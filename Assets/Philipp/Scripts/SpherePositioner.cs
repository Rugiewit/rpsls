using UnityEngine;
using System.Collections;

public class SpherePositioner : MonoBehaviour {

	public GameObject worldSphere;
	public Camera activeCamera;

	private float x = 0.0f;
	private float y = 0.0f;

	private float radius;

	public void Start () 
	{
		if(worldSphere.transform.localScale.x != worldSphere.transform.localScale.y || worldSphere.transform.localScale.x != worldSphere.transform.localScale.z)
		{
			Debug.LogError("World sphere is not uniform !! ");
		}
		this.radius = worldSphere.transform.localScale.x / 2f;
	}

	public void Update ()
	{
		float sphereX = worldSphere.transform.position.x;
		float sphereY = worldSphere.transform.position.y;
		float sphereZ = worldSphere.transform.position.y;


		float dy = Mathf.Sin(this.y * Mathf.PI) * this.radius;
		float dz = - Mathf.Cos(this.y * Mathf.PI) * this.radius;

		float dx = Mathf.Sin(this.x * Mathf.PI) * dz;
		dz = Mathf.Cos(this.x * Mathf.PI) * dz; 



		this.transform.position = new Vector3(sphereX+dx, sphereY+dy, sphereZ+dz );
		this.transform.LookAt(worldSphere.transform);

		if(Input.GetKey("w"))
		{
			Debug.Log(this.x +"," +this.y +": ("+ dx + ", " + dy + ", " + dz + ")" );
			this.y += 0.01f;
		}
		if(Input.GetKey("s"))
		{
			Debug.Log(this.x +"," +this.y +": ("+ dx + ", " + dy + ", " + dz + ")" );
			this.y -= 0.01f;
		}
		if(Input.GetKey("a"))
		{
			Debug.Log(this.x +"," +this.y +": ("+ dx + ", " + dy + ", " + dz + ")" );
			this.x += 0.01f;
		}
		if(Input.GetKey("d"))
		{
			Debug.Log(this.x +"," +this.y +": ("+ dx + ", " + dy + ", " + dz + ")" );
			this.x -= 0.01f;
		}
	}
}
