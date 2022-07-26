using System.Xml;
using UnityEngine;

namespace EditorFramework.Example.XMLGUI.Editor
{
    public abstract class XMLGUIBase : EditorFramework.Editor.GUIBase
    {
        public string Id { get; set; }

        protected T GetAttributeValue<T>(XmlElement xmlElement, string attributeName)
        {
            var attributeValue = xmlElement.GetAttribute(attributeName);

            if (string.IsNullOrEmpty(attributeValue))
            {
                T result;
                if (attributeValue.TryConvert<T>(out result))
                {
                    return result;
                }
            }
            

            return default;
        }

        public Rect rect
        {
            set { mPosition = value; }
        }

        public void Draw()
        {
            OnGUI(mPosition);
        }

        /// <summary>
        /// 解析字符串的内容
        /// </summary>
        /// <param name="xmlElement">xml标签内的值以及标签里的属性</param>
        public virtual void ParseXML(XmlElement xmlElement, XMLGUI rootXMLGUI)
        {
            var id = xmlElement.GetAttribute("id");

            var width = !string.IsNullOrEmpty(xmlElement.GetAttribute("width"))
                ? float.Parse(xmlElement.GetAttribute("width"))
                : 0;
            var height = !string.IsNullOrEmpty(xmlElement.GetAttribute("height"))
                ? float.Parse(xmlElement.GetAttribute("height"))
                : 0;
            var x = !string.IsNullOrEmpty(xmlElement.GetAttribute("x"))
                ? float.Parse(xmlElement.GetAttribute("x"))
                : 0;
            var y = !string.IsNullOrEmpty(xmlElement.GetAttribute("y"))
                ? float.Parse(xmlElement.GetAttribute("y"))
                : 0;

            if (!string.IsNullOrEmpty(id))
            {
                Id = id;
            }

            rect = new Rect(x, y, width, height);
        }
    }
}