using UnityEngine;
using static _Project.Scripts.HelperMethodsUtil;

namespace _Project.Scripts.ScriptableObject
{
    [CreateAssetMenu]
    public class IntObject : UnityEngine.ScriptableObject
    {
        [SerializeField] private int minimum = int.MinValue,
            maximum = int.MaxValue;
        [Space]
		
        [SerializeField] private int _value;
        public int value
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