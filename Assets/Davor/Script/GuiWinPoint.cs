using UnityEngine;
using System.Collections.Generic;

public class GuiWinPoint : MonoBehaviour
{

		public GameObject pill = null;
		public List<GameObject> myList ;
		public int numOfPoints = 0;
		public float span = 50;

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
						Vector3 newPos = transform.position + (new Vector3 (0, 0, i - 1) * span);
						GameObject idx_pill = Instantiate (pill, newPos, transform.rotation) as GameObject;
						myList.Add (idx_pill);
				}
		}

}
