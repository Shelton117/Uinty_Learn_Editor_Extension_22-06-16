using EditorFramework.Editor;
using UnityEditor;
using UnityEngine;

namespace EditorFramework.Example.CustomEditor
{
    /// <summary>
    /// �Զ���༭������ʾ��
    /// </summary>
    [CustomEditorWindow((int)ExampleIndex.CustomEditor)]
    public class CustomEditorExample : EditorWindow
    {
        private void OnGUI()
        {
            GUILayout.Label("CustomEditorExample");
        }
    }
}