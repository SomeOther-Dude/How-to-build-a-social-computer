//Class for changing facial expressions
//Written by Kiarash Tamaddon, September 2017

//# Facial expressions are originally created as blendShapes in Blender and then as components of the character, they are imported to Unity. 
//In Unity, you can find them in the inspector of the imported mesh under the title of "Skinned Mesh Renderer" as "Blend Shapes".
//This script (SetExpressionValues.cs) provides the possibility to change the facial expressions in the inspector or while running (by pushing some buttons)
//
//# How to use: 
//1. add this code as component of the avatar's mesh

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;


public class FacialExpressionsController : MonoBehaviour {

    // The name of the default expression, with no blend shapes applied.
    readonly static string DEFAULT_EXPRESSION_NAME = "Normal";

    // All teh blendshapes starting with this prefix will be considered as facial expressions.
    readonly static string EXPRESSION_BLENDSHAPE_PREFIX = "fe_";

	// If the difference between the target weight and the current onyl is below this threshold, snap to target instead of interpolating.
	readonly private static float SNAP_WEIGHT = 1.0f;

	// The time needed to go transit to the desired target expression.
	// Kind of... more precisely is the time needed to travel 80% of the distance.
	// See the documentation of the SmoothDamp for details.
	public float expressionTransitionTime = 0.2F;

	// Will contain the number of facial expressions sarting with "fe_"
	private int _numFacialExpressions;

	// This will contain the indices of all the BlendShapes that we selected for control.
	private int[] _expressionBlendShapeIndex;

	// The "current" target value of each of the facial expression blendshape.
	// We need an internal storage (instead of relying on the values stored in the geometry,
    // because other animation systems might override them (as happens when using avatars from the FBX format
	private float[] _currentBlendShapesWeight;

	// The desired target value of each of the facial expression blendshape.
	private float[] _targetBlendShapesWeight;

	// The current smooth damp velocity of each facial blendshape.
	private float[] _smoothDampVelocity;

	// Indicator of the current expression
	// 0 means no expression (Uses the default one). From 1 to expressionBlendShapeIndex.Lenght is an expression.
	public int currentExpressionIndex = 0 ;

	#if UNITY_EDITOR
	public string currentExpressionName;
	#endif

	// The Mesh from/to which we manipualte the BlendShapes
	private SkinnedMeshRenderer _meshRendered;
	private Mesh _sharedMesh;

	void Awake() {
		
		_meshRendered = GetComponent<SkinnedMeshRenderer>();
		Assert.IsNotNull(this._meshRendered) ;
		_sharedMesh = this._meshRendered.sharedMesh;

	}

	// Use this for initialization
	void Start () {		

		/////////////////////////////////////////////////////////
		//get facial expressions from blend shapes
		/////////////////////////////////////////////////////////
		List<int> fe_indices = new List<int>();

		for (int i=0; i < _sharedMesh.blendShapeCount; i++)
		{
			string s = _sharedMesh.GetBlendShapeName(i);
            if(s.StartsWith(EXPRESSION_BLENDSHAPE_PREFIX)){
				fe_indices.Add (i);
			}
		}

		_expressionBlendShapeIndex = fe_indices.ToArray() ;

		_numFacialExpressions = this._expressionBlendShapeIndex.Length;
		// Debug.Log("Num of blendshapes starting with fe_:" + _numFacialExpressions);

		_currentBlendShapesWeight = new float[_numFacialExpressions];
		_targetBlendShapesWeight = new float[_numFacialExpressions];
		_smoothDampVelocity = new float[_numFacialExpressions];

		ClearFacialExpression ();
	}


	void LateUpdate () {

		#if UNITY_EDITOR
//		Debug.Log("expr index " + current_expression_index) ;
//		Debug.Log("bs num " + (current_expression_index == 0 ? -1 : expressionBlendShapeIndex[current_expression_index-1]) ) ;
        this.currentExpressionName = currentExpressionIndex == 0 ? DEFAULT_EXPRESSION_NAME : _meshRendered.sharedMesh.GetBlendShapeName(_expressionBlendShapeIndex[currentExpressionIndex-1]) ;
		#endif
		
		//reset/set expressions values
		for (int expressionIndex = 0; expressionIndex < _numFacialExpressions; expressionIndex++) {

			// set the target weight of the requested expression to 100.
			if ((expressionIndex == (currentExpressionIndex-1))) {
				_targetBlendShapesWeight [expressionIndex] = 100;
			}else{
				//reset other expressions
				_targetBlendShapesWeight [expressionIndex] = 0.0f;
			}

			// Computes the new blend shape weight, by interpolating between the current weight and the target one.
			// float currentBSWeight = _meshRendered.GetBlendShapeWeight(_expressionBlendShapeIndex[expressionIndex]) ;
			float currentBSWeight = _currentBlendShapesWeight[expressionIndex];
			float targetBSweight = this._targetBlendShapesWeight[expressionIndex];
			float newBSWeight;
			if (Mathf.Abs(targetBSweight - currentBSWeight) < SNAP_WEIGHT)
            {
				newBSWeight = targetBSweight;
            } else
            {
				newBSWeight = Mathf.SmoothDamp(currentBSWeight, targetBSweight, ref this._smoothDampVelocity[expressionIndex], this.expressionTransitionTime);
			}

			// And stores it in the mesh
			_currentBlendShapesWeight[expressionIndex] = newBSWeight;
			_meshRendered.SetBlendShapeWeight (this._expressionBlendShapeIndex[expressionIndex], newBSWeight);
		}
	}
		
	public void SetNextFacialExpression(){
		currentExpressionIndex += 1;
		if (currentExpressionIndex > _numFacialExpressions) currentExpressionIndex = 0;
	}

	public void SetPreviousFacialExpression(){
		currentExpressionIndex -= 1;
		if (currentExpressionIndex < 0) currentExpressionIndex = _numFacialExpressions ;
	}

	public void SetExpressionTransitionTime(float transition_time_secs) {
		this.expressionTransitionTime = transition_time_secs;
	}

	public float GetExpressionTransitionTime() {
		return this.expressionTransitionTime;
	}

	public void ClearFacialExpression() {

		for (int expressionIndex = 0; expressionIndex < _numFacialExpressions; expressionIndex++) {
			_targetBlendShapesWeight [expressionIndex] = 0.0f;
		}

		currentExpressionIndex = 0;

	}

	//sets facial expression as passed by its name
	public void SetCurrentFacialExpression(string expression_name){

		for (int expressionIndex = 0; expressionIndex < _numFacialExpressions; expressionIndex++) {
			string s = _sharedMesh.GetBlendShapeName(_expressionBlendShapeIndex[expressionIndex]);
			if (s == expression_name) {
				currentExpressionIndex = expressionIndex + 1;
				break;
			}			
		}

	}

	//returns name of the current facial expression name
	public string GetCurrentFacialExpression (){

		if (currentExpressionIndex == 0)
            return(DEFAULT_EXPRESSION_NAME);
		else
			return _sharedMesh.GetBlendShapeName(_expressionBlendShapeIndex[currentExpressionIndex-1]);

	}

	/** Returns the list of facial expression starting with "fe_" */
	public string[] ListFacialExpressions() {

		List<string> expressions = new List<string>();

		for(int i = 0; i< _numFacialExpressions ; i++) 
		{
			expressions.Add(_sharedMesh.GetBlendShapeName(_expressionBlendShapeIndex[i])) ;
		}

		return expressions.ToArray() ;

	}
}








