using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FlipButton : MonoBehaviour, IInteractable
{
	[SerializeField] private Animator animator; //The animator to flip the button
	[SerializeField] private bool flipped = false;
	[SerializeField] private UnityEvent interactEvent;

	public bool Flipped { get => flipped; set => flipped = value; }

	private void Start()
	{
		animator = GetComponentInParent<Animator>();
		Flip();
	}
	public void Interact()
	{
		if(animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !animator.IsInTransition(0))
		{
			Flip();
			interactEvent.Invoke();
		}
	}

	public void Flip()
	{

		Debug.Log("Flip!");
		flipped = !flipped;
		animator.SetBool("flipped", flipped);

	}
}


