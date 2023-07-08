using System;
using System.Collections;
using System.Collections.Generic;
using _Project.Scripts.ScriptableObject;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Project.Scripts.Gameplay.Environment
{
	[Serializable]
	public struct DayPhase
	{
		[Tooltip("It just separates phases. No effect on code.")]
		[SerializeField] private string name;
		[Space]
		
		public int hourStart;
		[Space]
		
		public Material lightSourceMaterial;
		public Material skyboxMaterial;
		public float ambientIntensityMultiplier;

		[Space] 
		[Tooltip("Sun Source")]
		public Light directionalLight;
		public bool isLightSourceOn;
		public bool isFogOn;
	}
	
	public class EnvironmentTime : MonoBehaviour
	{
		[SerializeField] private FloatObject timeSO;
		
		[Header("Finding Light Sources")]
		[SerializeField] private string objectWithLightTag = "Untagged";
		[Space]
		
		[SerializeField] private List<DayPhase> dayPhaseList;


		List<Renderer> renderersWithLightList = new();
		List<GameObject> lightSourcesList = new();
		
		private int _currentDayPhase;
		private int CurrentDayPhase
		{
			get => _currentDayPhase;
			set
			{
				// If it's already the same day phase, don't change it.
				if (_currentDayPhase == value)
					return;
				
				_currentDayPhase = CycleBetween(value, 0, dayPhaseList.Count - 1);
				SetDayPhase();
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
		
		private void SetDayPhase()
		{
			SetLightSourceMaterials();
			SetSkyboxMaterial(dayPhaseList[CurrentDayPhase].skyboxMaterial);
			SetSkyboxIntensity(dayPhaseList[CurrentDayPhase].ambientIntensityMultiplier);

			SetSun(dayPhaseList[CurrentDayPhase].directionalLight);
			ToggleLightSources(dayPhaseList[CurrentDayPhase].isLightSourceOn);
			ToggleFog(dayPhaseList[CurrentDayPhase].isFogOn);
		}
		
		private void SetLightSourceMaterials()
		{
			Material oldMaterial,
				newMaterial;
			
			oldMaterial = dayPhaseList[CycleBetween(CurrentDayPhase - 1, 0, dayPhaseList.Count - 1)].lightSourceMaterial;
			newMaterial = dayPhaseList[CurrentDayPhase].lightSourceMaterial;
			
			foreach (Renderer currentRenderer in renderersWithLightList)
			{
				currentRenderer.sharedMaterials = ReplaceOneMaterial(currentRenderer.sharedMaterials, oldMaterial, newMaterial);
			}
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
		
		private void SetSkyboxMaterial(Material material)
		{
			RenderSettings.skybox = material;
		}
		
		private void SetSkyboxIntensity(float skyboxIntensityMultiplier)
		{
			RenderSettings.ambientIntensity = skyboxIntensityMultiplier;
		}
		
		private void SetSun(Light directionalLight)
		{
			// First turn the directional lights on or off so they dont overlap.
			for (int index = 0; index < dayPhaseList.Count; index++)
			{
				dayPhaseList[index].directionalLight.gameObject.SetActive(index == _currentDayPhase);
			}
			
			RenderSettings.sun = directionalLight;
		}
		
		private void ToggleLightSources(bool isLightSourceOn)
		{
			foreach (var lightSource in lightSourcesList)
			{
				lightSource.SetActive(isLightSourceOn);
			}
		}
		
		private void ToggleFog(bool isFogOn)
		{
			RenderSettings.fog = isFogOn;
		}
		
		void Awake()
		{
			ObtainMeshRenderersWithLightList();
			ObtainLightSources();
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
		
		private void ObtainLightSources()
		{
			foreach (Light lightComponent in FindObjectsOfType<Light>())
			{
				if (lightComponent != null)
				{
					lightSourcesList.Add(lightComponent.gameObject);
				}
			}
		}

		void Start()
		{
			// Update the day phase before the game begins because the setup could be wrong.
			CurrentDayPhase++;
			CurrentDayPhase--;
		}

		void Update()
		{
			timeSO.value += Time.deltaTime;
		}
		
		void OnEnable()
		{
			StartCoroutine(IGoToNextPhase());
		}
		
		IEnumerator IGoToNextPhase()
		{
			while (true)
			{
				for (int index = 0; index < dayPhaseList.Count; index++)
				{
					if ((int)timeSO.value / 60 >= dayPhaseList[index].hourStart)
					{
						CurrentDayPhase = index;
					}
				}
				
				yield return new WaitForSeconds(1f);
			}
		}

		void OnDisable()
		{
			StopAllCoroutines();
		}
	}
}
