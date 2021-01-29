using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_Ring : MonoBehaviour
{
	[SerializeField] private int ringState = 0;
	[SerializeField] private Animator anim;

	private void Start()
	{
		anim = GetComponent<Animator>();
	}

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			ChangeToNextState();
		}
	}

	public void ChangeToNextState()
	{
		ringState++;
		if(ringState > 3) ringState = 0;
		anim.SetInteger("State", ringState);
	}
}
