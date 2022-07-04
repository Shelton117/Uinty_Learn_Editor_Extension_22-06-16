using System;

namespace EditorFramework.Editor
{
    public class CustomEditorWindowAttribute : Attribute
    {
        /// <summary>
        /// ≈≈–Ú”√µƒ Ù–‘
        /// </summary>
        public int RenderOrder { get; private set; }

        public CustomEditorWindowAttribute(int order = -1)
        {
            RenderOrder = order;
        }
    }
}

