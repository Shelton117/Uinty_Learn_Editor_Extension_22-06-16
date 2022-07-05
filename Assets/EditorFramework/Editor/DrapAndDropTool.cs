using UnityEditor;
using UnityEngine;

namespace EditorFramework.Editor
{
    /// <summary>
    /// ��ק���� ��
    /// </summary>
    public static class DrapAndDropTool
    {
        /// <summary>
        /// ���ص���ק��Ϣ
        /// </summary>
        public class DragInfo
        {
            /// <summary>
            /// ��ק����
            /// </summary>
            public bool enterArea;
            /// <summary>
            /// ���
            /// </summary>
            public bool complete;
            /// <summary>
            /// �����϶�
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
            // ������ק�¼�
            // var e = Event.current;
            if (e.type == EventType.DragUpdated)
            {
                mEnterArea = content.Contains(e.mousePosition);
                mComplete = false;
                mDragging = true;

                // ��ק�����Ѹ��£����ޱ༭��
                if (mEnterArea)
                {
                    DragAndDrop.visualMode = DragAndDropVisualMode.Generic;
                    e.Use();
                }
            }
            else if (e.type == EventType.DragPerform)
            {
                // ��ʼ(��Ч)�����ϷŲ�����ͬ��
                mEnterArea = content.Contains(e.mousePosition);
                mComplete = true;
                mDragging = false;

                DragAndDrop.AcceptDrag();
                e.Use();
            }
            else if (e.type == EventType.DragExited)
            {
                // ��ק������ͬ��
                mEnterArea = content.Contains(e.mousePosition);
                mComplete = true;
                mDragging = false;
            }
            else
            {
                // ����
                mEnterArea = content.Contains(e.mousePosition);
                mComplete = false;
                mDragging = false;
            }

            // ���������ק��״̬��EventType.Used
            mInfo.complete = mComplete && e.type == EventType.Used;
            mInfo.enterArea = mEnterArea;
            mInfo.dragging = mDragging;

            return mInfo;
        }
    }
}