using System;
using EditorFramework.Editor;
using UnityEditor;
using UnityEngine;

namespace EditorFramework.Example.SplitView.Editor
{
    /// <summary>
    /// ÍÏ×§ÇøÓòÊ¾Àý
    /// </summary>
    [CustomEditorWindow((int)ExampleIndex.SplitView)]
    public class SplitViewExample : EditorWindow
    {
        private EditorFramework.Editor.SplitView mSplitView;

        private void OnEnable()
        {
            mSplitView = new EditorFramework.Editor.SplitView();
            mSplitView.FirstArea += SplitViewOnFirstArea;
            mSplitView.SecondArea += SplitViewOnSecondArea;
        }

        private void OnDisable()
        {
            mSplitView.FirstArea -= SplitViewOnFirstArea;
            mSplitView.SecondArea -= SplitViewOnSecondArea;
        }

        private void SplitViewOnFirstArea(Rect obj)
        {
            GUI.Box(obj, "First");
        }

        private void SplitViewOnSecondArea(Rect obj)
        {
            GUI.Box(obj, "Second");
        }

        private void OnGUI()
        {
            var position = new Rect(Vector2.zero, this.position.size);
            mSplitView.OnGUI(position);
        }
    }
}