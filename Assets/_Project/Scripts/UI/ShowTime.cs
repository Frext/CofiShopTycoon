using System.Collections;
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

		void OnEnable()
		{
			StartCoroutine(IUpdateText());
		}

		IEnumerator IUpdateText()
		{
			while (true)
			{
				textMeshPro.SetText(((int)timeSO.value / 60).ToString("D2") + ":" +
				                    ((int)timeSO.value % 60).ToString("D2"));

				yield return new WaitForSeconds(1f);
			}
		}
		
		private void OnDisable()
		{
			StopAllCoroutines();
		}
	}
}
