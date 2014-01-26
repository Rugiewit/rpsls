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
			Input.GetKey("w") || Input.GetAxis("OneUp") == -1,
			Input.GetKey("s") || Input.GetAxis("OneUp") == 1,
			Input.GetKey("a") || Input.GetAxis("OneLeft") == -1,
			Input.GetKey("d") || Input.GetAxis("OneLeft") == 1);
		MovePlayer moveplayer = this.GetComponent<MovePlayer>();
		if(moveplayer != null)
		{
			moveplayer.SetMovement(movement);
		}
	}
}
