/** Android specific code.
 * Usage: add this script to any active in the scene, such as an empty.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidConfig : MonoBehaviour
{

	void Awake()
	{

		if (Application.platform == RuntimePlatform.Android)
		{
			//
			// De-activates some features of the PostProcessing.

			// https://github.com/Unity-Technologies/PostProcessing/wiki/(v1)-Runtime-post-processing-modification
			/*Camera m_renderingCamera = Camera.main;
			var behaviour = m_renderingCamera.GetComponent<PostProcessingBehaviour>();

			if (behaviour.profile == null)
			{
				// enabled = false;
				return;
			}

			PostProcessingProfile m_Profile = Instantiate(behaviour.profile);
			behaviour.profile = m_Profile;

			// Disable SSAO.
			Debug.Log ("Android: disabling Screen-Space Ambient Occlusion (SSAO).");
			m_Profile.ambientOcclusion.enabled = false;
			*/
		}
	}


    void Update()
    {

        //
        // On andoid systems, exits the application
        // when pressing the back button.
        //
        if (Application.platform == RuntimePlatform.Android)
		{
	        if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }
}
