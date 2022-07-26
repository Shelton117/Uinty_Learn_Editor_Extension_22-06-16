using System.Xml;
using UnityEngine;

namespace EditorFramework.Example.XMLGUI.Editor
{
    public class XMLGUILayoutHorizontal : XMLGUIContainerBase
    {
        public bool Box { get; set; }

        public override void OnGUI(Rect position)
        {
            base.OnGUI(position);

            if (Box)
            {
                GUILayout.BeginHorizontal("Box");
            }
            else
            {
                GUILayout.BeginHorizontal();
            }
            
            {
                Xmlgui.Draw();
            }
            GUILayout.EndHorizontal();
        }

        public override void ParseXML(XmlElement xmlElement, XMLGUI rootXMLGUI)
        {
            base.ParseXML(xmlElement, rootXMLGUI);
            
            var boxString = xmlElement.GetAttribute("box");

            if (!string.IsNullOrEmpty(boxString))
            {
                Box = bool.Parse(boxString);
            }
        }
    }
}