﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player2_Collisions : MonoBehaviour {

	public int status = 1;
	// Use this for initialization
	private float deltaTime;
	
	private float velocity = 10.0f;
	public bool fly_away = false;
	public float fly_threshold = 20.0f;
	public float flying_path_distance = 0.0f;
	// Use this for initialization
	void Start () {
		
		
		
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
			Debug.Log ("Fly Away");
			GameObject obj = GameObject.Find ("Main Camera");
			Vector3 vec = (obj.transform.position - this.gameObject.transform.position).normalized;
			this.transform.position = this.transform.position + Time.deltaTime * vec;

			if((obj.transform.position - this.gameObject.transform.position).magnitude < fly_threshold)
			{
				this.transform.position = Vector3.zero;
			}
			
		}
		
		
	}

	void OnCollisionEnter(Collision col)
	{
		Debug.Log ("Collision");
		if(col.gameObject.name == "Pill")
		{
			Pill_FlyPath fly_path = col.gameObject.GetComponent<Pill_FlyPath>();
			GameObject p1 = GameObject.Find ("Player1");
			Player1_Collisions c = p1.GetComponent<Player1_Collisions>();
			if((fly_path.target != this.gameObject)&& (!c.fly_away))
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

		}

		if(col.gameObject.name == "Player1")
		{
			Debug.Log ("Fly Away");
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
				
				
				
			}
		}


	}
}
