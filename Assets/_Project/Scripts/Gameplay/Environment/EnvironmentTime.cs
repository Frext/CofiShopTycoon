using System;
using System.Collections.Generic;
using _Project.Scripts.ScriptableObject;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Environment
{
	[Serializable]
	public struct DayPhase
	{
		[Tooltip("It just separates phases. No effect on code.")]
		[SerializeField] private string name;

		public Material lightMaterial;
		public Material skyboxMaterial;

		public int hourStart;
	}
	
	public class EnvironmentTime : MonoBehaviour
	{
		[SerializeField] private FloatObject timeSO;
		
		[Header("Finding Light Sources")]
		[SerializeField] private string objectWithLightTag = "Untagged";
		[Space]
		
		[SerializeField] private List<DayPhase> dayPhases;


		List<Renderer> renderersWithLightList = new();
		
		private int _currentDayPhase;
		private int CurrentDayPhase
		{
			get => _currentDayPhase;
			set
			{
				// If it's already the same day phase, don't change it.
				if (_currentDayPhase == value)
					return;
				
				_currentDayPhase = CycleBetween(value, 0, dayPhases.Count - 1);
				SetTime();
			}
		}
		
		
		private int CycleBetween(int value, int min, int max)
		{
			// Secure the min and max arguments
			if (min > max)
				throw new Exception("min cannot be greater than max in the CycleBetween method");

			// Lets say value was -1, min was 0, and max was 2. The length would be 3.
			// (3 + -1 - 0) % (3+0) = 2 % 3 + 0 = 2
			// Otherwise if the value was 3,
			// (3 + 3 - 0) % 3 + 0 = 0
			int count = max - min + 1;

			return min + (count + value - min) % count;
		}
		
		void Awake()
		{
			ObtainMeshRenderersWithLightList();
		}

		private void ObtainMeshRenderersWithLightList()
		{
			foreach (GameObject go in GameObject.FindGameObjectsWithTag(objectWithLightTag))
			{
				Renderer currentMeshRenderer = go.GetComponent<Renderer>();

				if (currentMeshRenderer != null)
				{
					renderersWithLightList.Add(currentMeshRenderer);
				}
			}
		}

		private void SetTime()
		{
			Material oldMaterial,
				newMaterial;
			
			oldMaterial = dayPhases[CycleBetween(CurrentDayPhase - 1, 0, dayPhases.Count - 1)].lightMaterial;
			newMaterial = dayPhases[CurrentDayPhase].lightMaterial;
			
			foreach (Renderer currentRenderer in renderersWithLightList)
			{
				currentRenderer.sharedMaterials = ReplaceOneMaterial(currentRenderer.sharedMaterials, oldMaterial, newMaterial);
			}
			
			
			SetSkybox(dayPhases[CurrentDayPhase].skyboxMaterial);
		}

		private Material[] ReplaceOneMaterial(Material[] materialArray, Material oldMaterial, Material newMaterial)
		{
			for (int index = 0; index < materialArray.Length; index++)
			{
				if (materialArray[index] == oldMaterial)
				{
					materialArray[index] = newMaterial;
					// The reason I break here is we don't have to turn all the lights of an object, e.g., a building, on.
					break;
				}
			}

			return materialArray;
		}
		
		private void SetSkybox(Material material)
		{
			RenderSettings.skybox = material;
		}

		void Update()
		{
			timeSO.value += Time.deltaTime;

			GoToNextPhase();
		}

		private void GoToNextPhase()
		{
			for (int index = 0; index < dayPhases.Count; index++)
			{
				if ((int)timeSO.value / 60 >= dayPhases[index].hourStart)
				{
					print((int)timeSO.value / 60);
					CurrentDayPhase = index;
				}
			}
		}
	}
}
