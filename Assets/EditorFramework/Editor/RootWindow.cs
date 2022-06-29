using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace EditorFramework.Editor
{
    public class RootWindow : EditorWindow
    {
        private IEnumerable<Type> mEditorWindowTypes;

        [MenuItem("EditorFramework/Open %#e")]
        private static void Open()
        {
            GetWindow<RootWindow>().Show();
        }

        private void OnEnable()
        {
            var m_Parent = typeof(EditorWindow).GetField("m_Parent", BindingFlags.Instance | BindingFlags.NonPublic);

            // ������д����������ƵĽӿ�
            mEditorWindowTypes = typeof(EditorWindow).GetSubTypesWithClassAttributeInAssemblies<CustomEditorWindowAttribute>(); // ���Զ���Ĵ���
        }

        private void OnGUI()
        {
            foreach (var mEditorWindowType in mEditorWindowTypes)
            {
                GUILayout.BeginHorizontal("box");
                {
                    GUILayout.Label(mEditorWindowType.Name);
                    if (GUILayout.Button("Open", GUILayout.Width(80)))
                    {
                        GetWindow(mEditorWindowType).Show();
                    }
                }
                GUILayout.EndHorizontal();
            }
        }
    }
}

