using UnityEditor;
using UnityEngine;

namespace EditorFramework.Editor
{
    /// <summary>
    /// �༭�����ڹ��� ��
    /// </summary>
    public static class EditorWindowTool
    {
        public static Rect LocalPostion(this EditorWindow self)
        {
            return new Rect(Vector2.zero, self.position.size);
        }
    }
}