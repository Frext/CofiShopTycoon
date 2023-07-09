using UnityEngine;

namespace _Project.Scripts.Interactable
{
	public class Food : MonoBehaviour
	{
		[SerializeField] private int id;
		[SerializeField] private bool isHeld;

		Transform initialParent;

		void Awake()
		{
			initialParent = transform.parent;
		}

		public void OnClick(Transform parent)
		{
			isHeld = !isHeld;
			
			transform.SetParent(isHeld ? parent : initialParent);
		}
	}
}
