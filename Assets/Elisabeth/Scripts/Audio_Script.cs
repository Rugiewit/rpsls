using UnityEngine;
using System.Collections;



public class Audio_Script : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;
	public float threshold1;
	public float threshold2;
	private bool isPlayingFirst;
	private bool isPlayingSecond;
	public AudioSource source1;
	public AudioSource source2;
	// Use this for initialization

	void Start () {
		threshold1 = 0.5f;
		threshold2 = 0.1f;
	
	}
	
	// Update is called once per frame
	void Update () {

		float diff = (player1.transform.position - player2.transform.position).magnitude;

		if(diff > threshold1)
		{
			if(isPlayingFirst)
			{
				source1.volume = 0;
				isPlayingFirst = false;
			}

		}
		if(diff < threshold1)
		{
			source1.volume = diff * 1;
			if(!isPlayingFirst)
				isPlayingFirst = true;
			


		}

	
	}
}
