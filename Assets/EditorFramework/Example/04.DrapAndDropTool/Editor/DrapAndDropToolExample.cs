using EditorFramework.Editor;
using UnityEditor;
using UnityEngine;

namespace EditorFramework.Example.DrapAndDropTool.Editor
{
    /// <summary>
    /// 拖拽示例
    /// </summary>
    [CustomEditorWindow(4)]
    public class DrapAndDropToolExample : EditorWindow
    {
        /// <summary>
        /// 拖拽区域
        /// </summary>
        private bool enterArea;
        /// <summary>
        /// 完成
        /// </summary>
        private bool complete;
        /// <summary>
        /// 正在拖动
        /// </summary>
        private bool dragging;

        private void OnGUI()
        {
            var mRect = new Rect(10, 10, 300, 300);
            GUI.Box(mRect, "Drap anything");

            var info = EditorFramework.Editor.DrapAndDropTool.Drag(Event.current, mRect);

            if (info.enterArea && info.complete && !info.dragging)
            {
                // 拖拽完成的事件
                // 路径
                foreach (var path in info.paths)
                {
                    Debug.Log(path);
                }

                // 引用
                foreach (var objectReference in info.objectReferences)
                {
                    Debug.Log(objectReference);
                }
            }
        }
    }
}