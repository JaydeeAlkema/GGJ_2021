using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehaviour : MonoBehaviour
{
	[SerializeField] private string horizontalInputName;
	[SerializeField] private string verticalInputName;
	[SerializeField] private float movementSpeed;

	private CharacterController charController;

	[SerializeField] private AnimationCurve jumpFallOff;
	[SerializeField] private float jumpMultiplier;
	[SerializeField] private KeyCode jumpKey;
	[Space]
	[SerializeField] private AudioClip[] walkingAudioClips;
	[SerializeField] private Transform feetTransform;

	private Animator anim;
	private bool isJumping = false;
	private bool walking = false;

	private void Awake()
	{
		charController = GetComponent<CharacterController>();
		anim = GetComponent<Animator>();
	}

	private void Update()
	{
		PlayerMovement();
	}

	private void PlayerMovement()
	{
		float horizInput = Input.GetAxis(horizontalInputName) * movementSpeed;
		float vertInput = Input.GetAxis(verticalInputName) * movementSpeed;

		Vector3 forwardMovement = transform.forward * vertInput;
		Vector3 rightMovement = transform.right * horizInput;

		charController.SimpleMove(forwardMovement + rightMovement);

		JumpInput();

		if(!isJumping)
		{
			if(horizInput != 0 || vertInput != 0)
				anim.SetBool("Walking", true);
			else
				anim.SetBool("Walking", false);
		}
	}

	private void JumpInput()
	{
		if(Input.GetKeyDown(jumpKey) && !isJumping)
		{
			isJumping = true;
			StartCoroutine(JumpEvent());
		}
	}

	private IEnumerator JumpEvent()
	{
		charController.slopeLimit = 90.0f;
		float timeInAir = 0.0f;

		do
		{
			float jumpForce = jumpFallOff.Evaluate(timeInAir);
			charController.Move(Vector3.up * jumpForce * jumpMultiplier * Time.deltaTime);
			timeInAir += Time.deltaTime;
			yield return null;
		} while(!charController.isGrounded && charController.collisionFlags != CollisionFlags.Above);

		charController.slopeLimit = 45.0f;
		isJumping = false;
	}

	public void PlayWalkSound()
	{
		AudioManager.PlayAudioAtPosition(feetTransform.position, walkingAudioClips[Random.Range(0, walkingAudioClips.Length)], 0.5f, false);
	}

	public void Empty() { }
}