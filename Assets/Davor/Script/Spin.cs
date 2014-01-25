using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour
{
		public float rotSpeedX = 0;
		public float rotSpeedY = 0;
		public float rotSpeedZ = 0;
		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
				transform.Rotate (rotSpeedX * Time.deltaTime, rotSpeedY * Time.deltaTime, rotSpeedZ * Time.deltaTime);
		}
}
