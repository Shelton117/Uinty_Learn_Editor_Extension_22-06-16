using System;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace EditorFramework.Editor
{
    public class RootWindow : EditorWindow
    {
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
            var editorWindowTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.IsSubclassOf(editorWindowType));

            foreach (var windowType in editorWindowTypes)
            {
                Debug.Log(windowType.Name);
            }
        }
    }
}

