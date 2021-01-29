using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_Rotato : MonoBehaviour
{
	[SerializeField] private Puzzle_Ring circleOuter;
	[SerializeField] private Puzzle_Ring circleMiddle;
	[SerializeField] private Puzzle_Ring circleInner;
	[Space]
	[SerializeField] private float circleOuterTargetRotation;
	[SerializeField] private float circleMiddleTargetRotation;
	[SerializeField] private float circleInnerTargetRotation;
	[Space]
	[SerializeField] private bool circleOuterCorrectlyRotated = false;
	[SerializeField] private bool circleMiddleCorrectlyRotated = false;
	[SerializeField] private bool circleInnerCorrectlyRotated = false;

	private void FixedUpdate()
	{
		if(circleOuter.transform.rotation.x >= circleOuterTargetRotation + 1f && circleOuter.transform.rotation.x <= circleOuterTargetRotation - 1f)
		{
			circleOuterCorrectlyRotated = true;
		}
	}
}