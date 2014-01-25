using UnityEngine;
using System.Collections;

public class HandLookDirection : MonoBehaviour {

	public GameObject world;
	// Use this for initialization
	public void Start ()
	{
	
	}
	
	// Update is called once per frame
	public void Update () 
	{
		this.transform.LookAt(this.world.transform);
	}
}
