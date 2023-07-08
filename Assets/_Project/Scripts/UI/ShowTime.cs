using _Project.Scripts.ScriptableObject;
using TMPro;
using UnityEngine;

namespace _Project.Scripts.UI
{
	[RequireComponent(typeof(TextMeshProUGUI))]
	public class ShowTime : MonoBehaviour
	{
		[SerializeField] private FloatObject timeSO;
		[Space]

		TextMeshProUGUI textMeshPro;

		void Awake()
		{
			textMeshPro = GetComponent<TextMeshProUGUI>();
		}

		void Start()
		{
			UpdateText();
		}

		private void UpdateText()
		{
			textMeshPro.SetText(((int)timeSO.value / 60).ToString("D2") + ":" + 
			                    ((int)timeSO.value % 60).ToString("D2"));
		}
		
		void Update()
		{
			UpdateText();
		}
	}
}
