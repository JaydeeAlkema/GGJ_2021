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
	[SerializeField] private bool Puzzlecomplete = false;
	[Space]
	[SerializeField] private List<ParticleSystem> laserParticles = new List<ParticleSystem>();

	public bool Puzzlecomplete1 { get => Puzzlecomplete; set => Puzzlecomplete = value; }

	private void Start()
	{
		PuzzleCompleteEvent(Puzzlecomplete);
	}

	public void CheckCircleStates()
	{
		circleOuterCorrectlyRotated = circleOuter.State == circleOuterTargetState;
		circleMiddleCorrectlyRotated = circleMiddle.State == circleMiddleTargetState;
		circleInnerCorrectlyRotated = circleInner.State == circleInnerTargetState;
		if(circleOuterCorrectlyRotated && circleMiddleCorrectlyRotated && circleInnerCorrectlyRotated && !Puzzlecomplete)
		{
			Puzzlecomplete = true;
			PuzzleCompleteEvent(Puzzlecomplete);
		}
	}

	private void PuzzleCompleteEvent(bool isComplete)
	{
		for(int i = 0; i < laserParticles.Count; i++)
		{
			if(isComplete)
				laserParticles[i].Play();
			else
				laserParticles[i].Stop();

		}
	}
}