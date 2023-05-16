using _Project.Scripts.Gameplay.Environment;
using UnityEditor;
using UnityEngine;

namespace _Project.Scripts.Editor
{
    [CustomEditor(typeof(EnvironmentTime))]
    public class EnvironmentTimeInspector : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            EnvironmentTime example = (EnvironmentTime)target;

            if (GUILayout.Button("Set Day"))
            {
                example.SetTime(EnvironmentTime.DayPhases.Day);
            }
            
            if (GUILayout.Button("Set Night"))
            {
                example.SetTime(EnvironmentTime.DayPhases.Night);
            }
        }
    }
}
