using UnityEngine;
using System.Collections;

public class GUIChangeling : MonoBehaviour
{
		public float scale = 0.5f;
		public GameObject birdy = null;
		public GameObject rock = null;
		public GameObject paper = null;
		public GameObject scissors = null;
		public GameObject lizard = null;
		public GameObject spock = null;
		public  bool gotThePower;
		
		private GameObject current;
		// Use this for initialization
		void Start ()
		{
				current = Instantiate (birdy, transform.position, transform.rotation) as GameObject;
				SetUpCurrent ();
				PaintThePower ();
		}

		// Update is called once per frame
		void Update ()
		{
			
		}
		private void SetUpCurrent ()
		{
				current.transform.parent = transform;
				current.transform.localScale = new Vector3 (scale, scale, scale);
		}
		public void Change (int state)
		{
				GameObject changed = null;
				Destroy (current);
				switch (state) {
				case 0:
						changed = Instantiate (rock, transform.position, transform.rotation) as GameObject;
						break;
				case 1:
						changed = Instantiate (scissors, transform.position, transform.rotation) as GameObject;
						break;
				case 2:
						changed = Instantiate (lizard, transform.position, transform.rotation) as GameObject;
						break;
				case 3:
						changed = Instantiate (paper, transform.position, transform.rotation) as GameObject;
						break;
				case 4:
						changed = Instantiate (spock, transform.position, transform.rotation) as GameObject;
						break;
				case 5:
						changed = Instantiate (birdy, transform.position, transform.rotation) as GameObject;
						break;
				}			
				current = changed;
				SetUpCurrent ();
		}
		public void SwitchThePower ()
		{
				gotThePower = !gotThePower;
				//apply color, shaders or whatnot
				PaintThePower ();
		}
		private void PaintThePower ()
		{
				current.renderer.material.color = gotThePower ? new Color (0.9f, 0.1f, 0.7f) : new Color (0.1f, 0.9f, 0.7f); //C#

		}
		public void Reset ()
		{
				if (current != null) {
						current.transform.rotation = Quaternion.identity;
						Change (3);
				}
		}
}
