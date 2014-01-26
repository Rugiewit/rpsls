using UnityEngine;
using System.Collections;

public class GameDirector : MonoBehaviour
{
		public GameObject world;

		public GameObject player1;
		public GameObject player2;

		public GameObject guiPlayer1 = null;
		public GameObject guiPlayer2 = null;
		public GameObject guiWinPoint1 = null;
		public GameObject guiWinPoint2 = null;

		public GameObject pill;

		private bool isStarted = false;

		public GameObject pillPrefab;

		public float spawnPillTimer = 5;
		private float timeSinceLastPill = 0f;
		
		// Use this for initialization
		void Start ()
		{				
				Reset ();
		}	

		// Update is called once per frame
		void Update ()
		{	
				timeSinceLastPill += Time.deltaTime;
				if (timeSinceLastPill > spawnPillTimer) {
						SpawnPill ();
						timeSinceLastPill = 0;
				}
		}

		public void ScorePoint (string name)
		{
				if (player1.name == name) {
						GuiWinPoint gwp1 = guiWinPoint1.GetComponent<GuiWinPoint> ();
						GuiWinPoint gwp2 = guiWinPoint2.GetComponent<GuiWinPoint> ();
						if (gwp2.numOfPoints == 0) {
								gwp1.Change (gwp1.numOfPoints + 1);
						} else {
								gwp2.Change (gwp2.numOfPoints - 1);
						}
				} else {
						GuiWinPoint gwp1 = guiWinPoint2.GetComponent<GuiWinPoint> ();
						GuiWinPoint gwp2 = guiWinPoint1.GetComponent<GuiWinPoint> ();
						if (gwp2.numOfPoints == 0) {
								gwp1.Change (gwp1.numOfPoints + 1);
						} else {
								gwp2.Change (gwp2.numOfPoints - 1);
						}
				}
		}

		public void ChangePlayerStatus (string playerName, int status)
		{
				if (player1.gameObject.name == playerName) {
						guiPlayer1.GetComponent<GUIChangeling> ().setNextState (status);
				} else {
						guiPlayer2.GetComponent<GUIChangeling> ().setNextState (status);
				}
				//check who is winning set into power
				int p1s = player1.GetComponent<Player_Collisions> ().status;	
				int p2s = player2.GetComponent<Player_Collisions> ().status;
				if (p1s != p2s) {
						SetThePower (2, checkIsStatusLosing (p1s, p2s));
				}
		}
		public void SetThePower (int player, bool power)
		{
				if (player == 1) {
						guiPlayer1.GetComponent<GUIChangeling> ().SetThePower (power);
						guiPlayer2.GetComponent<GUIChangeling> ().SetThePower (!power);
				} else {
						guiPlayer1.GetComponent<GUIChangeling> ().SetThePower (!power);
						guiPlayer2.GetComponent<GUIChangeling> ().SetThePower (power);
				}
		}
		public static bool checkIsStatusLosing (int statusSource, int statusTarget)
		{
				if (statusSource != statusTarget) {
						switch (statusSource) {
						case 0: //Rock
								{
										if (statusTarget == 3)//Paper
												return true;
										if (statusTarget == 4)//Spock
												return true;
								}
								break;
						case 1: //Scissors
								{
										if (statusTarget == 4) //Spock
												return true;
										if (statusTarget == 0) //Rock
												return true;
								}
								break;
						case 2: //Lizard
								{
										if (statusTarget == 1) // Scissors
												return true;
										if (statusTarget == 0) //Rock
												return true;
								}
								break;
						case 3: //Paper
								{
										if (statusTarget == 2) //Lizard
												return true;
										if (statusTarget == 1) //Scissors
												return true;
								}
								break;
						case 4: //Spock
								{
										if (statusTarget == 2) // Lizzard
												return true;
										if (statusTarget == 3) // Paper
												return true;
								}
								break;
						}
				}

				return false;
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
				//Spawn spawn = obj.GetComponent<Spawn> ();
				//spawn.Respawn ();
		}
		public void setStarted (bool st)
		{
				isStarted = st;
		}
		public bool IsStarted ()
		{
				return isStarted;
		}

		public void SpawnPill ()
		{
				Vector3 spawnPos = Random.onUnitSphere * 0.5f;
				GameObject new_obj = GameObject.Instantiate (pillPrefab, spawnPos, pillPrefab.transform.rotation) as GameObject;
				new_obj.name = "Pill";
		}
}
