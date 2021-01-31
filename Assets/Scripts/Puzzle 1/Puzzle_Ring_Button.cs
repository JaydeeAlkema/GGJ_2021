using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_Ring_Button : MonoBehaviour, IInteractable
{
	[SerializeField] private Puzzle_Rotato puzzle_Rotato;
	public void Interact()
	{
		puzzle_Rotato.CheckCircleStates();
		GetComponent<Animator>().SetTrigger("Pressed");
	}
}
