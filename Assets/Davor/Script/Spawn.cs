using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour
{

		public float spawnX = 0;
		public float spawnY = 0;
		public float spawnZ = 0;

		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		public void Respawn ()
		{
				//animate before if needed
				//transform.position = new Vector3 (spawnX, spawnY, spawnZ);
		}
}
