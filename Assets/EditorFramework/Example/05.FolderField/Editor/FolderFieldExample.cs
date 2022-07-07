using EditorFramework.Editor;
using UnityEditor;
using UnityEngine;

namespace EditorFramework.Example.FolderField.Editor
{
    /// <summary>
    /// 路径选择的脚本
    /// 包含按钮选择和拖拽
    /// </summary>
    [CustomEditorWindow(5)]
    public class FolderFieldExample : EditorWindow
    {
        private string mPath = "Choose Folder";

        private void OnGUI()
        {
            var rect = EditorGUILayout.GetControlRect(GUILayout.Height(20));
            var rects = rect.VerticalSplit(rect.width - 30);
            var leftRect = rects[0];
            var rightRect = rects[1];

            GUI.Label(leftRect, mPath);
            if (GUI.Button(rightRect, GUIContents.Folder))
            {
                mPath = EditorUtility.OpenFolderPanel("Open Folder", Application.dataPath, "");
                Debug.Log(mPath);
            }

            // 拖拽部分
            var dragInfo = EditorFramework.Editor.DrapAndDropTool.Drag(Event.current, rect);
            if (dragInfo.enterArea && dragInfo.complete && !dragInfo.dragging)
            {
                mPath = dragInfo.paths[0];
            }
        }
    }
}