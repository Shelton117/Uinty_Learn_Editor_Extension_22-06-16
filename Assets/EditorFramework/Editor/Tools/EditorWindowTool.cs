using UnityEditor;
using UnityEngine;

namespace EditorFramework.Editor.Tools
{
    /// <summary>
    /// 编辑器窗口工具 类
    /// </summary>
    public static class EditorWindowTool
    {
        public static Rect LocalPostion(this EditorWindow self)
        {
            return new Rect(Vector2.zero, self.position.size);
        }
    }
}