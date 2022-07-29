using System;
using System.Collections.Generic;
using UnityEngine;

namespace EditorFramework.Editor.StringConverter
{
    public abstract class StringConverter
    {
        private static Dictionary<Type, StringConverter> mConverterMap = new Dictionary<Type, StringConverter>()
        {
            {typeof(Rect), new RectStringConverter()},
            {typeof(string), new StringStringConverter()},
            {typeof(float), new FloatStringConverter()},
            {typeof(bool), new BooleanStringConverter()},

        };

        public static StringConverter<T> Get<T>()
        {
            StringConverter t = default;

            if (mConverterMap.TryGetValue(typeof(T), out t))
            {
                return t as StringConverter<T>;
            }

            return default;
        }
    }

    /// <summary>
    /// 实现接口的类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class StringConverter<T> : StringConverter
    {
        public virtual string Convert2String(T t)
        {
            return t.ToString();
        }

        public abstract bool TryConvert(string self, out T result);
    }
}