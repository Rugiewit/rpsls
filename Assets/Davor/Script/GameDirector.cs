using UnityEngine;
using System.Collections;

public class GameDirector : MonoBehaviour
{
		public GameObject world;

		public GameObject player1;

		public GameObject player2;

		public GameObject guiPlayer1 = null;
		public GameObject guiPlayer2 = null;

		public GameObject pill;

		private bool isStarted = false;
		
		// Use this for initialization
		void Start ()
		{				
				Reset ();
		}	

		// Update is called once per frame
		void Update ()
		{
				if (Input.GetKeyDown (KeyCode.Keypad0)) {
						guiPlayer1.GetComponent<GUIChangeling> ().Change (0);
				} else
				if (Input.GetKeyDown (KeyCode.Keypad1)) {
						guiPlayer1.GetComponent<GUIChangeling> ().Change (1);
				} else
				if (Input.GetKeyDown (KeyCode.Keypad2)) {
						guiPlayer2.GetComponent<GUIChangeling> ().Change (2);
				} else
				if (Input.GetKeyDown (KeyCode.Keypad3)) {
						guiPlayer2.GetComponent<GUIChangeling> ().Change (3);
				} else
				if (Input.GetKeyDown (KeyCode.Keypad4)) {
						guiPlayer1.GetComponent<GUIChangeling> ().Change (4);
				}
				if (Input.GetKeyDown (KeyCode.Keypad5)) {
						guiPlayer2.GetComponent<GUIChangeling> ().Change (5);
				}


		}
	
		public void Reset ()
		{				
				Spawn (player1);
				Spawn (player2);
				Spawn (pill);
				guiPlayer1.GetComponent<GUIChangeling> ().Reset ();
				guiPlayer2.GetComponent<GUIChangeling> ().Reset ();
		}
		private void Spawn (GameObject obj)
		{
				Spawn spawn = obj.GetComponent<Spawn> ();
				spawn.Respawn ();
		}
		public void setStarted (bool st)
		{
				isStarted = st;
		}
		public bool IsStarted ()
		{
				return isStarted;
		}
}
