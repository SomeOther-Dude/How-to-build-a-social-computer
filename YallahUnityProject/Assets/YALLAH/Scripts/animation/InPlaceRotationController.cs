using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InPlaceRotationController : MonoBehaviour {

    [Tooltip("Where the avatar wants to look at.")]
	public Vector3 targetFacingPoint = new Vector3(0,0,0);

    [Tooltip("Force at each frame the Y coordinate to 0. Useful if you have animations drifting on the vertical axis.")]
	public bool forceZeroY = true;

	// If the angle between the avatar fwd vector and the target goes below this value, the rot factor will decrease to 0.
    [Tooltip("If the angle between the avatar fwd vector and the target goes below this value, the avatar will stop rotating.")]
	public float rotationThresholdDegs = 5.0f;

    // The actual threshold used to tart/stop the rotation.
    // When going below the user-define rot threshold, this threshold is set to a higher value.
    // If the highr value is reached, this histeresis threshold will be again set to the user-defined.
    // This avoids instabilities at the threshold level.
    // See: https://en.wikipedia.org/wiki/Hysteresis#Control_systems
    private float rotHistheresiThresholdDegs;


	private static float rotDampMaxSpeed = 5.0f;

	// Reference to the animator, on which we will set the value of the parameters and the IK info.
	private Animator anim ;

	// The current rotation factor [-1,1]
	private float rotVal = 0.0f;
	// velocity for the smooth damp
	private float rotValVelocity = 0.0f;

    // The layer containing the InPlaceRotation state machine.
	private int animatorLayerIdx = -1 ;


	#if UNITY_EDITOR
	[Header("Test:")]
    [Tooltip("Orders the character to turn towards the Target Position")]
	public bool forceStart ;
    public bool forceStop ;
	#endif



	// Use this for initialization
	void Start () {
		// Take the reference to the animator on the same GameObject
		this.anim = GetComponent<Animator> ();

		this.animatorLayerIdx = this.anim.GetLayerIndex ("InPlaceRotation Layer");
		Debug.Assert (this.animatorLayerIdx != -1);

        this.rotHistheresiThresholdDegs = this.rotationThresholdDegs;

		/*
        //
        // Override the animations, so that we can be able to set the animation clips at run-time.

        // I needed to move them in the global animation controller, where there is already an Animator Override configuration.
		AnimatorOverrideController animatorOverrideController = new AnimatorOverrideController(this.anim.runtimeAnimatorController);
		this.anim.runtimeAnimatorController = animatorOverrideController;
		animatorOverrideController ["DUMMY_TURN_RIGHT_ANIMATION"] = this.turnRightAnimationClip;
		animatorOverrideController ["DUMMY_TURN_LEFT_ANIMATION"] = this.turnLeftAnimationClip;
		*/

	}


	public void TurnTowards(float x, float y, float z)
	{
		this.TurnTowards(new Vector3(x, y, z));
	}

	public void TurnTowards (Vector3 target_position) {
		this.targetFacingPoint = target_position;
		this.anim.SetTrigger ("inplacerotation_start");
	}


    public bool IsTurning() {
        AnimatorStateInfo state_info = this.anim.GetCurrentAnimatorStateInfo(this.animatorLayerIdx) ;
        return state_info.IsName ("InPlaceRotationBlendTree");
    }

    public void StopTurning() {
        if(IsTurning()) {
            this.anim.SetTrigger("inplacerotation_stop");
        }        
    }

	// Update is called once per frame
	void Update () {

		#if UNITY_EDITOR
		if (this.forceStart) {
			this.TurnTowards (this.targetFacingPoint);
			this.forceStart = false;
		}
        if(this.forceStop) {
            this.StopTurning();
            this.forceStop = false;
        }
		#endif


        if (! this.IsTurning()) {
			this.anim.ResetTrigger ("inplacerotation_stop");
			this.rotVal = 0;
            return;                         // <-- BEWARE: Jumps out!!!
		}

		//
		//
		Vector3 current_position = this.gameObject.transform.position;
		// Animation accumulates a vertical offset that we ahve to force at 0.
		if (this.forceZeroY) {
			current_position.y = 0.0f;
			gameObject.transform.position = current_position;
		}

		Vector3 current_fwd_vector = (this.gameObject.transform.rotation * Vector3.forward).normalized;

		Vector3 vec_to_target = (targetFacingPoint - current_position).normalized;

        // The dot product is 1 when the vectors are aligned, 0 when at 90 degrees, -1 when opposites.
		float dot = Vector3.Dot (current_fwd_vector, vec_to_target);
        // We use the vertical (y) coordinate of the cross product to understand weather to go left or right.
		Vector3 cross = Vector3.Cross (current_fwd_vector, vec_to_target);
		// Debug.Log ("dot=" + dot + "\tcross=" + cross);

		//
		// ROTATION
		float new_rot_val = 0.0f;
		bool rot_reached = false;

		// calc the dot product value equivalent to the threshold in degrees.
        // Essentially it maps the [0,90] degrees range to [1,0].
		// float rot_thr_dot_val = Mathf.Cos (Mathf.Deg2Rad * this.rotationThresholdDegs);
        float rot_thr_dot_val = Mathf.Cos (Mathf.Deg2Rad * this.rotHistheresiThresholdDegs);
        // If the dot product if less than the threshold, we need to rotate and re-align (which would bring the dor towards 1.0)
		if (dot < rot_thr_dot_val) {
            // If we enter the histererirs zone, lower the threshold so that we go down to the lower value.
            this.rotHistheresiThresholdDegs = this.rotationThresholdDegs;

			new_rot_val = 1.0f;

			// test if the rotation has to be done left or right
			if (cross.y < 0)
				new_rot_val *= -1.0f;
		} else {
			rot_reached = true;
            // If we reach the lower threshold, set the new limit to a higher value, to avoid jumps.
            this.rotHistheresiThresholdDegs = this.rotationThresholdDegs * 2f;
			Debug.Log ("ROT Reached!");
		}
        // Debug.Log("HistThrsdegs=" + this.rotHistheresiThresholdDegs);

		this.rotVal = Mathf.SmoothDamp (this.rotVal, new_rot_val, ref this.rotValVelocity, Time.deltaTime, InPlaceRotationController.rotDampMaxSpeed);

		//
		// Values to the animator
		// Control left/right rotation
		this.anim.SetFloat ("inplacerotation_rot_factor", this.rotVal);


		if(rot_reached) {
			// Debug.Log ("Triger Stop");
			this.anim.SetTrigger ("inplacerotation_stop");
		}
	}

}
