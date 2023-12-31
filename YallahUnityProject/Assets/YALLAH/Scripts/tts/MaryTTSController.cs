﻿using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Assertions;

using System;
using System.Collections;
using System.Collections.Generic;

// Provides Random
using UnityEngine;

using haxe.root;


/**
 * Blender blend shape value range: 0.0-1.0
 * Unity blend shape value range: 0.0-100.0
 */
[RequireComponent(typeof(SkinnedMeshRenderer))]
public class MaryTTSController : MonoBehaviour {

    //
    // The name of the resource file containing the mapping between the phonemes received by MaryTTS and the corresponding visemes.
    private static readonly string MARYTTS_INFO_JSON_RESOURCE = "MaryTTS-Info-MBLab1_6" ;

	//
	// MaryTTS server info
    [Tooltip("The http address and the port of a running MaryTTS server, e.g.: 'localhost:59125'")]
    public String maryServerAndPort = "localhost:59125" ;

	//
	// MaryTTS voice info
	public enum MaryTTSVoice {
        DFKI_PRUDENCE,
        DFKI_PRUDENCE_HSMM,
        DFKI_POPPY,
        DFKI_POPPY_HSMM,
        CMU_SLT,
        CMU_SLT_HSMM,
        CMU_BDL_HSMM,
        CMU_RMS_HSMM,
        DFKI_OBADIAH,
        DFKI_OBADIAH_HSMM,
        DFKI_SPIKE,
        DFKI_SPIKE_HSMM,
        FR_UPMC_PIERRE_HSMM,
        FR_ENST_CAMILLE_HSMM,
        ISTC_LUCIA_HSMM,
        DE_BITS1_HSMM_FEMALE,
        DE_BITS3_HSMM_MALE
	};

	/** Small structure to hold voice name and its language. */
	private class VoiceInfo {
		public string voice;
		public string locale;

		public VoiceInfo(string voice, string locale) {
			this.voice = voice;
			this.locale = locale;
		}
	}


	private static readonly Dictionary<MaryTTSVoice, VoiceInfo> VOICES = new Dictionary<MaryTTSVoice, VoiceInfo>
	{
        {MaryTTSVoice.ISTC_LUCIA_HSMM, new VoiceInfo("istc-lucia-hsmm", "it")},
		{MaryTTSVoice.CMU_SLT, new VoiceInfo("cmu-slt", "en_US")},
		{MaryTTSVoice.CMU_SLT_HSMM,new VoiceInfo("cmu-slt-hsmm", "en_US")},
        {MaryTTSVoice.CMU_BDL_HSMM,new VoiceInfo("cmu-bdl-hsmm", "en_US")},
        {MaryTTSVoice.CMU_RMS_HSMM,new VoiceInfo("cmu-rms-hsmm", "en_US")},
		{MaryTTSVoice.DFKI_PRUDENCE, new VoiceInfo("dfki-prudence", "en_GB")},
		{MaryTTSVoice.DFKI_PRUDENCE_HSMM, new VoiceInfo("dfki-prudence-hsmm", "en_GB")},
		{MaryTTSVoice.DFKI_POPPY, new VoiceInfo("dfki-poppy", "en_GB")},
		{MaryTTSVoice.DFKI_POPPY_HSMM, new VoiceInfo("dfki-poppy-hsmm", "en_GB")},
		{MaryTTSVoice.DFKI_OBADIAH, new VoiceInfo("dfki-obadiah", "en_GB")},
		{MaryTTSVoice.DFKI_OBADIAH_HSMM, new VoiceInfo("dfki-obadiah-hsmm", "en_GB")},
		{MaryTTSVoice.DFKI_SPIKE, new VoiceInfo("dfki-spike", "en_GB")},
		{MaryTTSVoice.DFKI_SPIKE_HSMM, new VoiceInfo("dfki-spike-hsmm", "en_GB")},
		{MaryTTSVoice.FR_UPMC_PIERRE_HSMM, new VoiceInfo("upmc-pierre-hsmm", "fr")},
		{MaryTTSVoice.FR_ENST_CAMILLE_HSMM, new VoiceInfo("enst-camille-hsmm", "fr")},
        {MaryTTSVoice.DE_BITS1_HSMM_FEMALE, new VoiceInfo("bits1-hsmm", "de")},
        {MaryTTSVoice.DE_BITS3_HSMM_MALE, new VoiceInfo("bits3-hsmm", "de")}
	} ;


