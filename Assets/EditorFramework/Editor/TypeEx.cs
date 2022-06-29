using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EditorFramework.Editor
{
    public static class TypeEx
    {
        /// <summary>
        /// ��ȡ����·���Ľ��
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
        /// ����TClassAttribute ɸѡ
        /// </summary>
        /// <typeparam name="TClassAttribute">ɸѡ����</typeparam>
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