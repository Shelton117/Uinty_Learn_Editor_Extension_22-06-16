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
            var editorWindowType = typeof(EditorWindow);
            var m_Parent = editorWindowType.GetField("m_Parent", BindingFlags.Instance | BindingFlags.NonPublic);

            // TODO：C#反射（https://docs.microsoft.com/zh-cn/dotnet/api/system.appdomain.getassemblies?view=net-6.0）
            // 获得所有窗口类型名称的接口
            mEditorWindowTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.IsSubclassOf(editorWindowType)) // 打开全部窗口
                .Where(type => type.GetCustomAttribute<CustomEditorWindowAttribute>() != null); // 打开自定义的窗口
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

