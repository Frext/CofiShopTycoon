using UnityEngine;

namespace _Project.Scripts.UI
{
	public class CursorHandler : MonoBehaviour
	{
		void Start()
		{
			HideCursor();
		}

		#region Methods Used by Other Methods

		public void ShowCursor()
		{
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
		
		public void HideCursor()
		{
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
		}

		#endregion
		
	}
}