	public MaryTTSVoice mary_tts_voice;

	// A global multiplier to amplify, attenuate mouth articulation.
	public double blendshapesMultiplier = 1.0;
	
    [Tooltip("Extra parameters in MaryTTS URL format. See http://localhost:59125/audioeffects. E.g.: &effect_Robot_selected=on&effect_Robot_parameters=amount:60.0;&effect_Volume_selected=on&effect_Volume_parameters=amount:1.5;")]
    public string additionalHTTPRequestParameters = "";


	// URL composition instructions at: http://mary.dfki.de:59125/documentation.html
	private const string MARY_TTS_AUDIO_PARAMETER = "&OUTPUT_TYPE=AUDIO&AUDIO=WAVE_FILE";
	private const string MARY_TTS_REALISED_DURATION_PARAMETER = "&OUTPUT_TYPE=REALISED_DURATIONS";

	private SkinnedMeshRenderer skinnedMeshRenderer;
	private Mesh skinnedMesh;

    /** The sequencer is generated by Haxe. Check directory `YALLAH/Scripts/haxe_lib` */
    private MaryTTSBlendSequencer sequencer = null ;
    private double[] viseme_weights ;


    /** This is an audio source that is initialized during Awake.
     * It will play back the synthetized  audio.
     */
    private AudioSource audioSource = null;


    private static readonly Dictionary<string, string[]> TEST_SENTENCES = new Dictionary<string, string[]> {
        {"en_US",
            new string [] {
                "Hello, how are you?",
                "If everything goes right both individuals shake hands and go back to the world with a smile.",
                "I am gonna make him an offer he cant refuse.",
                "They may take our lives but not our freedom.",
                "The quick brown fox jumps over the lazy dog."
            }
        },

        {"en_GB",
            new string [] {
                "Hello, how are you?",
                "If everything goes right both individuals shake hands and go back to the world with a smile.",
                "I am gonna make him an offer he cant refuse.",
                "They may take our lives but not our freedom.",
                "The quick brown fox jumps over the lazy dog."
            }
        },

        {"fr",
            new string[] {
                "Bienvenue dans le monde de la synthèse de la parole!",
                "Bonjour, comment ça marche?"
            }
        },

        {"it",
            new string[] {
                "Ciao, come stai?",
                "Benvenuto nel mondo della sintesi vocale.",
                "Nel mezzo del cammin di nostra vita, mi ritrovai per una selva oscura."
            }
        },

        {"de",
            new string[] {
                "Hallo, wie ghet es Ihnen?",
                "Willkommen in der Welt der YALLAH!",
                "Ich bin Anna"
            }
        }

    };

#if UNITY_EDITOR

    [Header("Test:")]
    // A couple of checkboxes to test the engine from within the editor.
	public bool saySomething ;
    public bool stopSpeaking;

    /** Counter to advance through the demo sentences. */
    private static int SENTENCE_POSITION = -1;

#endif


    #region Listener
    public interface MaryTTSListener
    {
        void SpeechFinished(System.Object param);
    }

    private System.Object currentListenerParameter = null;
    private List<MaryTTSListener> listeners = new List<MaryTTSListener>();

    public void AddListener(MaryTTSListener l)
    {
        this.listeners.Add(l);
    }

    public void RemoveListener(MaryTTSListener l)
    {
        this.listeners.Remove(l);
    }
    #endregion


