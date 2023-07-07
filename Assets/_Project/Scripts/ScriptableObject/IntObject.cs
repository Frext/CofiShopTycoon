using System;
using UnityEngine;

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

        private int CycleBetween(int value, int min, int max)
        {
            // Secure the min and max arguments
            if (min > max)
                throw new Exception("min cannot be greater than max in the CycleBetween method");

            int count = max - min + 1;

            return min + (count + value - min) % count;
        }
    }
}