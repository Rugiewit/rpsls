using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player2_Collisions : MonoBehaviour {

	public int status = 0;
	private float deltaTime;
	
	private float velocity = 10.0f;
	public bool fly_away = false;
	public float fly_away_speed = 0.01f;
	
	private float fly_threshold = 0.1f;
	private float flying_path_distance = 0.2f;
	void Start () {
		
		status = 3;
		
	}
	
	// Update is called once per frame
	void Update () {
		/*deltaTime = Time.deltaTime;
		
		Vector3 pos = this.gameObject.transform.position;
		if(Input.GetKey (KeyCode.LeftArrow))
			pos.x = pos.x - (deltaTime) * velocity;
		if(Input.GetKey (KeyCode.RightArrow))
			pos.x = pos.x + deltaTime * velocity;
		if(Input.GetKey (KeyCode.UpArrow))
			pos.z = pos.z + deltaTime * velocity;
		if(Input.GetKey (KeyCode.DownArrow))
			pos.z = pos.z - deltaTime * velocity;
		this.gameObject.transform.position = pos;*/

		if(fly_away)
		{
			//Debug.Log ("Fly Away");
			GameObject obj = GameObject.Find ("Main Camera");
			Vector3 vec = (obj.transform.position - this.gameObject.transform.position).normalized;
			this.transform.position = this.transform.position + Time.deltaTime * vec * 0.1f;

			if((obj.transform.position - this.gameObject.transform.position).magnitude < fly_threshold)
			{
				fly_away = false;
				//this.transform.position = Vector3.zero;
			}
			
		}
		
		
	}

	void OnCollisionEnter(Collision col)
	{
		/*Debug.Log ("Collision");
		if(col.gameObject.name == "Pill")
		{
			Pill_FlyPath fly_path = col.gameObject.GetComponent<Pill_FlyPath>();
			
			GameObject p1 = GameObject.Find ("Player1");
			Player1_Collisions c = p1.GetComponent<Player1_Collisions>();
			if((fly_path.target != this.gameObject) && (!c.fly_away))
			{
				GameObject obj = GameObject.Find ("Player1");
				List<Vector3>points = new List<Vector3>();
				points.Add (this.gameObject.transform.position);
				GameObject o = GameObject.Find ("Main Camera");
				Vector3 cam_vec = (o.transform.position - obj.transform.position).normalized;
				//points.Add (this.gameObject.transform.position + flying_path_distance * cam_vec);
				points.Add (obj.transform.position);
				fly_path.setTarget (obj, points);
			}
			if(fly_path.target == this.gameObject)
			{
				Destroy (col.gameObject);
			}
			
		}*/
		
		if(col.gameObject.name == "Player1")
		{
			//Debug.Log ("Fly Away");
			Player1_Collisions g  = col.gameObject.GetComponent<Player1_Collisions>();
			if(g.status != this.status)
			{
				switch(this.status)
				{
				case 0: //Rock
				{
					if(g.status == 3)//Paper
						fly_away = true;
					if(g.status == 4)//Spock
						fly_away = true;
				}break;
				case 1: //Scissors
				{
					if(g.status == 4) //Spock
						fly_away = true;
					if(g.status == 0) //Rock
						fly_away = true;
				}break;
				case 2: //Lizard
				{
					if(g.status == 1) // Scissors
						fly_away = true;
					if(g.status == 0) //Rock
						fly_away = true;
				} break;
				case 3: //Paper
				{
					if(g.status == 2) //Lizard
						fly_away = true;
					if(g.status == 1) //Scissors
						fly_away = true;
				} break;
				case 4: //Spock
				{
					if(g.status == 2) // Lizzard
						fly_away = true;
					if(g.status == 3) // Paper
						fly_away = true;
				}break;
				}

				if(fly_away)
				{
					Debug.Log ("Away");
					//Collider current_collider = col.gameObject.GetComponent<Collider>();
					//current_collider.enabled = false;
				}

				
				
			}
		}
		
		
		
		
		
		
	}	

	void OnTriggerEnter(Collider col)
	{
		
		

		if(col.gameObject.name == "Pill")
		{

			GameObject obj = col.gameObject;
			Pill_FlyPath path_script = obj.GetComponent<Pill_FlyPath>();
			if(this.gameObject == path_script.target)
			{


				
				float r = Random.value;
				
				int s = 0;

				string name = " ";
				if((r >= 0.0f) && (r < (1.0f/5.0f)))
				{
					name = "hand_rock";
					s = 0;
				}
				if((r >= (1.0f/5.0f)) && (r < (2.0f/5.0f)))
				{
					name = "hand_scissors";
					s = 1;
				}
				if((r >= (2.0f/5.0f)) && (r < (3.0f/5.0f)))
				{
					name = "hand_lizard";
					s = 2;
				}
				if((r >= (3.0f/5.0f)) && (r < (4.0f/5.0f)))
				{
					name = "hand_paper";
					s = 3;
				}
				
				if(r >= (5.0f/6.0f))
				{
					name = "hand_spock";
					s = 4;
				}
				
				this.status = s;

				GameObject.Instantiate(Resources.Load (name));
				GameObject new_obj = GameObject.Find ((name + "(Clone)"));
				//new_obj.transform.position = pos;
				//new_obj.transform.rotation = rot;

				GameObject player_mesh = this.gameObject.transform.FindChild ("Hand").gameObject;
				Destroy (player_mesh);

				new_obj.name = "Hand";
				

				new_obj.transform.parent = this.gameObject.transform;
				new_obj.transform.localScale = new Vector3(0.25f,0.25f,0.25f);
				new_obj.transform.localEulerAngles = new Vector3(-90,0,0);
				new_obj.transform.localPosition = Vector3.zero;

				Destroy (obj);
				

			}
			
		

			else
			{
				Pill_FlyPath fly_path = col.gameObject.GetComponent<Pill_FlyPath>();
				
				GameObject p1 = GameObject.Find ("Player1");
				Player1_Collisions c = p1.GetComponent<Player1_Collisions>();
				if((fly_path.target != this.gameObject) && (!c.fly_away))
				{
					GameObject obj2 = GameObject.Find ("Player1");
					List<Vector3>points = new List<Vector3>();
					points.Add (this.gameObject.transform.position);
					GameObject o = GameObject.Find ("Main Camera");
					Vector3 cam_vec = (o.transform.position - obj2.transform.position).normalized;
					//points.Add (this.gameObject.transform.position + flying_path_distance * cam_vec);
					points.Add (o.transform.position);
					//points.Add (new Vector3(500.0f,0.0f,0.0f));
					//points.Add (this.gameObject.transform.position + flying_path_distance * cam_vec);
					fly_path.setTarget (obj2, points);
				}
				if(fly_path.target == this.gameObject)
				{
					Destroy (col.gameObject);
				}
			}

		}


	}



}