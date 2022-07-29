using System;
using EditorFramework.Editor.GUI.Base;
using EditorFramework.Editor.Tools;
using UnityEditor;
using UnityEngine;

namespace EditorFramework.Editor
{
    public class FolderField : GUIBase
    {
        public FolderField(string path = "Assets", string folder = "Assets", string title = "Select Folder",
            string defaultName = "")
        {
            mPath = path;
            Folder = folder;
            Title = title;
            DefaultName = defaultName;
        }

        protected string mPath;

        public string Path => mPath;
        public string Folder;
        public string Title;
        public string DefaultName;
        public RectExtension.SplitType SplitType = RectExtension.SplitType.Vertical;

        public void SetPath(string path)
        {
            mPath = path;
        }

        protected override void OnDispose()
        {
            throw new System.NotImplementedException();
        }

        public override void OnGUI(Rect position)
        {
            base.OnGUI(position);

            var rects = position.Split(SplitType, position.width - 30);
            var leftRect = rects[0];
            var rightRect = rects[1];

            var currentGUIEnabled = UnityEngine.GUI.enabled;
            UnityEngine.GUI.enabled = false;
            {
                EditorGUI.TextField(leftRect, mPath);
            }
            UnityEngine.GUI.enabled = currentGUIEnabled;

            if (UnityEngine.GUI.Button(rightRect, GUIContents.Folder))
            {
                var path = EditorUtility.OpenFolderPanel(Title, Folder, DefaultName);
                mPath = path == String.Empty && path.IsDirectory() // �����ļ�
                    ? mPath
                    : path.ToAssetsPath();
                Debug.Log(mPath);
            }

            // ��ק����
            var dragInfo = DrapAndDropTool.Drag(Event.current, position);
            if (dragInfo.enterArea && dragInfo.complete && !dragInfo.dragging
                && dragInfo.paths[0].IsDirectory())
            {
                mPath = dragInfo.paths[0];
            }
        }
    }
}