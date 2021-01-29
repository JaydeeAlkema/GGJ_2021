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

	private void Update()
	{
		CheckRotation(circleOuter.transform.rotation.x, circleOuterTargetRotation, 1f, circleOuter);
		CheckRotation(circleMiddle.transform.rotation.x, circleMiddleTargetRotation, 1f, circleMiddle);
		CheckRotation(circleInner.transform.rotation.x, circleInnerTargetRotation, 1f, circleInner);
	}

	private void FixedUpdate()
	{
	}

	void CheckRotation(float currentRotation, float targetRotation, float offset, Puzzle_Ring puzzleRing)
	{
		if(currentRotation >= (targetRotation + offset) || currentRotation <= (targetRotation - offset))
		{
			
		}
	}
}