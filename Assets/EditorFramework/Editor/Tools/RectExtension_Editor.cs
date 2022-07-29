using UnityEditor;
using UnityEngine;

namespace EditorFramework.Editor.Tools
{
    /// <summary>
    /// Rect À©Õ¹¡ª¡ª±à¼­Æ÷°æ
    /// </summary>
    public static class RectExtension_Editor
    {
        /// <summary>
        /// Ãè»æÍâ·¢¹â
        /// </summary>
        /// <param name="self">£¬Ãè»æÇøÓò</param>
        /// <param name="width">Ãè»æ¿í¶È</param>
        /// <param name="color">Ãè»æÑÕÉ«</param>
        public static void DrawOutline(this Rect self, float width, Color color)
        {
            Handles.color = color;
            Handles.DrawAAPolyLine(width,
                new Vector3(self.x, self.y, 0),
                new Vector3(self.x, self.yMax, 0),
                new Vector3(self.xMax, self.yMax, 0),
                new Vector3(self.xMax, self.y, 0),
                new Vector3(self.x, self.y, 0)
            );
        }
    }
}