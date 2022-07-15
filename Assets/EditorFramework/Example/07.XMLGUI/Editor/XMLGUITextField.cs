using UnityEngine;

namespace EditorFramework.Example.XMLGUI.Editor
{
    public class XMLGUITextField : XMLGUIBase
    {
        public XMLGUITextField(string text)
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

            Text = GUILayout.TextField(Text);
        }
    }


}
