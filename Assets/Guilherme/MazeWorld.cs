using UnityEngine;
using System.Collections;

public class MazeWorld : MonoBehaviour {
	float angle;

	// Use this for initialization
	void Start () 
	{
		SpawnBlocks(0);
		SpawnBlocks(90);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void SpawnBlocks(float rotationValue)
	{
		Vector3 centralPos = transform.position;
		const float pi2 = 2 * Mathf.PI;
		const float blockWidth = 0.025f;

		GameObject holder = new GameObject();

		for (float iter = -0.5f + blockWidth; iter < 0.5f - blockWidth; iter += blockWidth * 3)
		{
			float radius = Mathf.Sqrt(0.5f*0.5f - iter * iter);
			float perimeter = pi2 * radius;
			float ratio = perimeter / blockWidth;
			float increment = blockWidth / radius ;

			for(float cur = 0; cur < pi2; cur += increment)
			{
				GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

				Vector3 targetPos = Vector3.zero;

				targetPos.x = Mathf.Cos(cur) * radius;
				targetPos.z = Mathf.Sin(cur) * radius;
				targetPos.y = iter;

				cube.transform.rotation = Quaternion.LookRotation(targetPos);
				cube.transform.position = targetPos;
				cube.transform.localScale = new Vector3(0.025F, 0.025F, 0.025F);
				cube.transform.parent = holder.transform;

			}
		}

		holder.transform.RotateAround(centralPos, new Vector3(1, 0, 0), rotationValue);
	}
}
