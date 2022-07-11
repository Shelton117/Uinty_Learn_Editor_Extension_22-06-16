using UnityEngine;

namespace EditorFramework.Editor
{
    /// <summary>
    /// Rect（静态）扩展
    /// </summary>
    public static class RectExtension
    {
        /// <summary>
        /// 锚点枚举
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
        /// 根据锚点创建边距
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
        /// 获取中间分割区域
        /// </summary>
        /// <param name="self">当前分割的区域</param>
        /// <param name="width">宽</param>
        /// <param name="padding">分割间距</param>
        /// <returns></returns>
        public static Rect VerticalSplitRect(this Rect self, float width, float padding = 0)
        {
            var rect = self.CutRight(self.width - width).CutRight(padding).CutRight(-Mathf.CeilToInt(padding / 2f));
            rect.x += rect.width;
            rect.width = padding;
            return rect;
        }

        #region 分割 rect

        /// <summary>
        /// 分割rect
        /// 垂直
        /// </summary>
        /// <param name="self">当前分割的区域</param>
        /// <param name="width">宽</param>
        /// <param name="padding">间距</param>
        /// <param name="justMid">是否居中</param>
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

            // TODO:不居中的情况
            return new Rect[2]
            {
                new Rect(),
                new Rect()
            };
        }
        
        /// <summary>
        /// 分割rect
        /// 水平
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