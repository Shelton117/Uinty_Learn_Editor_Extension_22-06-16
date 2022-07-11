using EditorFramework.Editor;
using UnityEditor;
using UnityEngine;

namespace EditorFramework.Example.CustomEditor
{
    /// <summary>
    /// 自定义编辑器部分示例
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