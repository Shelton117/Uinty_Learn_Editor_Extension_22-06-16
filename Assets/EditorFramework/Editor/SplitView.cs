using System;
using UnityEngine;

namespace EditorFramework.Editor
{
    public class SplitView : GUIBase
    {
        public event Action<Rect> FirstArea, SecondArea;

        public override void Dispose()
        {
            base.Dispose();
        }

        public override void OnGUI(Rect position)
        {
            base.OnGUI(position);

            var rects = position.VerticalSplit(200, 4);

            // �������
            {
                FirstArea?.Invoke(rects[0]);
            }

            // �ұ�
            {
                SecondArea?.Invoke(rects[1]);
            }
        }

        protected override void OnDispose()
        {
            throw new System.NotImplementedException();
        }
    }
}