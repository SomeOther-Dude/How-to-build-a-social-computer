using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

using NativeWebSocket;
using System;


public class QuestionnaireControl : MonoBehaviour
{
    // Information for connecting to the VSM server
    public string ServerAddress = "127.0.0.1";
    public int ServerPort = 5002;
    public float ReconnectDelaySecs = 2.0f;

    /** The websocket used for communication. Send messages with:
     * <pre>
     * Task s = _webSock.SendText(msg);
     * s.Wait();
     * </pre>
     */
    private WebSocket _webSock;


    [Tooltip("The reference to the Text instance showing the question on the UI.")]
    public Text questionText;

    [Tooltip("Reference to the global gui scaler. Useful to Zoom the whole GUI in/out accordign to HW specific size.")]
    public GameObject guiScaler;

    [Tooltip("This must be initializized through the GUI to point ot the game objects showing the labels. Needed to set the label text at runtime.")]
    public GameObject[] labelObjects;

    /** The action id of the question currently displayed. Must be sent back to VSM to inform that the user answered. */
    int _displayedQuestionID;


    //
    // Start is called before the first frame update
    //
    void Start()
    {
        //
        // Sanity check
        Debug.Assert(questionText != null);
        Debug.Assert(guiScaler != null);
        Debug.Assert(labelObjects.Length == 7);
        foreach(GameObject label_obj in labelObjects)
        {
            Debug.Assert(label_obj != null);

        }

        //
        // Check if the VSM address:port is updated via command line
        var args = System.Environment.GetCommandLineArgs();
        for (int i = 0; i < args.Length; i++)
        {
            if (args[i] == "--questionnaire-socket-address" && args.Length > i + 1)
            {
                string sock_address = args[i + 1];
                Debug.Log("Replacing questionnaire socket address with " + sock_address);
                string[] addr_and_port = sock_address.Split(':');
                if (addr_and_port.Length == 2)
                {
                    this.ServerAddress = addr_and_port[0];
                    this.ServerPort = Int32.Parse(addr_and_port[1]);
                }
                else
                {
                    Debug.Log("Wrong format. Expected <ip_addr>:<port>.");
                }
            }

            else if((args[i] == "--questionnaire-zoom" && args.Length > i + 1))
            {
                float zoom = float.Parse(args[i + 1]);
                Debug.Log("Setting questionnaire x/y scale to  " + zoom);

                guiScaler.transform.localScale = new Vector3(zoom, zoom, 1.0f);
            }
        }


        //
        // Now initialize the WebSocket

        // It is important to have the trailing slash!
        String serverURL = "ws://" + this.ServerAddress + ":" + this.ServerPort + "/";
        Debug.Log("WebSocket Server URL is '" + serverURL + "'.");

        _webSock = new WebSocket(serverURL);

        _webSock.OnMessage += (bytes) =>
        {
            // Reading a plain text message
            var message = System.Text.Encoding.UTF8.GetString(bytes);
            // Debug.Log("WebSocket Got message: " + message);
            _HandleWSmessage(message);
        };

        _webSock.OnError += (msg) =>
        {
            // Reading a plain text message
            //var message = System.Text.Encoding.UTF8.GetString(bytes);
            Debug.Log("WebSocket Error: " + msg);
        };

        _webSock.OnClose += (msg) =>
        {
            Debug.Log("WebSocket Connection closed: " + msg);
        };


        // BEWARE!!! In UnityEditor `Connect` is blocking!
        // It will unlock only when the socket closes.
        //await _webSock.Connect();

        // Can only use the await form. Explicit use of Task hangs the system
        /*Task t = _webSock.Connect();
        t.Wait();
        Debug.Log(t.Status);
        if (t.IsFaulted)
        {
            Debug.Log(t.Exception);
        }
        Debug.Log("Connected.");
        */

        Debug.Log("WebSocket State: " + _webSock.State);

        // Hide the whole GUI
        Debug.Log("Hiding the Questionnaire GUI");
        gameObject.GetComponent<Canvas>().enabled = false;
    }


    private async void _OpenSocket()
    {
        if (_webSock.State == WebSocketState.Closed)
        {
            await _webSock.Connect();
            Debug.Log("Connect Terminated.");
        }
    }

    private async void _CloseSocket()
    {
        if (_webSock.State == WebSocketState.Open)
        {
            await _webSock.Close();
            Debug.Log("Socket Closed.");
        }

    }


    private async void OnApplicationQuit()
    {
        if (_webSock != null)
        {
            await _webSock.Close();
            _webSock = null;
        }
    }



