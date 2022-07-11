using System;

namespace EditorFramework.Editor
{
    /// <summary>
    /// 自定义编辑器扩展属性
    /// 标记
    /// </summary>
    public class CustomEditorWindowAttribute : Attribute
    {
        /// <summary>
        /// 排序用的属性
        /// </summary>
        public int RenderOrder { get; private set; }

        public CustomEditorWindowAttribute(int order = -1)
        {
            RenderOrder = order;
        }
    }
}

