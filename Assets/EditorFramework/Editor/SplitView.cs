using System;
using UnityEditor;
using UnityEngine;

namespace EditorFramework.Editor
{
    /// <summary>
    /// 可拖拽的窗口
    /// 默认为横向分割，数量为二
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
        public float MiniSize = 100; // 最小尺寸等于0会怎样
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

            // 左边区域/上边
            {
                FirstArea?.Invoke(rects[0]);
            }

            // 右边/下边
            {
                SecondArea?.Invoke(rects[1]);
            }

            // 绘制中间那条缝
            EditorGUI.DrawRect(mid.Zoom(-2, RectExtension.AnchorType.MiddleCenter), Color.gray);

            var e = Event.current;
            if (mid.Contains(e.mousePosition))
            {
                if (SplitType == RectExtension.SplitType.Vertical)
                {
                    EditorGUIUtility.AddCursorRect(mid, MouseCursor.ResizeHorizontal); // 添加选中对象，鼠标变更
                }
                else
                {
                    EditorGUIUtility.AddCursorRect(mid, MouseCursor.ResizeVertical); // 添加选中对象，鼠标变更
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