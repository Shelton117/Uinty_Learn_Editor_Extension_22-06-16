using System;
using System.Xml;
using UnityEngine;

namespace EditorFramework.Example.XMLGUI.Editor
{
    public class XMLGUIButton : XMLGUIBase
    {
        public override void ParseXML(XmlElement xmlElement, XMLGUI rootXMLGUI)
        {
            base.ParseXML(xmlElement, rootXMLGUI);

            Text = xmlElement.InnerText;
        }

        public string Text;
        public Action Onclick;

        protected override void OnDispose()
        {

        }

        public override void OnGUI(Rect position)
        {
            base.OnGUI(position);

            if (GUI.Button(position, Text))
            {
                Onclick?.Invoke();
            }
        }
    }
}