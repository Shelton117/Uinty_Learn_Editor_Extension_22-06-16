using System.Xml;
using UnityEngine;

namespace EditorFramework.Example.XMLGUI.Editor
{
    public class XMLGUILayoutLabel : XMLGUIBase
    {
        public string Text;

        protected override void OnDispose()
        {

        }

        public override void ParseXML(XmlElement xmlElement, XMLGUI rootXMLGUI)
        {
            base.ParseXML(xmlElement, rootXMLGUI);

            Text = xmlElement.InnerText;
        }

        public override void OnGUI(Rect position)
        {
            base.OnGUI(position);

            GUILayout.Label(Text);
        }
    }
}