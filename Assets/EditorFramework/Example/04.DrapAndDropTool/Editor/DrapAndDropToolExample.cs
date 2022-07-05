using EditorFramework.Editor;
using UnityEditor;
using UnityEngine;

namespace EditorFramework.Example.DrapAndDropTool.Editor
{
    /// <summary>
    /// ��קʾ��
    /// </summary>
    [CustomEditorWindow(4)]
    public class DrapAndDropToolExample : EditorWindow
    {
        /// <summary>
        /// ��ק����
        /// </summary>
        private bool enterArea;
        /// <summary>
        /// ���
        /// </summary>
        private bool complete;
        /// <summary>
        /// �����϶�
        /// </summary>
        private bool dragging;

        private void OnGUI()
        {
            var mRect = new Rect(10, 10, 300, 300);
            GUI.Box(mRect, "Drap anything");

            var info = EditorFramework.Editor.DrapAndDropTool.Drag(Event.current, mRect);

            if (info.enterArea && info.complete && !info.dragging)
            {
                // ��ק��ɵ��¼�
                // ·��
                foreach (var path in info.paths)
                {
                    Debug.Log(path);
                }

                // ����
                foreach (var objectReference in info.objectReferences)
                {
                    Debug.Log(objectReference);
                }
            }
        }
    }
}