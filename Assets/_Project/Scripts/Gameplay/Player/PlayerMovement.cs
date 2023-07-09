using UnityEngine;
using UnityEngine.InputSystem;
using static _Project.Scripts.HelperMethodsUtil;

namespace _Project.Scripts.Gameplay.Player
{
	[RequireComponent(typeof(Rigidbody), typeof(Collider), typeof(PlayerInput))]
	public class PlayerMovement : MonoBehaviour
	{
		[Header("Walk Properties")]
		[SerializeField] [Range(0, 20)] private float walkSpeed;
		[SerializeField] [Range(0.01f, 20)] private float rotateSpeed;

		[Header("Jump Properties")]
		[SerializeField] [Range(0, 20)] private float jumpForce;

		[Tooltip("The speed multiplier when the player is not grounded.")]
		[SerializeField] [Range(0, 10)] private float airMultiplier;

		[SerializeField] private LayerMask groundLayerMask;

		
		Rigidbody playerRb;
	
		Vector2 inputVector;

		bool isPlayerInAir;
		bool isJumpHeld;


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

			if (isPlayerInAir)
				movementForce *= airMultiplier;

			playerRb.AddForce(movementForce, ForceMode.Force);
		}
		
		void OnCollisionStay(Collision collision)
		{
			if (IsLayerInLayerMask(collision.gameObject.layer, groundLayerMask))
				isPlayerInAir = false;
		}

		void OnCollisionExit(Collision collision)
		{
			if (IsLayerInLayerMask(collision.gameObject.layer, groundLayerMask))
				isPlayerInAir = true;
		}

		private void Jump()
		{
			if (isPlayerInAir || !isJumpHeld)
			{
				return;
			}

			playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
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
				isJumpHeld = true;
			}
			else if (context.canceled)
			{
				isJumpHeld = false;
			}
		}

		#endregion
	}
}