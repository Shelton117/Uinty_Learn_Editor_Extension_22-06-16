using System.Xml;
using UnityEngine;

namespace EditorFramework.Example.XMLGUI.Editor
{
    public class XMLGUILayoutHorizontal : XMLGUIBase
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

        public override void OnGUI(Rect position)
        {
            base.OnGUI(position);

            GUILayout.BeginHorizontal();
            {
                mXmlgui.Draw();
            }
            GUILayout.EndHorizontal();
        }

        public override void ParseXML(XmlElement xmlElement)
        {
            base.ParseXML(xmlElement);
            mXmlgui.ChildElements2GUIBase(xmlElement);
        }
    }
}