using UnityEngine;
using System.Collections;

public class GUIChangeling : MonoBehaviour
{
		public float scale = 0.2f;
		
		private string birdy = "hand_Fyou";
		private string rock = "hand_rock";
		private string paper = "hand_paper";
		private string scissors = "hand_scissors";
		private string lizard = "hand_lizard";
		private string spock = "hand_spock";
		public Color color = Color.white;
		public Light light;
		public  bool gotThePower;
		
		private GameObject current;

		private int currentState = 3;
		private int nextState = 3;
		// Use this for initialization
		void Start ()
		{
				current = Instantiate (Resources.Load (paper), transform.position, transform.rotation) as GameObject;
				current.transform.parent = transform;
				current.transform.localScale = new Vector3 (scale, scale, scale);
				Paint ();
				PaintThePower ();
		}

		// Update is called once per frame
		void Update ()
		{
				if (nextState != currentState) {
						Change (nextState);
				}
		}
		public void setNextState (int state)
		{
				nextState = state;
		}
		private void Change (int state)
		{
				GameObject changed = current;
				
				switch (state) {
				case 0:
						current = Instantiate (Resources.Load (rock), transform.position, transform.rotation) as GameObject;
						break;
				case 1:
						current = Instantiate (Resources.Load (scissors), transform.position, transform.rotation) as GameObject;
						break;
				case 2:
						current = Instantiate (Resources.Load (lizard), transform.position, transform.rotation) as GameObject;
						break;
				case 3:
						current = Instantiate (Resources.Load (paper), transform.position, transform.rotation) as GameObject;
						break;
				case 4:
						current = Instantiate (Resources.Load (spock), transform.position, transform.rotation) as GameObject;
						break;
				case 5:
						current = Instantiate (Resources.Load (birdy), transform.position, transform.rotation) as GameObject;
						break;
				}			
			
				//current.transform.parent = changed.transform.parent;
				
				current.transform.parent = this.gameObject.transform;

				current.transform.localScale = new Vector3 (scale, scale, scale);
				current.transform.localEulerAngles = new Vector3 (0, 0, 0);
				current.transform.localPosition = Vector3.zero;


				if (changed != null) {
						Destroy (changed);
				} else {
						Debug.Log ("changed is NULL");
				}
				currentState = state;
				Paint ();
				PaintThePower ();	

		}
		public void SetThePower (bool power)
		{
				gotThePower = power;
				//apply color, shaders or whatnot
				Paint ();
				PaintThePower ();
		}
		private void Paint ()
		{
				if (current != null) {
						Renderer[] renList = current.gameObject.GetComponentsInChildren<Renderer> ();
						foreach (Renderer r in renList) {
								r.material.color = color;

						}		
				}
		}
		private void PaintThePower ()
		{
				
		}
		public void Reset ()
		{
				if (current != null) {
						
						Change (3);
				}
		}
}
