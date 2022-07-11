using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace EditorExtension.ProjectExample.GUI.Editor
{
    [InitializeOnLoad]
    public static class ProjectExample
    {
        static ProjectExample()
        {
            Menu.SetChecked(PATH, mCustomProjectEnable);
        }

        private const string PATH = "EditorExtension/02.IMGUI/04.Enable Custom Project";
        private static bool mCustomProjectEnable = false;

        [MenuItem(PATH)]
        private static void EnableCustomProject()
        {
            if (mCustomProjectEnable)
            {
                mCustomProjectEnable = false;
                UnregisterProject();
            }
            else
            {
                mCustomProjectEnable = true;
                RegisterProject();
            }

            Menu.SetChecked(PATH, mCustomProjectEnable);

            EditorApplication.RepaintProjectWindow();

            // ProjectWindowUtil.XXX Project窗口的一些操作与接口方法
        }

        private static void RegisterProject()
        {
            EditorApplication.projectWindowItemOnGUI += OnProjectGUI;
            EditorApplication.projectChanged += OnProjectChanged;
        }

        private static void UnregisterProject()
        {
            EditorApplication.projectWindowItemOnGUI -= OnProjectGUI;
            EditorApplication.projectChanged -= OnProjectChanged;
        }

        private static void OnProjectGUI(string guid, Rect selectionRect)
        {
            try
            {
                var assetPath = UnityEditor.AssetDatabase.GUIDToAssetPath(guid);
                var files = Directory.GetFiles(assetPath);
                var countLabelRect = selectionRect;
                countLabelRect.x = 300;
                UnityEngine.GUI.Label(countLabelRect,
                    files.Length % 2 == 0 ? (files.Length / 2).ToString() : files.Length.ToString());
            }
            catch (Exception e)
            {
                
            }
            
        }

        private static void OnProjectChanged()
        {
            throw new NotImplementedException();
        }
    }
}