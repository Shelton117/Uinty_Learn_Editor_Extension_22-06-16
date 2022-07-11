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
            public override string Description { get; set; } = "����һ������";
        }

        [MyDesc("TypeB")]
        public class MyDescriptionB : DescriptionBase
        {
            public override string Description { get; set; } = "����һ������B";
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
        /// ��������
        /// </summary>
        private IEnumerable<Type> mDescriptionTypes;

        /// <summary>
        /// Attribute���˳����Ľ��
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