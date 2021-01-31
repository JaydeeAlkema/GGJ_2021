using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCompleteCheck : MonoBehaviour
{
	[SerializeField] private Puzzle_Rotato puzzle_Rotato;
	[SerializeField] private DiskFlipPuzzle diskFlipPuzzle;
	[Space]
	[SerializeField] private List<ParticleSystem> laserParticles = new List<ParticleSystem>();
	[SerializeField] private bool allPuzzlesComplete = false;

	private void Start()
	{
		PuzzleCompleteEvent(false);
	}

	private void FixedUpdate()
	{
		if(diskFlipPuzzle.FlipPuzzleDone1 && puzzle_Rotato.Puzzlecomplete1 && !allPuzzlesComplete)
		{
			allPuzzlesComplete = true;
			PuzzleCompleteEvent(true);
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
