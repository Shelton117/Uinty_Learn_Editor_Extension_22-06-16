using System.Xml;
using UnityEngine;

namespace EditorFramework.Example.XMLGUI.Editor
{
    public class XMLGUILayoutLabel : XMLGUIBase
    {
        private string Text;

        protected override void OnDispose()
        {

        }

        public override void ParseXML(XmlElement xmlElement)
        {
            base.ParseXML(xmlElement);

            Text = xmlElement.InnerText;
        }

        public override void OnGUI(Rect position)
        {
            base.OnGUI(position);

            GUILayout.Label(Text);
        }
    }
}