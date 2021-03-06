﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
	private static DialogueManager instance;

	[SerializeField] private GameObject dialogueBox = default;
	[SerializeField] private TextMeshProUGUI textField = default;
	[SerializeField] private float textAppearDelay = 0.1f;
	[SerializeField] private string fullText = default;
	private string currentText = "";

	public static DialogueManager Instance { get => instance; set => instance = value; }

	private void Awake()
	{
		if(instance != null && instance != this) Destroy(this.gameObject);
		else instance = this;

		AppearBox(false);
	}

	public void AppearBox(bool active)
	{
		dialogueBox.SetActive(active);
	}

	/// <summary>
	/// Set the full text of the dialogue manager.
	/// </summary>
	/// <param name="text"> What should the fulltext be. </param>
	public void SetFullText(string text)
	{
		fullText = text;
	}

	public void LetTextAppearWithDelay()
	{
		StartCoroutine(AppearText());
	}

	private IEnumerator AppearText()
	{
		for(int i = 0; i < fullText.Length + 1; i++)
		{
			currentText = fullText.Substring(0, i);
			textField.text = currentText;
			yield return new WaitForSeconds(textAppearDelay);
		}
	}
}
