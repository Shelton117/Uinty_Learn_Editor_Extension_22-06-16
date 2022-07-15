using System;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

namespace EditorFramework.Example.XMLGUI.Editor
{
    public class XMLGUI : MonoBehaviour
    {
        public List<XMLGUIBase> GUIBases = new List<XMLGUIBase>();

        public Dictionary<string, XMLGUIBase> GUIBasesForId =
            new Dictionary<string, XMLGUIBase>();

        public T GetGUIBaseById<T>(string id) where T : XMLGUIBase
        {
            XMLGUIBase t = default;

            if (GUIBasesForId.TryGetValue(id, out t))
            {
                return t as T;
            }

            return default;
        }

        public void ReadXML(string xml)
        {
            // 每次渲染之前需要反序列化操作
            var doc = new XmlDocument();
            doc.LoadXml(xml);
            var rootNode = doc.SelectSingleNode("GUI");
            foreach (XmlElement rootNodeChildNode in rootNode.ChildNodes)
            {
                string id = rootNodeChildNode.Attributes["id"].Value;
                string value = rootNodeChildNode.InnerText;
                XMLGUIBase mXMLGUIBase;

                switch (rootNodeChildNode.Name)
                {
                    case "Label":
                        mXMLGUIBase = new XMLGUILabel(value);
                        mXMLGUIBase.Id = id;

                        AddGUIBase(mXMLGUIBase);
                        break;
                    case "TextField":
                        mXMLGUIBase = new XMLGUITextField(value);
                        mXMLGUIBase.Id = id;

                        GUIBases.Add(mXMLGUIBase);

                        AddGUIBase(mXMLGUIBase);
                        break;
                    case "TextArea":
                        mXMLGUIBase = new XMLGUITextArea(value);
                        mXMLGUIBase.Id = id;

                        AddGUIBase(mXMLGUIBase);
                        break;
                    case "Button":
                        mXMLGUIBase = new XMLGUIButton(value);
                        mXMLGUIBase.Id = id;

                        AddGUIBase(mXMLGUIBase);
                        break;
                }
            }
        }

        private void AddGUIBase(XMLGUIBase xmlguiBase)
        {
            GUIBases.Add(xmlguiBase);

            if (!string.IsNullOrEmpty(xmlguiBase.Id))
            {
                GUIBasesForId.Add(xmlguiBase.Id, xmlguiBase);
            }
            
        }
    }
}