﻿using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour
{
		
		public bool pause = false;
		public GUITexture pauseGUI_tex;

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
						Stop ();
			
				} else {
						Play ();
				}
		}
		
		void Play ()
		{
				Time.timeScale = 1.0f;
				pauseGUI_tex.enabled = false;

		}
		void Stop ()
		{
				Time.timeScale = 0.0f;
				pauseGUI_tex.enabled = true;
		}
}