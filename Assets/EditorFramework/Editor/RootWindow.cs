using System;
using System.Collections;
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
            var editorWindowType = typeof(EditorWindow);
            var m_Parent = editorWindowType.GetField("m_Parent", BindingFlags.Instance | BindingFlags.NonPublic);

            // C#·´Éä£¨https://docs.microsoft.com/zh-cn/dotnet/api/system.appdomain.getassemblies?view=net-6.0£©
            mEditorWindowTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.IsSubclassOf(editorWindowType));
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

