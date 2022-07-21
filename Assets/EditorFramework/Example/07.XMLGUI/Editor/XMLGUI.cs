using System;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

namespace EditorFramework.Example.XMLGUI.Editor
{
    /// <summary>
    /// �����������
    /// </summary>
    public class XMLGUI
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

                {"LayoutLabel", () => new XMLGUILayoutLabel()}, 
                {"LayoutButton", () => new XMLGUILayoutButton()}, // ���Ӻ����� TODO:����GUI

                {"LayoutHorizontal", () => new XMLGUILayoutHorizontal()},
                {"LayoutVertical", () => new XMLGUILayoutVertical()},
            };

        public void ReadXML(string xml)
        {
            // ÿ����Ⱦ֮ǰ��Ҫ�����л�����
            var doc = new XmlDocument();
            doc.LoadXml(xml);
            var rootNode = doc.SelectSingleNode("GUI");

            // GUI ��ǩ���Ǹ��ڵ�
            ChildElements2GUIBase(rootNode as XmlElement, this);
        }

        public void ChildElements2GUIBase(XmlElement rootElement, XMLGUI rootXMLGUI)
        {
            Func<XMLGUIBase> xmlGUIBaseFactory;

            foreach (XmlElement rootNodeChildNode in rootElement.ChildNodes)
            {
                if (mFactoriesForGUIBaseNames.TryGetValue(rootNodeChildNode.Name, out xmlGUIBaseFactory))
                {
                    var mXMLGUIBase = xmlGUIBaseFactory.Invoke();
                    mXMLGUIBase.ParseXML(rootNodeChildNode, rootXMLGUI);

                    AddGUIBase(mXMLGUIBase, rootXMLGUI);
                }
                else
                {
                    Debug.LogWarning("error tag: " + rootNodeChildNode.Name);
                }
            }
        }

        /// <summary>
        /// ע��id
        /// </summary>
        /// <param name="xmlguiBase">GUI�������</param>
        /// <param name="rootXMLGUI">���ڵ����</param>
        private void AddGUIBase(XMLGUIBase xmlguiBase, XMLGUI rootXMLGUI)
        {
            mGUIBases.Add(xmlguiBase);

            if (!string.IsNullOrEmpty(xmlguiBase.Id))
            {
                mGUIBasesForId.Add(xmlguiBase.Id, xmlguiBase);

                if (rootXMLGUI != this)
                {
                    rootXMLGUI.mGUIBasesForId.Add(xmlguiBase.Id, xmlguiBase);
                }
            }
        }
    }
}