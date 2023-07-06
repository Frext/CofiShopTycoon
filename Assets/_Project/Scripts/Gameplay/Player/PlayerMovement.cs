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
		[SerializeField] [Range(0, 1)] private float continuousJumpInterval;
		[Space]
		
		[Tooltip("The speed multiplier when the player is not grounded.")]
		[SerializeField] [Range(0, 10)] private float airMultiplier;
		
		[Tooltip("How close the player should be to ground to jump to avoid jumping in mid-air.")]
		[SerializeField] [Range(0, 10)] private float groundDistance;

		[SerializeField] private LayerMask groundLayerMask;

		
		Rigidbody playerRb;
	
		Vector2 inputVector;
		
		bool isJumpPressed;
		float jumpDelta;

		
		void Awake()
		{
			playerRb = GetComponent<Rigidbody>();
		}

		void Start()
		{
			playerRb.freezeRotation = true;
		}
		
		void FixedUpdate()
		{
			Walk();
			
			Jump();

			FallFaster();
		}

		private void Walk()
		{
			Vector3 inputDir = (transform.forward * inputVector.y + transform.right * inputVector.x).normalized;
			
			// If not moving backwards, rotate to the input.
			if (inputVector.y >= 0f)
			{
				transform.forward = Vector3.Slerp(transform.forward, inputDir, rotateSpeed * Time.fixedDeltaTime);
			}
			
			
			Vector3 movementForce = inputDir * walkSpeed;

			if (IsPlayerInAir())
				movementForce *= airMultiplier;

			playerRb.AddForce(movementForce, ForceMode.Force);
		}
		
		private bool IsPlayerInAir()
		{
			return !Physics.Raycast(transform.position, Vector3.down, groundDistance, groundLayerMask);
		}
		
		private void Jump()
		{
			// When mid air, don't increase the jumpDelta.
			if (IsPlayerInAir())
			{
				return;
			}
			
			jumpDelta += Time.deltaTime;
			
			// If trying to jump again in the state of jumping. Don't let that because it jumps much higher.
			if (jumpDelta <= continuousJumpInterval)
			{
				return;
			}
			
			if (isJumpPressed)
			{
				playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
				
				jumpDelta = 0.0f;
			}
		}
		
		private void FallFaster()
		{
			if (playerRb.velocity.y < -0.01f)
			{
				playerRb.velocity += Vector3.up * (Physics.gravity.y * Time.fixedDeltaTime);
			}
		}

		#region Player Input Actions Methods

		public void OnMovement(InputAction.CallbackContext context)
		{
			inputVector = context.ReadValue<Vector2>();
		}
		
		public void OnJump(InputAction.CallbackContext context)
		{
			if (context.started)
			{
				isJumpPressed = true;
			}
			else if (context.canceled)
			{
				isJumpPressed = false;
			}
		}

		#endregion
	}
}