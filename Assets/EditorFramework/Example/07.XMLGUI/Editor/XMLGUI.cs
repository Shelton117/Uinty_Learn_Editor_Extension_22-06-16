using System;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

namespace EditorFramework.Example.XMLGUI.Editor
{
    /// <summary>
    /// �����������
    /// </summary>
    public class XMLGUI : MonoBehaviour
    {
        private List<XMLGUIBase> mGUIBases = new List<XMLGUIBase>();

        private Dictionary<string, XMLGUIBase> mGUIBasesForId =
            new Dictionary<string, XMLGUIBase>();

        public T GetGUIBaseById<T>(string id) where T : XMLGUIBase
        {
            XMLGUIBase t = default;

            if (mGUIBasesForId.TryGetValue(id, out t))
            {
                return t as T;
            }

            return default;
        }

        /// <summary>
        /// ����GUI�ķ���
        /// </summary>
        public void Draw()
        {
            foreach (var guiBase in mGUIBases)
            {
                guiBase.Draw();
            }
        }

        /// <summary>
        /// ���󹤳�����xml��ǩת���ɶ�Ӧ��GUI���
        /// </summary>
        private Dictionary<string, Func<XMLGUIBase>> mFactoriesForGUIBaseNames =
            new Dictionary<string, Func<XMLGUIBase>>()
            {
                {"Label", () => new XMLGUILabel()},
                {"TextField", () => new XMLGUITextField()},
                {"TextArea", () => new XMLGUITextArea()},
                {"Button", () => new XMLGUIButton()},

                {"LayoutLabel", () => new XMLGUILayoutLabel()}, // ���Ӻ����� TODO:����GUI

                {"LayoutHorizontal", () => new XMLGUILayoutHorizontal()},
            };

        public void ReadXML(string xml)
        {
            // ÿ����Ⱦ֮ǰ��Ҫ�����л�����
            var doc = new XmlDocument();
            doc.LoadXml(xml);
            var rootNode = doc.SelectSingleNode("GUI");

            ChildElements2GUIBase(rootNode as XmlElement);
        }

        public void ChildElements2GUIBase(XmlElement rootElement)
        {
            Func<XMLGUIBase> xmlGUIBaseFactory;

            foreach (XmlElement rootNodeChildNode in rootElement.ChildNodes)
            {
                if (mFactoriesForGUIBaseNames.TryGetValue(rootNodeChildNode.Name, out xmlGUIBaseFactory))
                {
                    var mXMLGUIBase = xmlGUIBaseFactory.Invoke();
                    mXMLGUIBase.ParseXML(rootNodeChildNode);

                    AddGUIBase(mXMLGUIBase);
                }
                else
                {
                    Debug.LogWarning("error tag: " + rootNodeChildNode.Name);
                }
            }
        }

        private void AddGUIBase(XMLGUIBase xmlguiBase)
        {
            mGUIBases.Add(xmlguiBase);

            if (!string.IsNullOrEmpty(xmlguiBase.Id))
            {
                mGUIBasesForId.Add(xmlguiBase.Id, xmlguiBase);
            }
        }
    }
}