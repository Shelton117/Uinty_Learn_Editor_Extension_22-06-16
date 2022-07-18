using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace EditorExtension.ReorderableListExample.Editor
{
    /// <summary>
    /// ©иеепРап╠М
    /// </summary>
    public class ReorderableListExample : EditorWindow
    {
        [MenuItem("EditorExtension/06.ReorderableList/Open")]
        static void Open()
        {
            GetWindow<ReorderableListExample>().Show();
        }

        private ReorderableList mList;
        private List<Vector2> mData = new List<Vector2>();

        private void OnGUI()
        {
            mList.DoLayoutList();
        }

        private void OnEnable()
        {
            mList = new ReorderableList(mData, typeof(Vector2));
            mList.elementHeight = 40;

            mList.drawHeaderCallback += DrawHeader;
            mList.drawNoneElementCallback += DrawNoneElement;
            mList.drawElementCallback += DrawElement;
            mList.drawElementBackgroundCallback += DrawElementBG;
        }

        private void DrawHeader(Rect rect)
        {
            GUI.Box(rect, "Header");
        }

        private void DrawNoneElement(Rect rect)
        {

        }

        private void DrawElement(Rect rect, int index, bool isActive, bool isFocused)
        {
            mData[index] = EditorGUI.Vector2Field(rect, "Data", mData[index]);
        }

        private void DrawElementBG(Rect rect, int index, bool isActive, bool isFocused)
        {
            GUI.Box(rect, Texture2D.grayTexture);
        }
    }
}