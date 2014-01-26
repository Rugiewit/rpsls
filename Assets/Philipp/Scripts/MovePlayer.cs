using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour
{

		public GameObject worldSphere;
		public Definitions def;

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
				if (this.rigidbody.velocity.sqrMagnitude > 0.5f) {
						return;
				}

				Vector3 gravity = worldSphere.transform.position - this.transform.position; 
				gravity.Normalize ();
				Vector3 playerForce = Vector3.zero;

				if (movement.up) {
						Vector3 red = new Vector3 (0, gravity.y, gravity.z);
						red.Normalize ();
						Vector3 dir = Vector3.Cross (Vector3.left, red);
						playerForce += dir;
				}
				if (movement.down) {
						Vector3 red = new Vector3 (0, gravity.y, gravity.z);
						red.Normalize ();
						Vector3 dir = Vector3.Cross (Vector3.right, red);
						playerForce += dir;
				}
				if (movement.left) {
						Vector3 red = new Vector3 (gravity.x, 0, gravity.z);
						red.Normalize ();
						Vector3 dir = Vector3.Cross (Vector3.down, red);
						playerForce += dir;
				}
				if (movement.right) {
						Vector3 red = new Vector3 (gravity.x, 0, gravity.z);
						red.Normalize ();
						Vector3 dir = Vector3.Cross (Vector3.up, red);
						playerForce += dir;
				}
				playerForce.Normalize ();

				playerForce *= def.getPlayerForce ();
				this.rigidbody.AddForce (playerForce);
	

				this.transform.LookAt (this.rigidbody.velocity + gravity + this.transform.position, -gravity);

		}
}
