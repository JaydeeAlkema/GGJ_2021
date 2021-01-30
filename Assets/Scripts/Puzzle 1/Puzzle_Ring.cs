using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_Ring : MonoBehaviour, IPuzzleRing
{
	[SerializeField] private int state = 0;
	[SerializeField] private Animator anim;
	[SerializeField] private AudioClip audioClip = default;

	public int State { get => state; set => state = value; }

	private void Start()
	{
		state = Random.Range(1, 4);
		anim.SetInteger("State", state);
	}

	public void ChangeToNextState()
	{
		if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
		{
			state++;
			if(state > 4) state = 1;
			anim.SetInteger("State", state);
			AudioManager.PlayAudioAtPosition(transform.position, audioClip, 0.15f, false);
		}
	}

	public void Interact()
	{
		ChangeToNextState();
	}
}
