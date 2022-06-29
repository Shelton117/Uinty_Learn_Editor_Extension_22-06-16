using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EditorFramework.Editor
{
    public static class TypeEx
    {
        /// <summary>
        /// 获取所有路径的结果
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static IEnumerable<Type> GetSubTypesInAssemblies(this Type self)
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.IsSubclassOf(self));
        }

        /// <summary>
        /// 根据TClassAttribute 筛选
        /// </summary>
        /// <typeparam name="TClassAttribute">筛选类型</typeparam>
        /// <param name="self"></param>
        /// <returns></returns>
        public static IEnumerable<Type> GetSubTypesWithClassAttributeInAssemblies<TClassAttribute>(this Type self) 
            where TClassAttribute : Attribute
        {
            return GetSubTypesInAssemblies(self)
                .Where(type => type.GetCustomAttribute<TClassAttribute>() != null);
        }
    }
}