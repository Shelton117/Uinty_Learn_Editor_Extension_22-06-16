using EditorFramework.Editor;
using UnityEditor;
using UnityEngine;

namespace EditorFramework.Example.FolderField.Editor
{
    /// <summary>
    /// ·��ѡ��Ľű�
    /// ������ťѡ�����ק���ѷ�װ��FolderField��
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