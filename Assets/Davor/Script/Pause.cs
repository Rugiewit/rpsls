using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour
{
		
		public bool pause = false;
		public GameObject pausedBackground;

		// Use this for initialization
		void Start ()
		{
		}
	
		// Update is called once per frame
		void Update ()
		{
				if (Input.GetKeyDown (KeyCode.Escape)) {
						pause = !pause;
				}
				if (pause) {
						Tweak (0.0f, true);
			
				} else {
						Tweak (1.0f, false);
				}
		}
		
		void  Tweak (float timeScale, bool enableTex)
		{
				Time.timeScale = timeScale;				
				GUITexture pauseGUI_tex = pausedBackground.GetComponent<GUITexture> ();
				pauseGUI_tex.enabled = enableTex;

		}
		
}