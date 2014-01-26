using UnityEngine;
using System.Collections;

public class SphereGravity : MonoBehaviour {

	public GameObject worldSphere;

	// Use this for initialization
	public void Start () 
	{
	
	}

	public void SetWorld(GameObject worldSphere)
	{
		this.worldSphere = worldSphere;
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
			Vector3 center = Vector3.zero;
			if(worldSphere != null)
			{
				center = worldSphere.transform.position;
			}

			Vector3 gravity = center - this.transform.position; 
			gravity.Normalize();
			gravity *= 1;
			this.rigidbody.AddForce(gravity);
		}
	}
}
