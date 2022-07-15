using UnityEngine;

namespace EditorFramework.Example.XMLGUI.Editor
{
    public class XMLGUILabel : XMLGUIBase
    {
        public XMLGUILabel(string text)
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

            GUILayout.Label(Text);
        }
    }
}