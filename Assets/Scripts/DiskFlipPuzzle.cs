using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskFlipPuzzle : MonoBehaviour
{

	[SerializeField] private int totalAmountOfPuzzles = 3;
	[SerializeField] private int totalPuzzleCompleted = 0;

	[SerializeField] private List<FlipButton> flipButtons = new List<FlipButton>();

	[SerializeField] private int timer = 250;
	[SerializeField] private bool FlipPuzzleDone = false;

	[SerializeField] private List<ParticleSystem> laserParticles = new List<ParticleSystem>();

	public bool FlipPuzzleDone1 { get => FlipPuzzleDone; set => FlipPuzzleDone = value; }

	private void Start()
	{
		FlipPuzzleDoneEvent(false);
	}

	void Update()
	{
		if(timer > 0)
		{
			timer--;
		}
		else
		{
			timer = 250;
			SlowUpdate();
		}
	}

	void SlowUpdate()
	{
		CheckFlipPuzzle();
	}

	private void CheckFlipPuzzle()
	{
		int amount = 0;
		for(int i = 0; i < flipButtons.Count; i++)
		{
			if(!flipButtons[i].Flipped)
			{
				amount += 1;
			}
		}
		if(amount == flipButtons.Count)
		{
			if(!FlipPuzzleDone)
			{
				FlipPuzzleDoneEvent(true);
				FlipPuzzleDone = true;
			}
		}
	}
	private void FlipPuzzleDoneEvent(bool active)
	{
		for(int i = 0; i < laserParticles.Count; i++)
		{
			if(active)
				laserParticles[i].Play();
			else
				laserParticles[i].Stop();

		}
	}
}