    void Awake () {
		this.skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer> ();
        this.skinnedMesh = GetComponent<SkinnedMeshRenderer> ().sharedMesh;

        // For info, see: https://docs.unity3d.com/2017.4/Documentation/ScriptReference/Resources.html
        Debug.Log("Loading MaryTTS info from resource: " + MARYTTS_INFO_JSON_RESOURCE);
        TextAsset tts_info_asset = Resources.Load<TextAsset>(MARYTTS_INFO_JSON_RESOURCE);
        Assert.IsNotNull(tts_info_asset);
        this.sequencer = new MaryTTSBlendSequencer(tts_info_asset.text);

        // Initialize the audio source that we need for speaking.
        this.audioSource = this.gameObject.AddComponent<AudioSource>();
	}

	void Start () {
		Assert.IsNotNull(skinnedMeshRenderer); 
		Assert.IsNotNull(skinnedMesh);

        //
        // Check that all the visemes required by the Sequencer are indeed present in the mesh.
        string[] needed_visemes = this.sequencer.getVisemes();
        for (int i = 0; i < needed_visemes.Length; i++) {
            string bs_name = needed_visemes[i];
            if (skinnedMesh.GetBlendShapeIndex(bs_name) == -1)
            {
                Debug.LogError("The BlendShape '" + bs_name + "' is required by TTS but missing in skinnedMesh.");
            }
        }

        this.viseme_weights = new double[this.sequencer.get_viseme_count()];


        //
        // Override Check if the VSM address:port is updated via command line
        var args = System.Environment.GetCommandLineArgs();
        for (int i = 0; i < args.Length; i++)
        {
            if (args[i] == "--marytts-socket-address" && args.Length > i + 1)
            {
                string sock_address = args[i + 1];
                Debug.Log("Replacing the MaryTTS socket address with " + sock_address);
                this.maryServerAndPort = sock_address;
            } else if (args[i] == "--marytts-voice" && args.Length > i + 1)
            {
                string new_voice_str = args[i + 1];
                MaryTTSVoice new_voice;
                bool isValidEnum = Enum.TryParse(new_voice_str, out new_voice);
                if (isValidEnum) {
                    this.mary_tts_voice = new_voice;
                } else
                {
                    Debug.Log("Warning. The voice specified in the command line is not recognized: " + new_voice_str);
                }
            }
        }

    }

    public void MaryTTSspeak(string text)
    {
        this.MaryTTSspeak(text, null);
    }

    public void MaryTTSspeak(string text, System.Object listener_param) {

        // If it is already speaking, notify listeners
        if (this.sequencer.is_speaking())
        {
            this._notifySpeechFinished();
        }

        this.currentListenerParameter = listener_param;
        StartCoroutine(ProcessInputText (text));
	}

    public void MaryTTSstopSpeaking()
    {
        this.audioSource.Stop();
        this.audioSource.clip = null;
        this.sequencer.stop_sequencer();
    }

    public void MaryTTSsayRandomSentence()
    {
        VoiceInfo voice_info = MaryTTSController.VOICES[this.mary_tts_voice];
        string[] locale_sentences = MaryTTSController.TEST_SENTENCES[voice_info.locale];

        int rnd_id = UnityEngine.Random.Range(0, locale_sentences.Length);
        string sentence = locale_sentences[rnd_id];
        //Debug.Log(sentence);
        this.MaryTTSspeak(sentence);

    }

    public bool IsMaryTTSspeaking()
    {
        return this.sequencer.is_speaking();
        // Or directly check if audio is being emitted.
        // return this.audioSource.isPlaying;
    }

