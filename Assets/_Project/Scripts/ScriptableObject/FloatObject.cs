using UnityEngine;
using static _Project.Scripts.HelperMethodsUtil;

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
	}
}
