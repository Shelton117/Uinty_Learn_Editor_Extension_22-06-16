using System.Xml;
using UnityEngine;

namespace EditorFramework.Example.XMLGUI.Editor
{
    public abstract class XMLGUIContainerBase : XMLGUIBase
    {
        // ÈÝÆ÷
        private XMLGUI mXmlgui = new XMLGUI();

        public XMLGUI Xmlgui
        {
            get { return mXmlgui; }
        }

        protected override void OnDispose()
        {

        }

        public override void ParseXML(XmlElement xmlElement, XMLGUI rootXMLGUI)
        {
            base.ParseXML(xmlElement, rootXMLGUI);
            mXmlgui.ChildElements2GUIBase(xmlElement, rootXMLGUI);
        }
    }
}