    /** The co-routine method to get new info from MaryTTS without blocking anything. */
    private IEnumerator ProcessInputText(string text)
    {
        // Adapt the text to be put in a URL
        text = text.Replace(" ", "+");

        //
        // Prepare the URLs to contact the MaryTTS server.

        String MARY_TTS_HTTP_ADDRESS = "http://" + this.maryServerAndPort;
        // Debug.Log ("Composed address: " + MARY_TTS_HTTP_ADDRESS);

        VoiceInfo voice_info = MaryTTSController.VOICES[this.mary_tts_voice];

        String voice_parameter = "&VOICE=" + voice_info.voice;
        // Debug.Log("Selected voice: " + voice_parameter);

        String locale_parameter = "&LOCALE=" + voice_info.locale;

        string request_url = MARY_TTS_HTTP_ADDRESS + "/process?INPUT_TEXT=" + text + "&INPUT_TYPE=TEXT" + voice_parameter + locale_parameter + this.additionalHTTPRequestParameters;
        Debug.Log("Request URL: " + request_url);

        //
        // Fetch audio
        WWW audioResponse = new WWW(request_url + MARY_TTS_AUDIO_PARAMETER);
        yield return MaryTTWaitForRequest(audioResponse);

        //
        // Fetch realised durations
        WWW rdurationsResponse = new WWW(request_url + MARY_TTS_REALISED_DURATION_PARAMETER);
        yield return MaryTTWaitForRequest(rdurationsResponse);

        //
        // Parse the realised durations
        sequencer.parse_realized_durations(rdurationsResponse.text);

        //
        // Play audio and start the animation sequencer
        AudioClip new_clip = audioResponse.GetAudioClip(false, false, AudioType.WAV);
        this.audioSource.clip = new_clip;
        this.audioSource.Play();

        // Re-Initialize the sequencer
        this.sequencer.reset_timers();
    
    }

    /** Support co-routine method to get info from the web without blocking anything. */
	private IEnumerator MaryTTWaitForRequest(WWW www) {
		yield return www;

		// Check for errors
		if (!string.IsNullOrEmpty(www.error)) {
            Debug.LogError("WWW error: " + www.error);
		}
	}



    private bool wasSpeaking = false;

	// Update is called once per frame
	void LateUpdate() {


		#if UNITY_EDITOR
		if (this.saySomething) {
			VoiceInfo voice_info = MaryTTSController.VOICES[this.mary_tts_voice];
			string[] locale_sentences = TEST_SENTENCES[voice_info.locale] ;

            SENTENCE_POSITION += 1;
            if(SENTENCE_POSITION >= locale_sentences.Length) {
                SENTENCE_POSITION = 0;
            }
            string to_say = locale_sentences[SENTENCE_POSITION] ;
			this.MaryTTSspeak (to_say);
			this.saySomething = false;
		}

        if (this.stopSpeaking)
        {
            this.MaryTTSstopSpeaking();
            this.stopSpeaking = false;
        }
		#endif


        // Asks teh sequencer to update the viseme_weights vector with the new weights. */
		this.sequencer.update(Time.time, this.viseme_weights);
		// Debug.Log (this.viseme_weights [0]);


        //
        // Transfer the viseme weights into the blendshapes.
        for (int i=0 ; i < this.sequencer.get_viseme_count() ; i++) {
            string viseme = (string)(this.sequencer.VISEMES [i]);

			int blendShapeIdx = this.skinnedMesh.GetBlendShapeIndex(viseme);
			// Debug.Log ("Looking for viseme " + viseme+". Index: " + blendShapeIdx);

			// Simple version
			double weight = this.viseme_weights[i] * 100.0 * this.blendshapesMultiplier;

			// Tries to soften movements at low values
			//double sw = this.viseme_weights[i] ;
			//sw = -2.0 * (sw * sw * sw) + 3.0 * (sw * sw);
			//double weight = sw * 100.0 * this.blendshapesMultiplier;
			skinnedMeshRenderer.SetBlendShapeWeight(blendShapeIdx, (float) weight);
		}

        //
        // Manager Listeners
        bool speaks_now = this.sequencer.is_speaking();
        if (speaks_now == false)
        {
            if (this.wasSpeaking)
            {
                this._notifySpeechFinished();
            }
        }
        this.wasSpeaking = speaks_now;

    }


    private void _notifySpeechFinished()
    {
        foreach (MaryTTSListener l in this.listeners)
        {
            l.SpeechFinished(this.currentListenerParameter);
        }
        this.currentListenerParameter = null;

    }


}
