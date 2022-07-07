using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EditorFramework.Editor
{
    /// <summary>
    /// �����ࣨ��װ�ٷ�������
    /// ���ҳ���Ŀ¼
    /// C#���䣨https://docs.microsoft.com/zh-cn/dotnet/api/system.appdomain.getassemblies?view=net-6.0��
    /// </summary>
    public static class TypeEx
    {
        /// <summary>
        /// ��ȡ����·���Ľ��
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static IEnumerable<Type> GetSubTypesInAssemblies(this Type self)
        {
            // ����ɸѡ��֮ɸѡAssembly��ĳ���
            // �����Դ��ĳ��򼯣��������������������򣩹��˵�
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