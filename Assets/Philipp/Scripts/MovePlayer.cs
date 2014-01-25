using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour {

	public GameObject worldSphere;
	public Definitions def;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//Debug.Log(this.rigidbody.velocity.sqrMagnitude);
		if(this.rigidbody.velocity.sqrMagnitude > 0.5f)
		{
			return;
		}

		Vector3 gravity = worldSphere.transform.position - this.transform.position; 
		gravity.Normalize();
		Vector3 playerForce = Vector3.zero;

		if(Input.GetKey("w"))
		{
			Vector3 red = new Vector3(0,gravity.y,gravity.z);
			red.Normalize();
			Vector3 dir = Vector3.Cross(Vector3.left,red);
			playerForce += dir;
			Debug.Log(playerForce);
		}
		if(Input.GetKey("s"))
		{
			Vector3 red = new Vector3(0,gravity.y,gravity.z);
			red.Normalize();
			Vector3 dir = Vector3.Cross(Vector3.right,red);
			playerForce += dir;
		}
		if(Input.GetKey("a"))
		{
			Vector3 red = new Vector3(gravity.x,0,gravity.z);
			red.Normalize();
			Vector3 dir = Vector3.Cross(Vector3.down,red);
			playerForce += dir;
		}
		if(Input.GetKey("d"))
		{
			Vector3 red = new Vector3(gravity.x,0,gravity.z);
			red.Normalize();
			Vector3 dir = Vector3.Cross(Vector3.up,red);
			playerForce += dir;
		}
		playerForce.Normalize();

		playerForce *= def.getPlayerForce();
		this.rigidbody.AddForce(playerForce);
	

		this.transform.LookAt(this.rigidbody.velocity+gravity+this.transform.position, gravity);

	}
}
