using System;
using System.Xml;
using UnityEngine;

namespace EditorFramework.Example.XMLGUI.Editor
{
    public class XMLGUILayoutButton : XMLGUIBase
    {
        public override void ParseXML(XmlElement xmlElement, XMLGUI rootXMLGUI)
        {
            base.ParseXML(xmlElement, rootXMLGUI);

            Text = xmlElement.InnerText;
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
