//Class for setting up the buttons and texts of the GUI
//Written by Kiarash Tamaddon, September 2017

//# Here functionality of buttons and texts of the GUI are set accordingly
//
//# How to use: 
//1. Add this code as component of UI object which contains (is parent of) GUI texts and buttons
//2. Drag corrensponding objects to the inspector under this code as a component of the UI

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DECADGUISetup : MonoBehaviour {
	[Header(" ")]
	/** Reference to the Avatar game object object */
	public GameObject targetCharacterAvatar;
	///** Reference to the Mesh object */
	//public GameObject targetCharacterMesh;
	public GameObject activeCamera;

	[Header(" ")]
	public Text txtFExpression;
	public Text txtCameraShot;

	public Button Button_FE_Next;
	public Button Button_FE_Previous;
	public Button Button_Shot_Next;
	public Button Button_Shot_Previous;
	public Button MaryTTS_Say;
	public Button Button_Animation_Random;

	public Toggle Toggle_AmbientAnmation;

	public Toggle Toggle_LookAtCamera;
	public Toggle Toggle_LookAtMouse;
	public Toggle Toggle_LookAtDisabled;


	private Button btn_animation_random;
	private int randomAnimationNumber; //the randomly generated number is kept to avoid repeating sequential animations

	private AnimationController animationController;
	private FacialExpressionsController facialExprController;
	// private MaryTTSSayRandom ttsSayRandomScript;
	private MaryTTSController ttsController;

	private CameraCinemaControl cameraPositioner;
	private EyeHeadGazeController eyeHeadGazeController;

	void Awake()
	{
		// Get a reference to the animation controller af this avatar
		this.animationController = this.targetCharacterAvatar.GetComponent<AnimationController>();
		// Get facial expression controller from the child mesh.
		this.facialExprController = this.targetCharacterAvatar.GetComponentInChildren<FacialExpressionsController>();
		// Get the reference to the script controlling the text to speech, from the child mesh.
		this.ttsController = this.targetCharacterAvatar.GetComponentInChildren<MaryTTSController>();
		// Get the reference to the script controlling the position of the camera.
		this.cameraPositioner = this.activeCamera.GetComponent<CameraCinemaControl>();
		// Get the reference to the script controlling the eye/head Gaze
		this.eyeHeadGazeController = this.targetCharacterAvatar.GetComponentInChildren<EyeHeadGazeController>() ;
	}


	void Start()
	{
		Button btn_fe_next = Button_FE_Next.GetComponent<Button>();
		btn_fe_next.onClick.AddListener(nxtExpression);

		Button_FE_Previous.onClick.AddListener(prvExpression);

		MaryTTS_Say.onClick.AddListener(saySomething);

		Button_Shot_Next.onClick.AddListener(nxtShot);
		Button_Shot_Previous.onClick.AddListener(prvShot);

		btn_animation_random = Button_Animation_Random.GetComponent<Button>();
		btn_animation_random.onClick.AddListener(playRandomAnimation);

		Toggle_AmbientAnmation.isOn = animationController.enableAmbientAtStart;
		Toggle ambient_animation = Toggle_AmbientAnmation.GetComponent<Toggle> ();
		ambient_animation.onValueChanged.AddListener ((bool On)  =>  {atoggle();});

		Toggle_LookAtCamera.isOn = true;
		Toggle_LookAtMouse.isOn = false;
		Toggle_LookAtDisabled.isOn = false;

		Toggle lootAt_camera = Toggle_LookAtCamera.GetComponent<Toggle> ();
		lootAt_camera.onValueChanged.AddListener ((bool On)  =>  {toggleLookAtCamera();});

		Toggle lootAt_mouse = Toggle_LookAtMouse.GetComponent<Toggle> ();
		lootAt_mouse.onValueChanged.AddListener ((bool On)  =>  {toggleLookAtMouse();});

		Toggle lootAt_disabled = Toggle_LookAtDisabled.GetComponent<Toggle> ();
		lootAt_disabled.onValueChanged.AddListener ((bool On)  =>  {toggleLookAtDisabled();});

		toggleLookAtCamera ();


		//
		// Check if there is a command line option askibg to disable the GUI panel
		var args = System.Environment.GetCommandLineArgs();
		for (int i = 0; i < args.Length; i++)
		{
			if (args[i] == "--hide-gui")
			{
				Debug.Log("Disabling the GUI panel...");
				GameObject gui_top_obj = gameObject.transform.parent.gameObject;
				gui_top_obj.SetActive(false);

				break;
			}
		}

	}

	private void nxtExpression()
	{
		//set the next expression from the class FacialExpressionsController
		this.facialExprController.SetNextFacialExpression();
	}

	private void prvExpression()
	{
		//set the previous expression from the class FacialExpressionsController
		this.facialExprController.SetPreviousFacialExpression();
	}

	private void saySomething()
	{
		if (this.ttsController.IsMaryTTSspeaking())
		{
			return;
		}

		// Quick Dirty hack: reset the facial expression to normal before speaking.
		if (this.facialExprController)
		{
			this.facialExprController.ClearFacialExpression();
		}

		//set the next shot from the class CameraPositioner
		this.ttsController.MaryTTSsayRandomSentence();
	}

	//moves the camera to the next shot
	private void nxtShot()
	{
		//set the next shot through the class CameraPositioner
		this.cameraPositioner.GoToNextShot();
	}

	//moves the camera to the previous shot
	private void prvShot()
	{
		//set the previous shot through the class CameraPositioner
		this.cameraPositioner.GoToPreviousShot();
	}

	//plays random animations
	private void playRandomAnimation()
	{
		int lastNumber = randomAnimationNumber;

		//filters repeating animations
		while(randomAnimationNumber == lastNumber)
			randomAnimationNumber =	Random.Range (0, animationController.animationClips.Length);

		animationController.PlayAnimationClip(randomAnimationNumber);
	}

	//the toggle enables/disables idle(ambient) animation
	private void atoggle ()
	{
		if (Toggle_AmbientAnmation.isOn) {
			//this.cameraPositioner.SaveCurrentCameraTransform ();
			animationController.EnableAmbientAnimation();
		} else {
			//this.cameraPositioner.SaveCurrentCameraTransform ();
			animationController.DisableAmbientAnimation();
		}
	}



	//3 radio buttons for "Look At"
	//the toggle enables/disables 
	private void toggleLookAtCamera ()
	{
		if (Toggle_LookAtCamera.isOn) {
			Toggle_LookAtMouse.isOn = false;
			Toggle_LookAtDisabled.isOn = false;

			// Look at the camera
			Debug.Log ("LookAt: Camera");
			//this.eyeHeadGazeMouseFollower.enabled = false;
			this.enableMouseFollowing = false;
			eyeHeadGazeController.LookAtObject (this.activeCamera.name);
		}
	}

	//the toggle enables/disables
	private void toggleLookAtMouse ()
	{
		if (Toggle_LookAtMouse.isOn) {
			Toggle_LookAtCamera.isOn = false;
			Toggle_LookAtDisabled.isOn = false;

			// enable mouse pointer following
			Debug.Log("LookAt: Mouse");
			this.enableMouseFollowing = true;
		}
	}

	//the toggle enables/disables 
	private void toggleLookAtDisabled ()
	{
		if (Toggle_LookAtDisabled.isOn) {
			Toggle_LookAtMouse.isOn = false;
			Toggle_LookAtCamera.isOn = false;
		
			// Reset eye gaze to frontal default pose
			Debug.Log("LookAt: Disabled");
			//this.eyeHeadGazeMouseFollower.enabled = false;
			this.enableMouseFollowing = false;
			eyeHeadGazeController.StopLooking();

		}
	}

	private bool enableMouseFollowing = false ;

	private void Update () {
		//set the text according to curent expression
		txtFExpression.text = this.facialExprController.GetCurrentFacialExpression ();

		//set the text according to current shot
		txtCameraShot.text = this.cameraPositioner.GetCurrentShot ();

		if (animationController.IsAnimationClipPlaying () == true){
			//print ("getting animation name");
		//write name of the animation on the button's text
			btn_animation_random.GetComponentInChildren<Text> ().text = animationController.GetPlayingAnimationClipName ();
		}
		else{
			//print ("random animation");
			btn_animation_random.GetComponentInChildren<Text> ().text = "Random Animations";
		}


		//
		// Eye gaze management
		// Create a ray from the Mouse click position
		if (this.enableMouseFollowing)
		{
			// Debug.Log("Ray casting ...");
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			// If the ray hits something: look there. It is supposed to be a panel in front of the character.
			RaycastHit hitInfo;
			if (Physics.Raycast(ray, out hitInfo))
			{

				// Vector3 targetPoint = new Vector3(hitInfo.point.x, hitInfo.point.y, hitInfo.point.z);
				// Debug.Log("Point: " + targetPoint.x + " " + targetPoint.y + " " + targetPoint.z);

				eyeHeadGazeController.LookAtPoint(hitInfo.point);
			}
		}

	}
}






