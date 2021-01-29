using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableButton : MonoBehaviour, IInteractable
{
    [SerializeField] private UnityEvent uEvent;
    [SerializeField] private string flavorText;

    public string FlavorText { get => flavorText; set => flavorText = value; }

    public void Interact()
    {
        uEvent.Invoke();
    }

    public void DebugMessage(string msg)
    {
        Debug.Log(msg);
    }
}
