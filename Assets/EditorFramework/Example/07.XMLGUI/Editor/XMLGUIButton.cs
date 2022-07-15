using System;
using UnityEngine;

namespace EditorFramework.Example.XMLGUI.Editor
{
    public class XMLGUIButton : XMLGUIBase
    {
        public XMLGUIButton(string text)
        {
            Text = text;
        }

        private string Text;
        public Action Onclick;

        protected override void OnDispose()
        {

        }

        public override void OnGUI(Rect position)
        {
            base.OnGUI(position);

            if (GUILayout.Button(Text))
            {
                Onclick?.Invoke();
            }
        }
    }
}