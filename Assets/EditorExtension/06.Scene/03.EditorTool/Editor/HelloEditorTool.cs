using UnityEditor;
using UnityEditor.EditorTools;
using UnityEngine;

namespace EditorExtension.Scene.EditorTool.Editor
{
    [EditorTool("Hello EditorTool")]
    public class HelloEditorTool : UnityEditor.EditorTools.EditorTool
    {
        public override void OnToolGUI(EditorWindow window)
        {
            // ¥∞ø⁄Ã· æ
            window.ShowNotification(new GUIContent("Hello EditorTool"));

            UnityEditor.Handles.BeginGUI();
            {
                if (GUILayout.Button("Hello EditorTool"))
                {
                    Debug.Log("Hello EditorTool");
                }
            }
            UnityEditor.Handles.EndGUI();
        }
    }
}