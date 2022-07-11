using System;
using UnityEditor;
using UnityEngine;

namespace EditorFramework.Editor
{
    /// <summary>
    /// ����ק�Ĵ���
    /// Ĭ��Ϊ����ָ����Ϊ��
    /// </summary>
    public class SplitView : GUIBase
    {
        public SplitView(RectExtension.SplitType splitType = RectExtension.SplitType.Vertical)
        {
            SplitType = splitType;
        }

        private RectExtension.SplitType SplitType = RectExtension.SplitType.Horizontal;
        public event Action<Rect> FirstArea, SecondArea;
        public event Action OnBeginResize, OnEndResize;
        public float SplitSize = 200;
        public float MiniSize = 100; // ��С�ߴ����0������
        public float SplitPadding = 4;

        public bool Dragging
        {
            get { return mResizing; }
            set {
                if (mResizing != value)
                {
                    mResizing = value;

                    if (value)
                    {
                        OnBeginResize?.Invoke();
                    }
                    else
                    {
                        OnEndResize?.Invoke();
                    }
                }
            }
        }

        private bool mResizing;

        public override void OnGUI(Rect position)
        {
            base.OnGUI(position);

            var rects = position.Split(SplitType, SplitSize, SplitPadding);
            var mid = position.SplitRect(SplitType, SplitSize, SplitPadding);

            // �������/�ϱ�
            {
                FirstArea?.Invoke(rects[0]);
            }

            // �ұ�/�±�
            {
                SecondArea?.Invoke(rects[1]);
            }

            // �����м�������
            EditorGUI.DrawRect(mid.Zoom(-2, RectExtension.AnchorType.MiddleCenter), Color.gray);

            var e = Event.current;
            if (mid.Contains(e.mousePosition))
            {
                if (SplitType == RectExtension.SplitType.Vertical)
                {
                    EditorGUIUtility.AddCursorRect(mid, MouseCursor.ResizeHorizontal); // ���ѡ�ж��������
                }
                else
                {
                    EditorGUIUtility.AddCursorRect(mid, MouseCursor.ResizeVertical); // ���ѡ�ж��������
                }
                
            }

            switch (e.type)
            {
                case EventType.MouseDown:
                    if (mid.Contains(e.mousePosition))
                    {
                        Dragging = true;
                    }
                    break;
                case EventType.MouseDrag:
                    if (Dragging)
                    {
                        if (SplitType == RectExtension.SplitType.Vertical)
                        {
                            SplitSize += e.delta.x;
                            SplitSize = Mathf.Clamp(SplitSize, MiniSize, position.width - MiniSize);
                        }
                        else
                        {
                            SplitSize += e.delta.y;
                            SplitSize = Mathf.Clamp(SplitSize, MiniSize, position.height - MiniSize);
                        }
                        
                        e.Use();
                    }
                    break;
                case EventType.MouseUp:
                    if (Dragging)
                    {
                        Dragging = false;
                    }
                    break;
            }
        }

        protected override void OnDispose()
        {
            FirstArea = null;
            SecondArea = null;

            OnBeginResize = null;
            OnEndResize = null;
        }
    }
}