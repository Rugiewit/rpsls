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
	public AudioSource source3;
	public AudioSource source4;

	public float loud = 0.8f;
	// Use this for initialization

	void Start () {
		threshold1 = 0.5f;
		threshold2 = 0.1f;

		source1.volume = loud;
	
	}
	
	// Update is called once per frame
	void Update () {

		float diff = (player1.transform.position - player2.transform.position).magnitude;

		if(diff > threshold1)
		{
			if(isPlayingFirst)
			{
				source2.volume = 0;
				source3.volume = 0;
				isPlayingFirst = false;
				isPlayingSecond = false;
			}

		}
		if(diff < threshold1)
		{
			//source2.volume = diff * 1;
			source2.volume = loud * (1 - (diff / threshold1));

			if(!isPlayingFirst)
				isPlayingFirst = true;
			if(diff > threshold2)
			{
				isPlayingSecond = false;
				source3.volume = 0;
			}
			


		}

		if(diff < threshold2)
		{
			source3.volume = loud * (1 - ((diff) / (threshold2)));
			if(!isPlayingSecond)
				isPlayingSecond = true;
		}

	
	}
}
