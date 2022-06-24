using EditorFramework.Editor;
using UnityEditor;
using UnityEngine;

namespace EditorFramework.Example.GUIBase.Editor
{
    [CustomEditorWindow]
    public class GUIBaseExample : EditorWindow
    {
        public class Label : EditorFramework.Editor.GUIBase
        {
            public Label(string text)
            {
                mText = text;
            }

            private string mText;

            public override void OnGUI(Rect position)
            {
                GUILayout.Label(mText);
            }

            protected override void OnDispose()
            {
                mText = null;
            }
        }

        private Label mLabel = new Label("123");
        private Label mLabel2 = new Label("456");

        private void OnGUI()
        {
            mLabel.OnGUI(default);
            mLabel2.OnGUI(default);
        }
    }
}