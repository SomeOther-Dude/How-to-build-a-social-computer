using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Code appling WebGL specific configuration.
 */
public class WebGLSetup : MonoBehaviour {

	void Awake()
	{
		// This property enables listening on keyboard events for input fields in html pages
		// https://forum.unity3d.com/threads/input-field-in-webpage-not-working-with-unity-webgl-in-page.316016/#post-2221329
		#if !UNITY_EDITOR && UNITY_WEBGL
		Debug.Log ("WebGL specific Setup");
		WebGLInput.captureAllKeyboardInput = false;
		#endif
	}

}
