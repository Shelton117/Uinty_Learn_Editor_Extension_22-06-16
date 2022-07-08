using EditorFramework.Editor;
using UnityEditor;
using UnityEngine;

namespace EditorFramework.Example.FolderField.Editor
{
    /// <summary>
    /// 路径选择的脚本
    /// 包含按钮选择和拖拽（已封装，FolderField）
    /// </summary>
    [CustomEditorWindow(5)]
    public class FolderFieldExample : EditorWindow
    {
        private EditorFramework.Editor.FolderField mFolderField;

        private void OnEnable()
        {
            mFolderField = new EditorFramework.Editor.FolderField();
        }

        private void OnGUI()
        {
            GUILayout.Label("Folder Field");
            var rect = EditorGUILayout.GetControlRect(GUILayout.Height(20));
            mFolderField.OnGUI(rect);
        }
    }
}