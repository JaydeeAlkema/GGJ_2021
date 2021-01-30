using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_Ring : MonoBehaviour
{
	[SerializeField] private int state = 0;
	[SerializeField] private Animator anim;
	[SerializeField] private KeyCode changeStateKey;

	public int State { get => state; set => state = value; }

	private void Start()
	{
		anim = GetComponent<Animator>();
	}

	private void Update()
	{
		if(Input.GetKeyDown(changeStateKey))
			if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !anim.IsInTransition(0))
				ChangeToNextState();
	}

	public void ChangeToNextState()
	{
		state++;
		if(state > 4) state = 1;
		anim.SetInteger("State", state);
	}
}
