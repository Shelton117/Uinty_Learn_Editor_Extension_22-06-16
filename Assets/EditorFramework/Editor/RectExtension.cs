using UnityEngine;

namespace EditorFramework.Editor
{
    /// <summary>
    /// Rect£¨¾²Ì¬£©À©Õ¹
    /// </summary>
    public static class RectExtension
    {
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
    }
}