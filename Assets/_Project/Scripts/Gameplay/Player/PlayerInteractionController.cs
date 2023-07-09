using _Project.Scripts.Interactable;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Project.Scripts.Gameplay.Player
{
	public class PlayerInteractionController : MonoBehaviour
	{
		[Range(0, 10)]
		[SerializeField] private float maxDistance = 10f;
		[SerializeField] private LayerMask interactableLayer;
		[SerializeField] private GameObject objectToFollow;

		Camera mainCamera;

		void Awake()
		{
			mainCamera = Camera.main;
		}

		public void OnMouseClick(InputAction.CallbackContext context)
		{
			if (context.performed)
			{
				Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
				
				if (Physics.Raycast(ray, out var raycastHit, maxDistance, interactableLayer))
				{
					Food foodScript = raycastHit.collider.gameObject.GetComponent<Food>();
					Togglable togglableScript = raycastHit.collider.gameObject.GetComponent<Togglable>();
					
					if (foodScript != null)
					{
						foodScript.OnClick(objectToFollow.transform);
					}
					else if (togglableScript != null)
					{
						togglableScript.OnClick();
					}
				}
			}
		}
	}
}
