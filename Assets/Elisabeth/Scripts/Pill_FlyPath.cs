using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pill_FlyPath : MonoBehaviour {


	private List<Vector3> curve_points;
	public GameObject target;
	private bool followed = false;
	private int point_index = 0;
	private float velocity = 0.1f;
	private float threshold = 0.1f;
	// Use this for initialization
	void Start () {

		Transform particles = this.transform.GetChild (0);
		particles.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if(followed)
		{

			if(point_index == curve_points.Count - 1)
			{
				Vector3 vec = (target.transform.position - this.transform.position).normalized;
				this.transform.position = this.transform.position + Time.deltaTime * vec * velocity;
				Transform particles = this.transform.GetChild (0);
				particles.LookAt (target.transform.position);

			}
			else
			{
				Vector3 vec = (curve_points[point_index] - curve_points[point_index - 1]).normalized;
				this.transform.position = this.transform.position + Time.deltaTime * vec * velocity;
			
				Transform particles = this.transform.GetChild (0);
				particles.LookAt (curve_points[point_index - 1]);

				if((this.transform.position - curve_points[point_index]).magnitude < threshold)
				{
					if(point_index < (curve_points.Count))
					{
					   point_index++;
						Debug.Log (point_index);
					}

				}
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
		Transform particles = this.transform.GetChild (0);
		particles.gameObject.SetActive (true);
	
		MeshRenderer m = this.GetComponent<MeshRenderer>();
		m.enabled = false;


		Vector3 vec = (curve_points[point_index] - this.gameObject.transform.position).normalized;
		Vector3 target_pos =  this.gameObject.transform.position -  20.0f * vec;
		particles.transform.LookAt(target_pos);



	}



}
