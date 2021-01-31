using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CameraBehaviour : MonoBehaviour
{
	[SerializeField] private string mouseXInputName; //Input name for inputmanager on X
	[SerializeField] private string mouseYInputName; //Input name for inputmanager on Y
	[SerializeField] private float mouseSensitivity; //The sensitivity of the mouse

	[SerializeField] private Image reticle; //Reticle in the center of the screen (little dot)
	[SerializeField] private TextMeshProUGUI grabText; //The text to display under the reticle when looking at an interactable

	[SerializeField] private string interactButtonName; //Input name for inputmanager to interact

	[SerializeField] private float interactDistance; //The distance the player can interact with interactables

	[SerializeField] private Transform playerBody; //The transform of the player for movement

	[SerializeField] private LayerMask interactionMask; //The mask to check with things that are interactable

	private float xAxisClamp; //Tracker of the clamping of the camera

	private void Awake()
	{
		LockCursor();
		xAxisClamp = 0.0f;
	}


	private void LockCursor()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	private void Update()
	{
		CameraRotation();
		InteractInput();
	}

	private void CameraRotation()
	{
		float mouseX = Input.GetAxis(mouseXInputName) * mouseSensitivity;
		float mouseY = Input.GetAxis(mouseYInputName) * mouseSensitivity;

		xAxisClamp += mouseY;

		if(xAxisClamp > 90.0f)
		{
			xAxisClamp = 90.0f;
			mouseY = 0.0f;
			ClampXAxisRotationToValue(270.0f);
		}
		else if(xAxisClamp < -90.0f)
		{
			xAxisClamp = -90.0f;
			mouseY = 0.0f;
			ClampXAxisRotationToValue(90.0f);
		}

		transform.Rotate(Vector3.left * mouseY);
		playerBody.Rotate(Vector3.up * mouseX);
	}

	private void ClampXAxisRotationToValue(float value)
	{
		Vector3 eulerRotation = transform.eulerAngles;
		eulerRotation.x = value;
		transform.eulerAngles = eulerRotation;
	}

	private void InteractInput()
	{

		RaycastHit hit;
		Ray ray = new Ray(transform.position, transform.forward);


		Debug.DrawRay(transform.position, transform.forward, Color.blue);
		if(Physics.Raycast(ray, out hit, interactDistance, interactionMask))
		{
			reticle.color = Color.white;
			if(Input.GetButtonDown(interactButtonName))
			{
				hit.transform.GetComponent<IInteractable>()?.Interact();
				hit.transform.GetComponent<IPuzzleRing>()?.Interact();
			}
		}
		else
		{
			reticle.color = Color.black;
		}
	}
}