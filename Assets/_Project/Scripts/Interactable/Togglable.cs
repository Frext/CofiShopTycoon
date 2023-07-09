using System;
using UnityEngine;

namespace _Project.Scripts.Interactable
{
	public class Togglable : MonoBehaviour
	{
		[SerializeField] private Vector3 closePoint;
		
		
		Vector3 openPoint;
		bool isOpen;

		
		void Awake()
		{
			openPoint = transform.position;
		}

		public void OnClick()
		{
			isOpen = !isOpen;

			transform.position = isOpen ? openPoint : closePoint;
		}
	}
}
