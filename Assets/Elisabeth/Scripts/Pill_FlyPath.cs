using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pill_FlyPath : MonoBehaviour {


	private List<Vector3> curve_points;
	public GameObject target;
	private bool followed = false;
	private int point_index = 0;
	public float velocity = 4.0f;
	private float threshold = 0.1f;
	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
		if(followed)
		{
			Vector3 vec = (curve_points[point_index] - curve_points[point_index - 1]).normalized;
			this.transform.position = this.transform.position + Time.deltaTime * vec;
			if((this.transform.position - curve_points[point_index]).magnitude < threshold)
			{
				if(point_index < (curve_points.Count - 1))
				   point_index++;

			}
		}
	
	}

	public void setTarget(GameObject obj, List<Vector3> points)
	{
		target = obj;
		followed = true;
		curve_points = points;
		point_index = 1;

		Debug.Log ("Particles");
		GameObject.Instantiate ( Resources.Load ("Pill_Particles") as GameObject);
		GameObject particles = GameObject.Find ("Pill_Particles(Clone)");
		particles.name = "Pill_Particles";
		particles.transform.position = this.transform.position;
		particles.transform.parent = this.gameObject.transform;


		Vector3 vec = (curve_points[point_index] - this.gameObject.transform.position).normalized;
		Vector3 target_pos =  this.gameObject.transform.position -  20.0f * vec;
		particles.transform.LookAt(target_pos);




		//this.gameObject.AddComponent<ParticleSystem>();
	}

	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject == this.target)
		{
			Debug.Log ("Destroy");
			if((col.gameObject.name == "Player1") || (col.gameObject.name == "Player2"))
			{
				GameObject obj = null;
				Vector3 pos = Vector3.zero;
				Quaternion rot = Quaternion.identity;
				if(col.gameObject.name == "Player2")
				{
					 obj = GameObject.Find ("Player2");
					 pos = obj.transform.position;
					 rot = obj.transform.rotation;
				}
				else if(col.gameObject.name == "Player1")
				{
					obj = GameObject.Find ("Player1");
					pos = obj.transform.position;
					rot = obj.transform.rotation;
				}
				
				float r = Random.value;
				
				int s = 0;
				r = 0.0f;
				string name = " ";
				if((r >= 0.0f) && (r < (1.0f/5.0f)))
				{
					name = "Rock";
					s = 0;
				}
				if((r >= (1.0f/5.0f)) && (r < (2.0f/5.0f)))
				{
					name = "Scissors";
					s = 1;
				}
				if((r >= (2.0f/5.0f)) && (r < (3.0f/5.0f)))
				{
					name = "Lizard";
					s = 2;
				}
				if((r >= (3.0f/5.0f)) && (r < (4.0f/5.0f)))
				{
					name = "Paper";
					s = 3;
				}

				if(r >= (5.0f/6.0f))
				{
					name = "Spock";
					s = 4;
				}
				
				
				GameObject.Instantiate(Resources.Load (name));
				GameObject new_obj = GameObject.Find ((name + "(Clone)"));
				new_obj.transform.position = pos;
				new_obj.transform.rotation = rot;
				new_obj.name = obj.name;
				Destroy (obj);

				if(col.gameObject.name == "Player2")
				{
					new_obj.AddComponent ("Player2_Collisions");
					Player2_Collisions g  = new_obj.GetComponent<Player2_Collisions>();
					g.status = s;
					
					Rigidbody[] rbodies = obj.GetComponents<Rigidbody>();
					
					foreach(Rigidbody ri in rbodies)
					{
						UnityEditorInternal.ComponentUtility.CopyComponent(ri);
						UnityEditorInternal.ComponentUtility.PasteComponentAsNew(new_obj);
					}
				}
				else
				{
					new_obj.AddComponent ("Player1_Collisions");
					Player1_Collisions g  = new_obj.GetComponent<Player1_Collisions>();
					g.status = s;
					
					Rigidbody[] rbodies = obj.GetComponents<Rigidbody>();
					
					foreach(Rigidbody ri in rbodies)
					{
						UnityEditorInternal.ComponentUtility.CopyComponent(ri);
						UnityEditorInternal.ComponentUtility.PasteComponentAsNew(new_obj);
					}
				}
				Destroy (obj);
				Destroy (this.gameObject);
			}
		}
	}


}
