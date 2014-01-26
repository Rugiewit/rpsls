using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour
{

	public GameObject worldSphere;
	public Definitions def;
	public GameObject camera;

	private Movement movement = new Movement ();

	// Use this for initialization
	public void Start ()
	{

	}

	public void SetMovement (Movement movement)
	{
			this.movement = movement;
	}


	// Update is called once per frame
	public void Update ()
	{
		GameObject god = GameObject.Find ("GameDirector");	
		Pause pause = god.GetComponent<Pause> ();
		if (pause.pause) {
				return;
		}


		//Debug.Log(this.rigidbody.velocity.sqrMagnitude);
		if (this.rigidbody.velocity.sqrMagnitude > 0.5f || !(movement.up || movement.down || movement.right || movement.left)) {
			return;
		}

		Vector3 gravity = worldSphere.transform.position - this.transform.position;
		Vector3 guideVector = gravity;
		guideVector.y += 1;

		Vector3 myRight = Vector3.Cross (guideVector, gravity);
		Vector3 myUp = Vector3.Cross (gravity, myRight);
		myRight.Normalize();
		myUp.Normalize();

		 
		gravity.Normalize ();
		Vector3 playerForce = Vector3.zero;

		if (movement.up) {
			playerForce += myUp;
		}
		if (movement.down) {
			playerForce += -myUp;
		}
		if (movement.left) {
			playerForce += -myRight;
		}
		if (movement.right) {
			playerForce += myRight;
		}

		playerForce.Normalize ();

		playerForce *= def.getPlayerForce ();
		this.rigidbody.AddForce (playerForce);


		this.transform.LookAt (this.rigidbody.velocity + gravity + this.transform.position, -gravity);

	}
}
