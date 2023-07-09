using System;
using UnityEngine;

namespace _Project.Scripts
{
	public static class HelperMethodsUtil
	{
		public static bool IsLayerInLayerMask(int layer, LayerMask layerMask)
		{
			// Returns true if the layer that is converted into a layer mask and the attack layer mask have a common bit which is 1.
			return (layerMask & (1 << layer)) != 0;
		}
		
		public static int CycleBetween(int value, int min, int max)
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
		
		public static float CycleBetween(float val, float min, float max)
		{
			// Secure the min and max arguments
			if (min > max)
				throw new Exception("min cannot be greater than max in the CycleBetween method");

			float count = max - min + 1;
			
			return min + (count + val - min) % count;
		}
	}
}
