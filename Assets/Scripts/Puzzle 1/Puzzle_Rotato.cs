using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_Rotato : MonoBehaviour
{
	[SerializeField] private Puzzle_Ring circleOuter;
	[SerializeField] private Puzzle_Ring circleMiddle;
	[SerializeField] private Puzzle_Ring circleInner;
	[Space]
	[SerializeField] private int circleOuterTargetState;
	[SerializeField] private int circleMiddleTargetState;
	[SerializeField] private int circleInnerTargetState;
	[Space]
	[SerializeField] private bool circleOuterCorrectlyRotated = false;
	[SerializeField] private bool circleMiddleCorrectlyRotated = false;
	[SerializeField] private bool circleInnerCorrectlyRotated = false;

	private void FixedUpdate()
	{
		circleOuterCorrectlyRotated = circleOuter.State == circleOuterTargetState;
		circleMiddleCorrectlyRotated = circleMiddle.State == circleMiddleTargetState;
		circleInnerCorrectlyRotated = circleInner.State == circleInnerTargetState;
	}
}