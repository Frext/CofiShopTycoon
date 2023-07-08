using System.Collections;
using _Project.Scripts.ScriptableObject;
using TMPro;
using UnityEngine;

namespace _Project.Scripts.UI
{
	[RequireComponent(typeof(TextMeshProUGUI))]
	public class ShowIntObject : MonoBehaviour
	{
		[SerializeField] private IntObject intObjectSO;
		[SerializeField] private bool shouldUpdate;

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
			do
			{
				textMeshPro.text = intObjectSO.value.ToString();
				yield return new WaitForSeconds(1f);
			}
			while (shouldUpdate);
		}

		private void OnDisable()
		{
			StopAllCoroutines();
		}
	}
}
