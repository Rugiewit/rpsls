using UnityEngine;
using System.Collections;

public class GUIChangeling : MonoBehaviour
{
		public float scale = 0.2f;

		public GameObject[] hands; 
		public Material mat;


		public Color color = Color.white;
		public Light light;
		public  bool gotThePower;
		
		private GameObject current;



		private int currentState = 3;
		private int nextState = 3;
		// Use this for initialization
		void Start ()
		{
		current = Instantiate (hands[0], transform.position, transform.rotation) as GameObject;
				current.transform.parent = transform;
				current.transform.localScale = new Vector3 (scale, scale, scale);
				SetTexture(current);
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
						current = Instantiate (hands[0], transform.position, transform.rotation) as GameObject;
						break;
				case 1:
						current = Instantiate (hands[1], transform.position, transform.rotation) as GameObject;
						break;
				case 2:
						current = Instantiate (hands[2], transform.position, transform.rotation) as GameObject;
						break;
				case 3:
						current = Instantiate (hands[3], transform.position, transform.rotation) as GameObject;
						break;
				case 4:
						current = Instantiate (hands[4], transform.position, transform.rotation) as GameObject;
						break;
				case 5:
						current = Instantiate (hands[5], transform.position, transform.rotation) as GameObject;
						break;
				}			
				SetTexture(current);
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
						//SetLayerRecursively (current.gameObject.transform.parent.gameObject, 8);
				}
				
		}
		void SetLayerRecursively (GameObject obj, int newLayer)
		{
				if (null == obj) {
						return;
				}
				foreach (Transform child in obj.transform) {
						if (null == child) {
								continue;
						}
						SetLayerRecursively (child.gameObject, newLayer);
				}
		} 
		private void PaintThePower ()
		{
				if (gotThePower) {
						current.transform.localScale = new Vector3 (1.3f * scale, 1.3f * scale, 1.3f * scale);
				} else {
						current.transform.localScale = new Vector3 (scale, scale, scale);

				}
		}
		public void Reset ()
		{
				if (current != null) {
						
						Change (3);
				}
		}

		public void SetTexture (GameObject new_obj)
		{
			foreach (SkinnedMeshRenderer smr in new_obj.GetComponentsInChildren<SkinnedMeshRenderer>()) {
				smr.material = mat; 
			}	
		}
}
