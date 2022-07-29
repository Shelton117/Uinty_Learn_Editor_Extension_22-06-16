using UnityEditor;
using UnityEngine;

namespace EditorFramework.Editor.Tools
{
    /// <summary>
    /// Rect ��չ�����༭����
    /// </summary>
    public static class RectExtension_Editor
    {
        /// <summary>
        /// ����ⷢ��
        /// </summary>
        /// <param name="self">���������</param>
        /// <param name="width">�����</param>
        /// <param name="color">�����ɫ</param>
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