using System;
using System.Collections.Generic;
using System.Reflection;
using EditorFramework.Editor;
using UnityEditor;
using UnityEngine;

namespace EditorFramework.Example.TypeEx.Editor
{
    [CustomEditorWindow((int)ExampleIndex.TypeEx)]
    public class TypeExExample : EditorWindow
    {
        public class DescriptionBase
        {
            public virtual string Description { get; set; }
        }

        public class MyDescription : DescriptionBase
        {
            public override string Description { get; set; } = "这是一个描述";
        }

        [MyDesc("TypeB")]
        public class MyDescriptionB : DescriptionBase
        {
            public override string Description { get; set; } = "这是一个描述B";
        }

        public class MyDescAttribute : Attribute
        {
            public string Type;

            public MyDescAttribute(string type = "")
            {
                Type = type;
            }
        }

        /// <summary>
        /// 所有子类
        /// </summary>
        private IEnumerable<Type> mDescriptionTypes;

        /// <summary>
        /// Attribute过滤出来的结果
        /// </summary>
        private IEnumerable<Type> mDescriptionTypesWithAttribute;

        private void OnEnable()
        {
            mDescriptionTypes = typeof(DescriptionBase).GetSubTypesInAssemblies();
            mDescriptionTypesWithAttribute =
                typeof(DescriptionBase).GetSubTypesWithClassAttributeInAssemblies<MyDescAttribute>();
        }

        private void OnGUI()
        {
            foreach (var descriptionType in mDescriptionTypes)
            {
                GUILayout.BeginHorizontal("box");
                {
                    GUILayout.Label(descriptionType.Name);
                }
                GUILayout.EndHorizontal();
            }

            GUILayout.Label("With Attr");

            foreach (var type in mDescriptionTypesWithAttribute)
            {
                GUILayout.BeginHorizontal("box");
                {
                    GUILayout.Label(type.Name);
                    GUILayout.Label(type.GetCustomAttribute<MyDescAttribute>().Type);
                }
                GUILayout.EndHorizontal();
            }
        }
    }
}