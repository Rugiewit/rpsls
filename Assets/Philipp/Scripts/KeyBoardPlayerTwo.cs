using UnityEngine;
using System.Collections;

public class KeyBoardPlayerTwo : MonoBehaviour {
	
	// Use this for initialization
	public void Start ()
	{
		
	}
	
	// Update is called once per frame
	public void Update () 
	{
		Movement movement = new Movement(
			Input.GetKey(KeyCode.UpArrow) || Input.GetAxis("TwoUp") == -1,
			Input.GetKey(KeyCode.DownArrow) || Input.GetAxis("TwoUp") == 1,
			Input.GetKey(KeyCode.LeftArrow) || Input.GetAxis("TwoLeft") == -1,
			Input.GetKey(KeyCode.RightArrow) || Input.GetAxis("TwoLeft") == 1 );
		MovePlayer moveplayer = this.GetComponent<MovePlayer>();
		if(moveplayer != null)
		{
			moveplayer.SetMovement(movement);
		}
	}
}
