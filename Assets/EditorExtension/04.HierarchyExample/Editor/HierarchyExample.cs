using System;
using UnityEditor;
using UnityEngine;

namespace EditorExtension.HierarchyExample.Editor
{
    /// <summary>
    /// Hierarchy ��չ
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

            // ���»���Hierarchy����
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
        /// ��Ⱦһ����hierarchy����չ������
        /// </summary>
        /// <param name="instanceID">ʵ��ID</param>
        /// <param name="selectionRect">ѡ��λ��</param>
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
        /// Hierarchy����(�κ�)�ı�ʱ����
        /// </summary>
        private static void OnHierarchyChanged()
        {
            Debug.Log("HierarchyChanged");
        }
    }
}