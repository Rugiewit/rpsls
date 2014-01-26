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
			Input.GetKey(KeyCode.Keypad8) || Input.GetAxis("TwoUp") == -1,
			Input.GetKey(KeyCode.Keypad5) || Input.GetAxis("TwoUp") == 1,
			Input.GetKey(KeyCode.Keypad4) || Input.GetAxis("TwoLeft") == -1,
			Input.GetKey(KeyCode.Keypad6) || Input.GetAxis("TwoLeft") == 1 );
		MovePlayer moveplayer = this.GetComponent<MovePlayer>();
		if(moveplayer != null)
		{
			moveplayer.SetMovement(movement);
		}
	}
}
