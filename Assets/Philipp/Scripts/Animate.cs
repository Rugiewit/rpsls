using UnityEngine;
using System.Collections;

public class Animate : MonoBehaviour {

	// Use this for initialization
	public void Start () 
	{
		this.animation.wrapMode = WrapMode.Loop;
		this.animation["walk"].speed = 5f;
		this.animation.Play("walk");
	}
}
