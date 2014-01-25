using UnityEngine;
using System.Collections;

public class KeyBoardPlayerOne : MonoBehaviour {

	// Use this for initialization
	public void Start ()
	{
	
	}
	
	// Update is called once per frame
	public void Update () 
	{
		Movement movement = new Movement(
			Input.GetKey("w"),
			Input.GetKey("s"),
			Input.GetKey("a"),
			Input.GetKey("d"));
		MovePlayer moveplayer = this.GetComponent<MovePlayer>();
		if(moveplayer != null)
		{
			moveplayer.SetMovement(movement);
		}
	}
}