    private float _socketLastCheckTime = 0.0f;

    // Update is called once per frame
    void Update()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        // The following test is mandatory, to prevent Unity (Editor)
        // giving NullPointer messages after a certain inactivity while disconnected.
        //if (_webSock.State == WebSocketState.Open)
        {
            _webSock.DispatchMessageQueue();
        }
#endif
        float now = Time.time;
        float socket_unchecked_for = now - this._socketLastCheckTime;


        if (socket_unchecked_for > ReconnectDelaySecs)
        {
            this._socketLastCheckTime = now;
            if (_webSock.State == WebSocketState.Closed)
            {
                Debug.Log("Socket closed for more than " + ReconnectDelaySecs + " seconds. Reconnecting...");
                Invoke("_OpenSocket", 0);
                this._socketLastCheckTime = Time.time;
            }
        }

    }


    private void _displayQuestion(string question_text)
    {
        questionText.text = question_text;
        // Show the whole GUI
        gameObject.GetComponent<Canvas>().enabled = true;
    }

    // Set the name of the labels by looking objects "label_0" thorugh "label_6"
    private void _setLabels(string[] labels)
    {
        // For each label, search for the object displaying ites text, and set it.
        for(int i=0; i<labels.Length; i++)
        {
            GameObject label_obj = labelObjects[i];
            Text txt_comp = label_obj.GetComponent<Text>();
            txt_comp.text = labels[i];
        }
    }


    // Available as callback for other components
    public void questionAnswered(int n)
    {
        // Debug.Log("Click detected with params " + n);

        // Hide the whole GUI
        gameObject.GetComponent<Canvas>().enabled = false;

        // Send the result to the server
        if (this._webSock.State == WebSocketState.Open)
        {

            QuestionnaireAnswer answer = new QuestionnaireAnswer();
            answer.action_id = _displayedQuestionID;
            answer.question_text = questionText.text;
            answer.answer = n;

            string msg = JsonUtility.ToJson(answer);
            Debug.Log("Question answered. Sending '" + msg + "'");
            this._webSock.SendText(msg);
        }

    }


    #region JSON support classes
    //
    // These are the support classes to parse the JSON messages coming from VSM.

    [System.Serializable]
    class VSMCommandMessage
    {
        public int action_id;
        public string command;
        public string parameters;
    }

    [System.Serializable]
    class CommandAnswer
    {
        public int action_id;
    }

    [System.Serializable]
    class QuestionnaireAnswer: CommandAnswer
    {
        public string question_text;
        public int answer;
    }


    #endregion



    private void _HandleWSmessage(string msg)
    {
        //Debug.Log("Received JSON: " + msg);

        VSMCommandMessage cmd_msg = JsonUtility.FromJson<VSMCommandMessage>(msg);
        //Debug.Log("Message type: " + vsm_msg.type);

        Debug.Log("Built JSON: " + JsonUtility.ToJson(cmd_msg));

        // Unpack the parameters (separated by vertical columns)
        string[] parameters_list = cmd_msg.parameters.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
        Dictionary<string, string> parameters_dict = new Dictionary<string, string>();
        foreach (string param_entry in parameters_list)
        {
            string[] param_value_pair = param_entry.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
            if (param_value_pair.Length != 2)
            {
                Debug.LogError("Command parameter malformed. Expected 'key=value', got '" + param_entry + "'");
            }
            parameters_dict.Add(param_value_pair[0], param_value_pair[1]);
        }
        // Debug.Log("Got " + parameters_dict.Count + " parameters");

        //
        // And invoke the command
        this._handleCommand(cmd_msg.action_id,  cmd_msg.command, parameters_dict);

    }


    private void _handleCommand(int action_id, string cmd, Dictionary<string, string> parameters)
    {
        // Question
        // * name: string
        if (cmd == "Question")
        {
            string question_text = parameters["text"];
            _displayedQuestionID = action_id;
            // Debug.Log("Playclip " + name);
            _displayQuestion(question_text);
        }
        // SetLabels
        // * labels: string  (label1;label2;label3;...)
        else if (cmd == "SetLabels")
        {
            string labels_strlist = parameters["labels"];
            string[] labels_array = labels_strlist.Split(';');
            _setLabels(labels_array);

            // Operation is instantaneous, we can answer immediately.
            CommandAnswer answer = new CommandAnswer();
            answer.action_id = action_id;
            string answer_str = JsonUtility.ToJson(answer);
            this._webSock.SendText(answer_str);
        }
        else
        {
            Debug.LogError("Questionnaire command not recognized: " + cmd);
        }
    }

}
