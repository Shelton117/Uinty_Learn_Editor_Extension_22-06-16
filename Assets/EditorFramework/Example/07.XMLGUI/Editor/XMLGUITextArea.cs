using UnityEngine;

namespace EditorFramework.Example.XMLGUI.Editor
{
    public class XMLGUITextArea : XMLGUIBase
    {
        public XMLGUITextArea(string text)
        {
            Text = text;
        }

        private string Text;

        protected override void OnDispose()
        {
            
        }

        public override void OnGUI(Rect position)
        {
            base.OnGUI(position);

            Text = GUILayout.TextArea(Text);
        }
    }
}