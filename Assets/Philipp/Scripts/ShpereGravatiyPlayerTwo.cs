using UnityEngine;
using System.Collections;

public class ShpereGravatiyPlayerTwo : MonoBehaviour {

	public GameObject worldSphere;
	public Definitions def;

	// Use this for initialization
	public void Start ()
	{
	
	}
	
	
	// Update is called once per frame
	public void Update ()
	{
		Vector3 gravity = worldSphere.transform.position - this.transform.position; 
		gravity.Normalize();
		gravity *= def.getGravityForce();
		this.rigidbody.AddForce(gravity);
		Debug.Log(gravity);
	}
}
