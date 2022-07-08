using System;
using UnityEditor;
using UnityEngine;

namespace EditorExtension.HierarchyExample.Editor
{
    /// <summary>
    /// Hierarchy 拓展
    /// </summary>
    [InitializeOnLoad]
    public static class HierarchyExample
    {
        static HierarchyExample()
        {
            Menu.SetChecked(PATH, mCustomHierarchyEnable);
        }

        private static bool mCustomHierarchyEnable = false;
        private const string PATH = "EditorExtension/02.IMGUI/03.Enable Custom Hierarchy";

        [MenuItem(PATH)]
        private static void EnableCustomHierarchy()
        {
            if (mCustomHierarchyEnable)
            {
                mCustomHierarchyEnable = false;
                UnregisterHierarchy();
            }
            else
            {
                mCustomHierarchyEnable = true;
                RegisterHierarchy();
            }

            Menu.SetChecked(PATH, mCustomHierarchyEnable);

            // 重新绘制Hierarchy窗口
            EditorApplication.RepaintHierarchyWindow();
        }

        private static void RegisterHierarchy()
        {
            EditorApplication.hierarchyWindowItemOnGUI += OnHierarchyGUI;
            EditorApplication.hierarchyChanged += OnHierarchyChanged;
        }
        
        private static void UnregisterHierarchy()
        {
            EditorApplication.hierarchyWindowItemOnGUI -= OnHierarchyGUI;
            EditorApplication.hierarchyChanged -= OnHierarchyChanged;
        }

        /// <summary>
        /// 渲染一下在hierarchy中拓展的内容
        /// </summary>
        /// <param name="instanceID">实例ID</param>
        /// <param name="selectionRect">选择位置</param>
        private static void OnHierarchyGUI(int instanceID, Rect selectionRect)
        {
            var obj = EditorUtility.InstanceIDToObject(instanceID) as GameObject;

            if (obj)
            {
                var tagLabelRect = selectionRect;
                tagLabelRect.x += 120;
                GUI.Label(tagLabelRect, obj.tag);

                var layerLabelRect = tagLabelRect;
                layerLabelRect.x += 120;
                GUI.Label(layerLabelRect, LayerMask.LayerToName(obj.layer));
            }
        }

        /// <summary>
        /// Hierarchy发生(任何)改变时调用
        /// </summary>
        private static void OnHierarchyChanged()
        {
            Debug.Log("HierarchyChanged");
        }
    }
}