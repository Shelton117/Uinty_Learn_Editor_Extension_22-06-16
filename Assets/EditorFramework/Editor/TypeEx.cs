using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EditorFramework.Editor
{
    /// <summary>
    /// 工具类（封装官方方法）
    /// 查找程序集目录
    /// C#反射（https://docs.microsoft.com/zh-cn/dotnet/api/system.appdomain.getassemblies?view=net-6.0）
    /// </summary>
    public static class TypeEx
    {
        /// <summary>
        /// 获取所有路径的结果
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static IEnumerable<Type> GetSubTypesInAssemblies(this Type self)
        {
            // 程序集筛选，之筛选Assembly里的程序集
            // 引擎自带的程序集（基本不会往里面打包程序）过滤掉
            return AppDomain.CurrentDomain.GetAssemblies()
                .Where(assembly => assembly.FullName.StartsWith("Assembly"))
                //.Select(assembly =>
                //{
                //    Debug.Log(assembly.FullName);
                //    return assembly;
                //})
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