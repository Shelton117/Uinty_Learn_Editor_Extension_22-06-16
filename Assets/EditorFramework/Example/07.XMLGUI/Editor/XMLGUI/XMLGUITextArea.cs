using System.Xml;
using UnityEngine;

namespace EditorFramework.Example.XMLGUI.Editor
{
    public class XMLGUITextArea : XMLGUIBase
    {
        public override void ParseXML(XmlElement xmlElement, XMLGUI rootXMLGUI)
        {
            base.ParseXML(xmlElement, rootXMLGUI);

            Text = xmlElement.InnerText;
        }

        public string Text;

        protected override void OnDispose()
        {
            
        }

        public override void OnGUI(Rect position)
        {
            base.OnGUI(position);

            Text = GUI.TextArea(position, Text);
        }
    }
}