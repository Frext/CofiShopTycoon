using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Environment
{
	public class EnvironmentTime : MonoBehaviour
	{
		// TODO: Make every public thing private in this class whenever the editor script is deleted.
		[SerializeField] private string objectWithLightTag;

		
		[Header("Materials")] 
		[SerializeField] private Material litMaterial;
		[SerializeField] private Material unlitMaterial;
		
		[Space] 
		[SerializeField] private Material skyboxDayMaterial;
		[SerializeField] private Material skyboxNightMaterial;
		

		List<Renderer> renderersWithLightList = new();

		public enum DayPhases
		{
			Day,
			Night
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

		public void SetTime(DayPhases dayPhase)
		{
			Material oldMaterial,
				newMaterial;
			
			if (dayPhase == DayPhases.Day)
			{
				oldMaterial = litMaterial;
				newMaterial = unlitMaterial;
				
				SetSkybox(skyboxDayMaterial);
			}
			else
			{
				oldMaterial = unlitMaterial;
				newMaterial = litMaterial;
				
				SetSkybox(skyboxNightMaterial);
			}
			
			foreach (Renderer currentRenderer in renderersWithLightList)
			{
				currentRenderer.sharedMaterials = ReplaceOneMaterial(currentRenderer.sharedMaterials, oldMaterial, newMaterial);
			}
		}

		private void SetSkybox(Material material)
		{
			RenderSettings.skybox = material;
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
	}
}
