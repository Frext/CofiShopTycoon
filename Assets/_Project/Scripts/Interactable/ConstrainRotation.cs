using UnityEngine;

namespace _Project.Scripts.Interactable
{
	public class ConstrainRotation : MonoBehaviour
	{
		private Quaternion initialRotation;

	
		void Awake()
		{
			initialRotation = transform.rotation;
		}

		void Update()
		{
			transform.rotation = initialRotation;
		}
	}
}
