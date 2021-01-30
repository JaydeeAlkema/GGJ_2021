using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FlipButton : MonoBehaviour, IInteractable
{
    private Animator animator; //The animator to flip the button
    [SerializeField] private bool flipped = false;
    [SerializeField] private UnityEvent interactEvent;

    private void Start()
    {
        animator = GetComponent<Animator>(); 
        Flip();
    }
    public void Interact()
    {
        Flip();
        interactEvent.Invoke();
    }

    public void Flip()
    {
        Debug.Log("Flip!");
        flipped = !flipped;
        animator.SetBool("flipped", flipped);
    }

    
}
