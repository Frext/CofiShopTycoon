using UnityEngine;
using UnityEngine.InputSystem;

namespace _Project.Scripts.Gameplay.Player
{
	[RequireComponent(typeof(Rigidbody), typeof(PlayerInput))]
	public class PlayerMovement : MonoBehaviour
	{
		[Header("Walk Properties")]
		[SerializeField] [Range(0, 20)] private float walkSpeed;
		[SerializeField] [Range(0.01f, 20)] private float rotateSpeed;

		
		[Header("Jump Properties")]
		[SerializeField] [Range(0, 20)] private float jumpForce;
		
		[Tooltip("The speed multiplier when the player is not grounded.")]
		[SerializeField] [Range(0, 10)] private float airMultiplier;
		
		[Tooltip("How close the player should be to ground to jump to avoid jumping in mid-air.")]
		[SerializeField] [Range(0, 10)] private float groundDistance;

		[SerializeField] private LayerMask groundLayerMask;

		
		Rigidbody playerRb;
		
		Vector2 inputVector;

		
		void Awake()
		{
			playerRb = GetComponent<Rigidbody>();
			playerRb.freezeRotation = true;
		}

		void FixedUpdate()
		{
			Walk();
		}

		private void Walk()
		{
			// First, rotate the player with LEFT and RIGHT inputs.
			transform.forward = Vector3.Slerp(transform.forward , transform.right * inputVector.x, rotateSpeed * Time.fixedDeltaTime);

			
			// Then, add the player a force in the direction of UP and DOWN inputs.
			Vector3 movementForce = transform.forward * (inputVector.y * walkSpeed);

			if (!IsPlayerGrounded())
				movementForce *= airMultiplier;

			playerRb.AddForce(movementForce, ForceMode.Force);
		}
		
		private bool IsPlayerGrounded()
		{
			return Physics.Raycast(transform.position, Vector3.down, groundDistance, groundLayerMask);
		}

		#region Player Input Actions Methods

		public void OnMovement(InputAction.CallbackContext context)
		{
			inputVector = context.ReadValue<Vector2>();
		}

		public void OnJump(InputAction.CallbackContext context)
		{
			if (context.performed && IsPlayerGrounded())
			{
				playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
			}
		}

		#endregion
	}
}
