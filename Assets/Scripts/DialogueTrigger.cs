using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
	[SerializeField] private string textToDisplay = default;

	private void OnTriggerEnter(Collider other)
	{
		DialogueManager.Instance.SetFullText(textToDisplay);
		DialogueManager.Instance.LetTextAppearWithDelay();

		Destroy(this.gameObject);
	}
}
