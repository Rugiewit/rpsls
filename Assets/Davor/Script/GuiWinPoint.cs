using UnityEngine;
using System.Collections.Generic;

public class GuiWinPoint : MonoBehaviour
{

		public List<GameObject> myList ;
		public int numOfPoints = 0;
		public float span = 50;
		public float scale = 0.1f;
		// Use this for initialization
		void Start ()
		{
				myList = new List<GameObject> ();
				Change (numOfPoints);
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
		public void Change (int points)
		{	
				foreach (GameObject go in myList) {
						Destroy (go);
				}
				myList.Clear ();
				numOfPoints = points;
				for (int i=0; i < numOfPoints; i++) {
						Vector3 newPos = transform.position + (new Vector3 (0, (i - 1) * span, 0));
						GameObject idx_pill = Instantiate (Resources.Load ("Pill"), newPos, transform.rotation) as GameObject;
						idx_pill.transform.parent = idx_pill.gameObject.transform;
						idx_pill.transform.localScale = new Vector3 (scale, scale, scale);
						
						idx_pill.transform.parent = this.gameObject.transform;
			
						idx_pill.transform.localScale = new Vector3 (scale, scale, scale);
						idx_pill.transform.localEulerAngles = new Vector3 (0, 0, 0);
						idx_pill.transform.localPosition = Vector3.zero;


						myList.Add (idx_pill);
				}
		}

}
