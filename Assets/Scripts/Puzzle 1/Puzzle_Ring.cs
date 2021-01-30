using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_Ring : MonoBehaviour
{
	[SerializeField] private int state = 1;
	[SerializeField] private Animator anim;

	public int State { get => state; set => state = value; }

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
		state++;
		if(state > 4) state = 1;
		anim.SetInteger("State", state);
	}
}
