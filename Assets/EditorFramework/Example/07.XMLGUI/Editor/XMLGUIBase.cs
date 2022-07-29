using System.Xml;
using EditorFramework.Editor.StringConverter;
using UnityEngine;

namespace EditorFramework.Example.XMLGUI.Editor
{
    public abstract class XMLGUIBase : EditorFramework.Editor.GUI.Base.GUIBase
    {
        public string Id { get; set; }

        protected T GetAttributeValue<T>(XmlElement xmlElement, string attributeName)
        {
            var attributeValue = xmlElement.GetAttribute(attributeName);

            if (!string.IsNullOrEmpty(attributeValue))
            {
                T result = default;
                if (attributeValue.TryConvert<T>(out result))
                {
                    return result;
                }
            }
            

            return default;
        }

        public Rect rect
        {
            get { return mPosition; }
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
            Id = GetAttributeValue<string>(xmlElement, "id");

            //var width = !string.IsNullOrEmpty(xmlElement.GetAttribute("width"))
            //    ? float.Parse(xmlElement.GetAttribute("width"))
            //    : 0;
            var width = GetAttributeValue<float>(xmlElement, "width") == 0
                ? 100
                : GetAttributeValue<float>(xmlElement, "width");
            var height = GetAttributeValue<float>(xmlElement, "height") == 0
                ? 40
                : GetAttributeValue<float>(xmlElement, "height");
            var x = GetAttributeValue<float>(xmlElement, "x");
            var y = GetAttributeValue<float>(xmlElement, "y");

            //var id = xmlElement.GetAttribute("id");

            //if (!string.IsNullOrEmpty(id))
            //{
            //    Id = id;
            //}

            rect = new Rect(x, y, width, height);
        }
    }
}