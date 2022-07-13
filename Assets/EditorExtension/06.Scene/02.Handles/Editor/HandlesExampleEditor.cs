using UnityEditor;
using UnityEngine;

namespace EditorExtension.Scene.Handles.Editor
{
    [CustomEditor(typeof(HandlesExample))]
    public class HandlesExampleEditor : UnityEditor.Editor
    {
        private void OnSceneGUI()
        {
            var t = target as HandlesExample;
            UnityEditor.Handles.color = new Color(1, 0.8f, 0.4f, 1);
            UnityEditor.Handles.DrawWireDisc(t.transform.position, t.transform.up, t.Radius);
            UnityEditor.Handles.Label(t.transform.position,t.Radius.ToString("F1"));
            
            UnityEditor.Handles.BeginGUI();
            {
                if (GUILayout.Button("Hello"))
                {
                    Debug.Log("Hello");
                }
            }
            UnityEditor.Handles.EndGUI();
        }
    }
}