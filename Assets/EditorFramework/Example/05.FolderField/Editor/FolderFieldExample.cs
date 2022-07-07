using System;
using EditorFramework.Editor;
using UnityEditor;
using UnityEngine;

namespace EditorFramework.Example.FolderField.Editor
{
    [CustomEditorWindow(5)]
    public class FolderFieldExample : EditorWindow
    {
        private string mPath = "Choose Folder";

        private void OnGUI()
        {
            var rect = EditorGUILayout.GetControlRect(GUILayout.Height(20));

            if (GUI.Button(rect, mPath))
            {
                mPath = EditorUtility.OpenFolderPanel("Open Folder", Application.dataPath,"");
                Debug.Log(mPath);
            }

            // ÍÏ×§²¿·Ö
            var dragInfo = EditorFramework.Editor.DrapAndDropTool.Drag(Event.current, rect);
            if (dragInfo.enterArea && dragInfo.complete && !dragInfo.dragging)
            {
                mPath = dragInfo.paths[0];
            }
        }
    }
}