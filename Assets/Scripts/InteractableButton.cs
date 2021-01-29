using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableButton : MonoBehaviour, IInteractable
{
    [SerializeField] private UnityEvent uEvent;


    public void Interact()
    {
        uEvent.Invoke();
    }

    public void DebugMessage(string msg)
    {
        Debug.Log(msg);
    }
}
