using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Project.Scripts.Gameplay.Player
{
	public class PlayerFPSController : MonoBehaviour
	{
		[SerializeField] private CinemachineVirtualCamera cmCamera;
		[SerializeField] private float sensitivity = 1f;
		
		
		Vector2 mouseInput;

		float xRotation,
			yRotation;

		void Update()
		{
			UpdateRotation();
		}

		private void UpdateRotation()
		{
			yRotation += mouseInput.x;

			xRotation -= mouseInput.y;
			xRotation = Mathf.Clamp(xRotation, -90f, 90f);
			
			// Rotate the camera and the orientation transform.
			cmCamera.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
			transform.rotation = Quaternion.Euler(0, yRotation, 0);
		}

		#region Player Input Actions Methods
		
		public void OnMouseMove(InputAction.CallbackContext context)
		{
			mouseInput = context.ReadValue<Vector2>() * sensitivity;
		}
		
		#endregion
	}
}
