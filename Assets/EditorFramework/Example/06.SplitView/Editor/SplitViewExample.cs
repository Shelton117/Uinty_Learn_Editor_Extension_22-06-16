using EditorFramework.Editor;
using UnityEditor;
using UnityEngine;

namespace EditorFramework.Example.SplitView.Editor
{
    /// <summary>
    /// ��ק����ʾ��
    /// </summary>
    [CustomEditorWindow((int)ExampleIndex.SplitView)]
    public class SplitViewExample : EditorWindow
    {
        private EditorFramework.Editor.SplitView mSplitView;

        private void OnEnable()
        {
            mSplitView = new EditorFramework.Editor.SplitView(RectExtension.SplitType.Horizontal);

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
            obj.DrawOutline(2, Color.white);
            GUI.Box(obj, "First");
        }

        private void SplitViewOnSecondArea(Rect obj)
        {
            obj.DrawOutline(2, Color.cyan);
            GUI.Box(obj, "Second");
        }

        private void OnGUI()
        {
            mSplitView.OnGUI(this.LocalPostion().Zoom(-10, RectExtension.AnchorType.MiddleCenter));
        }
    }
}