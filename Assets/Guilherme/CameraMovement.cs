using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	public GameObject player1;
	public GameObject player2;
	public GameObject world;
	public float distance = 5;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 midpoint = (player2.transform.position + player1.transform.position) / 2;

		Vector3 dir =  midpoint - world.transform.position;

		dir.Normalize();

		transform.position = dir * distance;
		transform.LookAt(world.transform.position);
	}
}
