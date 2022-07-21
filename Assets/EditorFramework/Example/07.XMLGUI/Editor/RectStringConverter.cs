using UnityEngine;

namespace EditorFramework.Example.XMLGUI.Editor
{
    public class RectStringConverter
    {
        /// <summary>
        /// 处理position="0,0,0,0"格式的标签
        /// </summary>
        /// <param name="rectString"></param>
        /// <returns></returns>
        public static Rect Converter(string rectString)
        {
            var positionChars = rectString.Split(',');

            return new Rect
            {
                
                x = float.Parse(positionChars[0]),
                y = float.Parse(positionChars[1]),
                width = float.Parse(positionChars[2]),
                height = float.Parse(positionChars[3]),
            };
        }
    }
}
