using UnityEngine;
using System.Collections;

public class Movement
{
	public bool up;
	public bool down;
	public bool left;
	public bool right;

	public Movement(bool up, bool down, bool left, bool right)
	{
		this.up = up;
		this.down = down;
		this.left = left;
		this.right = right;
	}

	public Movement()
	{
		this.up = false;
		this.down = false;
		this.left = false;
		this.right = false;
	}
}
