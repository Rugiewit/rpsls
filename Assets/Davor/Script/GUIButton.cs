using UnityEngine;
using System.Collections;

public class GUIButton : MonoBehaviour
{
		public int posX = 15;
		public int posY = 15;
		public int width = 150;
		public int height = 30;
		public string buttonName = "START";
		public bool paused = true;
		// Use this for initialization
		void Start ()
		{
			
		}
	
		// Update is called once per frame
		void Update ()
		{
				GUITexture guiText = GetComponent<GUITexture> ();
				if (paused != guiText.enabled) {
						paused = guiText.enabled;
						
				} 
		}
		private void OnGUI ()
		{
				if (paused) {
						GUI.Button (new Rect (posX, posY, width, height), buttonName);
				}
		}
}
