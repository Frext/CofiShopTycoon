using System;
using UnityEngine;

namespace _Project.Scripts.ScriptableObject
{
	[CreateAssetMenu]
	public class FloatObject : UnityEngine.ScriptableObject
	{
		[SerializeField] private float minimum = float.MinValue,
									maximum = float.MaxValue;
		[Space]
		
		[SerializeField] private float _value;
		public float value
		{
			get
			{
				_value = CycleBetween(_value, minimum, maximum);
				return _value;
			}
			set => _value = value;
		}

		private float CycleBetween(float val, float min, float max)
		{
			// Secure the min and max arguments
			if (min > max)
				throw new Exception("min cannot be greater than max in the CycleBetween method");

			float count = max - min + 1;
			
			return min + (count + val - min) % count;
		}
	}
}
