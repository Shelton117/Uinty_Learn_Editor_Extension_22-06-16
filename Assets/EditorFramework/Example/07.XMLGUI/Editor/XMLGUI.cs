using System;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

namespace EditorFramework.Example.XMLGUI.Editor
{
    /// <summary>
    /// 组件处理、绘制
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
        /// 绘制GUI的方法
        /// </summary>
        public void Draw()
        {
            foreach (var guiBase in mGUIBases)
            {
                guiBase.Draw();
            }
        }

        /// <summary>
        /// 抽象工厂管理xml标签转化成对应的GUI组件
        /// </summary>
        private Dictionary<string, Func<XMLGUIBase>> mFactoriesForGUIBaseNames =
            new Dictionary<string, Func<XMLGUIBase>>()
            {
                {"Label", () => new XMLGUILabel()},
                {"TextField", () => new XMLGUITextField()},
                {"TextArea", () => new XMLGUITextArea()},
                {"Button", () => new XMLGUIButton()},

                {"LayoutLabel", () => new XMLGUILayoutLabel()}, 
                {"LayoutButton", () => new XMLGUILayoutButton()}, // 例子后续略 TODO:兼容GUI

                {"LayoutHorizontal", () => new XMLGUILayoutHorizontal()},
                {"LayoutVertical", () => new XMLGUILayoutVertical()},
            };

        public void ReadXML(string xml)
        {
            // 每次渲染之前需要反序列化操作
            var doc = new XmlDocument();
            doc.LoadXml(xml);
            var rootNode = doc.SelectSingleNode("GUI");

            // GUI 标签才是根节点
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
        /// 注册id
        /// </summary>
        /// <param name="xmlguiBase">GUI组件对象</param>
        /// <param name="rootXMLGUI">根节点对象</param>
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