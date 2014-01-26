using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Player_Collisions : MonoBehaviour
{

		public int status = 0;
		private float deltaTime;

		private float velocity = 10.0f;
		public bool fly_away = false;
		private float fly_away_speed = 0.2f;

		private float fly_threshold = 0.1f;
		private float flying_path_distance = 0.9f;

		public GameObject other_player;

		// Use this for initialization
		void Start ()
		{
				status = 3;
				
				//GameObject new_obj = GameObject.Instantiate (Resources.Load ("Pill")) as GameObject;
				//	new_obj.name = "Pill";
				//new_obj.transform.localScale = new Vector3 (0.25f, 0.25f, 0.25f);
//new_obj.transform.localEulerAngles = new Vector3 (-90, 0, 0);
				//	new_obj.transform.localPosition = Vector3.zero;

		}
	
		// Update is called once per frame
		void Update ()
		{


				if (fly_away) {

						GameObject obj = GameObject.Find ("World");
						Vector3 vec = (obj.transform.position - this.gameObject.transform.position).normalized;

						this.transform.position = this.transform.position - Time.deltaTime * vec * fly_away_speed;

						if ((obj.transform.position - this.gameObject.transform.position).magnitude > flying_path_distance) {
								fly_away = false;
								//GameObject p2 = GameObject.Find ("Player2");
								//Player2_Collisions p2_script = p2.GetComponent<Player2_Collisions>();
								Player_Collisions p2_script = other_player.GetComponent<Player_Collisions> ();
								string name = " ";
								if (p2_script.status == 0) {//Rock
										this.status = 4;//Spock
										name = "hand_spock";
								}
								if (p2_script.status == 1) { //Scissors
										this.status = 4;
										name = "hand_spock";
								}
								if (p2_script.status == 2) { //Lizard
										this.status = 0; //Rock
										name = "hand_rock";
								}
								if (p2_script.status == 3) {//Paper
										this.status = 2;
										name = "hand_lizard";
								}
								if (p2_script.status == 4) { //Spock
										this.status = 2;
										name = "hand_lizard";
								}

								//this.transform.position = Vector3.zero;

								//propagate change to the director for player 1
								GameObject god = GameObject.Find ("GameDirector");	
								GameDirector gd = god.GetComponent<GameDirector> ();
								gd.ChangePlayerStatus (this.gameObject.name, status);

								
								GameObject new_obj = GameObject.Instantiate (Resources.Load (name)) as GameObject;

								new_obj.name = "Hand";
				
								GameObject player_mesh = this.gameObject.transform.FindChild ("Hand").gameObject;
								Destroy (player_mesh);
								new_obj.transform.parent = this.gameObject.transform;
								new_obj.transform.localScale = new Vector3 (0.25f, 0.25f, 0.25f);
								new_obj.transform.localEulerAngles = new Vector3 (-90, 0, 0);
								new_obj.transform.localPosition = Vector3.zero;

						}
				}

	
		}

		void OnCollisionEnter (Collision col)
		{


				if (col.gameObject.name == other_player.name) {
						//Debug.Log ("Fly Away");
						Player_Collisions g = col.gameObject.GetComponent<Player_Collisions> ();
						fly_away = GameDirector.checkIsStatusLosing (this.status, g.status);
						if (g.status != this.status) {
								fly_away = GameDirector.checkIsStatusLosing (this.status, g.status);
								
								if (fly_away) {
										Debug.Log ("Away");
										//Collider current_collider = col.gameObject.GetComponent<Collider>();
										//current_collider.enabled = false;
								}

						}
				}



			

		
		}

		void OnTriggerEnter (Collider col)
		{



				if (col.gameObject.name == "Pill") {
						Debug.Log ("Pill detected");
						GameObject obj = col.gameObject;
						Pill_FlyPath path_script = obj.GetComponent<Pill_FlyPath> ();
						if (this.gameObject == path_script.target) {
				
	
								//Vector3 pos = obj.transform.FindChild("Hand").position;
								//Vector3 pos = this.gameObject.transform.FindChild ("Hand").position;
								//Quaternion rot = this.gameObject.transform.FindChild ("Hand").rotation;
				
								float r = Random.value;
				
								int s = 0;

								string name = " ";
								if ((r >= 0.0f) && (r < (1.0f / 5.0f))) {
										name = "hand_rock";
										s = 0;
								}
								if ((r >= (1.0f / 5.0f)) && (r < (2.0f / 5.0f))) {
										name = "hand_scissors";
										s = 1;
								}
								if ((r >= (2.0f / 5.0f)) && (r < (3.0f / 5.0f))) {
										name = "hand_lizard";
										s = 2;
								}
								if ((r >= (3.0f / 5.0f)) && (r < (4.0f / 5.0f))) {
										name = "hand_paper";
										s = 3;
								}
				
								if (r >= (5.0f / 6.0f)) {
										name = "hand_spock";
										s = 4;
								}


								this.status = s;
								//propagate change to the director for player 1
								GameObject god = GameObject.Find ("GameDirector");	
								GameDirector gd = god.GetComponent<GameDirector> ();
								gd.ChangePlayerStatus (this.gameObject.name, status);

								GameObject new_obj = GameObject.Instantiate (Resources.Load (name)) as GameObject;
								
								new_obj.name = "Hand";
				
								GameObject player_mesh = this.gameObject.transform.FindChild ("Hand").gameObject;
								Destroy (player_mesh);
								new_obj.transform.parent = this.gameObject.transform;
								new_obj.transform.localScale = new Vector3 (0.25f, 0.25f, 0.25f);
								new_obj.transform.localEulerAngles = new Vector3 (-90, 0, 0);
								new_obj.transform.localPosition = Vector3.zero;

								Destroy (obj);
				
			
						} else {
								Pill_FlyPath fly_path = col.gameObject.GetComponent<Pill_FlyPath> ();
				
								//GameObject p2 = GameObject.Find ("Player2");
								Player_Collisions c = other_player.GetComponent<Player_Collisions> ();
								if ((fly_path.target != this.gameObject) && (!c.fly_away)) {
										//GameObject obj2 = GameObject.Find ("Player2");

										List<Vector3> points = new List<Vector3> ();
										points.Add (this.gameObject.transform.position);
										GameObject o = GameObject.Find ("Main Camera");
										Vector3 cam_vec = (o.transform.position - other_player.transform.position).normalized;
										//points.Add (this.transform.position + flying_path_distance * cam_vec);
										points.Add (o.transform.position);
										Debug.Log (this.transform.position + flying_path_distance * cam_vec);
										//points.Add (obj2.transform.position);
										fly_path.setTarget (other_player, points);
								}
								if (fly_path.target == this.gameObject) {
										Destroy (col.gameObject);
								}

						}

		
				}
		}


}
