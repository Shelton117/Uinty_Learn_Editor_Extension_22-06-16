using UnityEditor;
using UnityEngine;

namespace EditorFramework.Editor
{
    /// <summary>
    /// 拖拽工具 类
    /// </summary>
    public static class DrapAndDropTool
    {
        /// <summary>
        /// 返回的拖拽信息
        /// </summary>
        public class DragInfo
        {
            /// <summary>
            /// 拖拽区域
            /// </summary>
            public bool enterArea;
            /// <summary>
            /// 完成
            /// </summary>
            public bool complete;
            /// <summary>
            /// 正在拖动
            /// </summary>
            public bool dragging;

            public Object[] objectReferences => DragAndDrop.objectReferences;
            public string[] paths => DragAndDrop.paths;
            public DragAndDropVisualMode visualMode => DragAndDrop.visualMode;
            public int activeControlID => DragAndDrop.activeControlID;
        }

        private static DragInfo mInfo = new DragInfo();

        private static bool mEnterArea;
        private static bool mComplete;
        private static bool mDragging;

        public static DragInfo Drag(Event e, Rect content, DragAndDropVisualMode mode = DragAndDropVisualMode.Generic)
        {
            // 监听拖拽事件
            // var e = Event.current;
            if (e.type == EventType.DragUpdated)
            {
                mEnterArea = content.Contains(e.mousePosition);
                mComplete = false;
                mDragging = true;

                // 拖拽操作已更新，仅限编辑器
                if (mEnterArea)
                {
                    DragAndDrop.visualMode = DragAndDropVisualMode.Generic;
                    e.Use();
                }
            }
            else if (e.type == EventType.DragPerform)
            {
                // 开始(生效)接收拖放操作，同上
                mEnterArea = content.Contains(e.mousePosition);
                mComplete = true;
                mDragging = false;

                DragAndDrop.AcceptDrag();
                e.Use();
            }
            else if (e.type == EventType.DragExited)
            {
                // 拖拽结束，同上
                mEnterArea = content.Contains(e.mousePosition);
                mComplete = true;
                mDragging = false;
            }
            else
            {
                // 其他
                mEnterArea = content.Contains(e.mousePosition);
                mComplete = false;
                mDragging = false;
            }

            // 更新完成拖拽的状态，EventType.Used
            mInfo.complete = mComplete && e.type == EventType.Used;
            mInfo.enterArea = mEnterArea;
            mInfo.dragging = mDragging;

            return mInfo;
        }
    }
}