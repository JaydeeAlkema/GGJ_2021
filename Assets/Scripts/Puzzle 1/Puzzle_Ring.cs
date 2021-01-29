using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_Ring : MonoBehaviour
{
	int rotIndex = 1;

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			RotateOnce();
		}
	}

	public void RotateOnce()
	{
		transform.Rotate(new Vector3(90 * rotIndex, transform.rotation.y, transform.rotation.z));
		rotIndex++;
	}
}
