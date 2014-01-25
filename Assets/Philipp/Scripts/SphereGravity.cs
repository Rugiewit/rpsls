using UnityEngine;
using System.Collections;

public class SphereGravity : MonoBehaviour {

	public GameObject worldSphere;
	public Definitions def;

	// Use this for initialization
	public void Start () 
	{
	
	}
	
	// Update is called once per frame
	public void Update ()
	{
		bool state = false;
		if(this.gameObject.name == "Player1")
		{
			Player_Collisions status = this.gameObject.GetComponent<Player_Collisions>();
			state = status.fly_away;
		}

		if(this.gameObject.name == "Player2")
		{
			Player_Collisions status = this.gameObject.GetComponent<Player_Collisions>();
			state = status.fly_away;
		}
		if(!state)
		{
			Vector3 gravity = worldSphere.transform.position - this.transform.position; 
			gravity.Normalize();
			gravity *= 1;
			this.rigidbody.AddForce(gravity);
		}
	}
}
