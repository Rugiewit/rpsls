using UnityEngine;
using System.Collections;

public class GUIButton : MonoBehaviour
{
		private static int numOfButtons = 3;
		private static int width = 150;
		private static int height = 30;

		private static int spacingY = 40;	
		private static int posX = (Screen.width / 2) - (width / 2);
		private static int posY = (Screen.height / 2) - (numOfButtons * height) + ((numOfButtons - 1) * spacingY);

		public string strName = "START";
		public string cntName = "CONTINUE";

		public string rsName = "RESET";
		public string exName = "EXIT";
		private bool paused = true;
		//public Texture2D buttonImage = null;
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
						GameObject gameDirectorObj = GameObject.Find ("GameDirector");
						GameDirector gameDirector = gameDirectorObj.GetComponent<GameDirector> ();		

						//on Start ButtonClicked
						string btnName = gameDirector.IsStarted () ? cntName : strName;
						if (GUI.Button (new Rect (posX, posY, width, height), btnName)) {
								Play (gameDirectorObj);
								gameDirector.setStarted (true);
						}
						//on Reset Button Clicked
						if (GUI.Button (new Rect (posX, posY + ((numOfButtons - 2) * spacingY), width, height), rsName)) {
								Play (gameDirectorObj);
								//reset all parameters here	
								gameDirector.Reset ();
								
					
						}
						//on Exit Button Clicked
						if (GUI.Button (new Rect (posX, posY + ((numOfButtons - 1) * spacingY), width, height), exName)) {
								Application.Quit ();
						}
				}
		}
		private void Play (GameObject gameDirectorObj)
		{				
				Pause pause = gameDirectorObj.GetComponent<Pause> ();
				pause.pause = false;
		}

}
