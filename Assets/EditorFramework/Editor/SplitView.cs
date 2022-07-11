using System;
using UnityEditor;
using UnityEngine;

namespace EditorFramework.Editor
{
    public class SplitView : GUIBase
    {
        public event Action<Rect> FirstArea, SecondArea;
        
        public override void OnGUI(Rect position)
        {
            base.OnGUI(position);

            var rects = position.VerticalSplit(200, 4);
            var mid = position.VerticalSplitRect(200, 4);

            // �������
            {
                FirstArea?.Invoke(rects[0]);
            }

            // �ұ�
            {
                SecondArea?.Invoke(rects[1]);
            }

            // �����м�������
            EditorGUI.DrawRect(mid.Zoom(-2, RectExtension.AnchorType.MiddleCenter), Color.gray);
        }

        protected override void OnDispose()
        {
            FirstArea = null;
            SecondArea = null;
        }
    }
}