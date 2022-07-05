using EditorFramework.Editor;
using UnityEditor;
using UnityEngine;

namespace EditorFramework.Example.CustomEditor
{
    [CustomEditorWindow(1)]
    public class CustomEditorExample : EditorWindow
    {
        private void OnGUI()
        {
            GUILayout.Label("CustomEditorExample");
        }
    }
}