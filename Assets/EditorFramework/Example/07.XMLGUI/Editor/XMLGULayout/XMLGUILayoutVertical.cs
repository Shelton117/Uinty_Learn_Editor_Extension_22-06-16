using System.Xml;
using UnityEngine;

namespace EditorFramework.Example.XMLGUI.Editor
{
    public class XMLGUILayoutVertical : XMLGUIContainerBase
    {
        public bool Box { get; set; }

        public override void OnGUI(Rect position)
        {
            base.OnGUI(position);

            if (Box)
            {
                GUILayout.BeginVertical("Box");
            }
            else
            {
                GUILayout.BeginVertical();
            }
            
            {
                Xmlgui.Draw();
            }
            GUILayout.EndVertical();
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