using UnityEngine;

namespace EditorFramework.Editor
{
    /// <summary>
    /// Rect����̬����չ
    /// </summary>
    public static class RectExtension
    {
        /// <summary>
        /// ê��ö��
        /// </summary>
        public enum AnchorType
        {
            UpperLeft = 0,
            UpperCenter = 1,
            UpperRight = 2,
            MiddleLeft = 3,
            MiddleCenter = 4,
            MiddleRight = 5,
            LowerLeft = 6,
            LowerCenter = 7,
            LowerRight = 8,
        }
        
        /// <summary>
        /// ����ê�㴴���߾�
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="anchorType"></param>
        /// <param name="pixel"></param>
        /// <returns></returns>
        public static Rect Zoom(this Rect rect, float pixel, AnchorType anchorType = AnchorType.UpperLeft)
        {
            var width = rect.width + pixel;
            var heigh = rect.height + pixel;

            switch (anchorType)
            {
                case AnchorType.MiddleCenter:
                    rect.x -= pixel * 0.5f;
                    rect.y -= pixel * 0.5f;
                    break;
            }
            
            rect.width = width;
            rect.height = heigh;

            return rect;
        }

        /// <summary>
        /// ��ȡ�м�ָ�����
        /// </summary>
        /// <param name="self">��ǰ�ָ������</param>
        /// <param name="width">��</param>
        /// <param name="padding">�ָ���</param>
        /// <returns></returns>
        public static Rect VerticalSplitRect(this Rect self, float width, float padding = 0)
        {
            var rect = self.CutRight(self.width - width).CutRight(padding).CutRight(-Mathf.CeilToInt(padding / 2f));
            rect.x += rect.width;
            rect.width = padding;
            return rect;
        }

        #region �ָ� rect

        /// <summary>
        /// �ָ�rect
        /// ��ֱ
        /// </summary>
        /// <param name="self">��ǰ�ָ������</param>
        /// <param name="width">��</param>
        /// <param name="padding">���</param>
        /// <param name="justMid">�Ƿ����</param>
        /// <returns></returns>
        public static Rect[] VerticalSplit(this Rect self, float width, float padding = 0, bool justMid = true)
        {
            var i = -Mathf.CeilToInt(padding / 2);

            if (justMid)
            {
                return new Rect[2]
                {
                    self.CutRight(self.width - width).CutRight(padding).CutRight(i),
                    self.CutLeft(width).CutLeft(padding).CutLeft(i)
                };
            }

            // TODO:�����е����
            return new Rect[2]
            {
                new Rect(),
                new Rect()
            };
        }
        
        /// <summary>
        /// �ָ�rect
        /// ˮƽ
        /// </summary>
        /// <param name="self"></param>
        /// <param name="width"></param>
        /// <param name="padding"></param>
        /// <param name="justMid"></param>
        /// <returns></returns>
        public static Rect[] HorizontalSplit(this Rect self, float width, float padding = 0, bool justMid = true)
        {
            var i = -Mathf.CeilToInt(padding / 2);

            if (justMid)
            {
                return new Rect[2]
                {
                    self.CutTop(self.width - width).CutTop(padding).CutTop(i),
                    self.CutBottom(width).CutBottom(padding).CutBottom(i)
                };
            }

            return new Rect[2]
            {
                new Rect(),
                new Rect()
            };
        }


        public static Rect CutRight(this Rect self, float pixels)
        {
            self.xMax -= pixels;
            return self;
        }

        public static Rect CutLeft(this Rect self, float pixels)
        {
            self.xMin += pixels;
            return self;
        }

        public static Rect CutTop(this Rect self, float pixels)
        {
            self.yMin += pixels;
            return self;
        }

        public static Rect CutBottom(this Rect self, float pixels)
        {
            self.yMax -= pixels;
            return self;
        }
        
        #endregion
    }
}