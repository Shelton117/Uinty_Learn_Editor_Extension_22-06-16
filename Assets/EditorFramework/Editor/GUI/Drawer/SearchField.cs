using System;
using System.Reflection;
using EditorFramework.Editor.GUI.Base;
using UnityEditor;
using UnityEngine;

namespace EditorFramework.Editor.GUI.Drawer
{
    public class SearchField : GUIBase
    {
        private string mSearchContent;
        private string[] mSearchableContents;
        private int mContentInex;
        private MethodInfo mDrawAPI;

        private int mControlId;

        public event Action<int> OnModeChanged;
        public event Action<string> OnValueChanged;
        public event Action<string> OnEndEdit;

        public SearchField(string searchContent, string[] searchableContents, int contentInex)
        {
            mSearchContent = searchContent;
            mSearchableContents = searchableContents;
            mContentInex = contentInex;

            // 反射获取内部api？
            mDrawAPI = typeof(EditorGUI).GetMethod(
                 "ToolbarSearchField",
                 BindingFlags.NonPublic | BindingFlags.Static,
                 null,
                 new Type[]
                 {
                    typeof(int),
                    typeof(Rect),
                    typeof(string[]),
                    typeof(int).MakeByRefType(),
                    typeof(string),
                 },
                 null);
        }

        public override void OnGUI(Rect position)
        {
            base.OnGUI(position);

            if (mDrawAPI != null)
            {
                mControlId = GUIUtility.GetControlID("EditorSearchField".GetHashCode(),
                    FocusType.Keyboard,
                    position);

                int mode = mContentInex;
                object[] args = new object[] {mControlId, position, mSearchableContents, mode, mSearchContent};
                string newSearchableContent = mDrawAPI.Invoke(null, args) as string;

                if ((int)args[3] != mContentInex)
                {
                    mContentInex = (int)args[3];
                    OnModeChanged?.Invoke(mContentInex);
                }

                if (newSearchableContent != mSearchContent)
                {
                    mSearchContent = newSearchableContent;
                    OnValueChanged?.Invoke(mSearchContent);
                }

                Event e = Event.current;

                if (e.keyCode == KeyCode.Return || e.keyCode == KeyCode.Escape || e.character == '\n')
                {
                    if (GUIUtility.keyboardControl == mControlId)
                    {
                        GUIUtility.keyboardControl = -1; // 标记已完成

                        if (e.type != EventType.Repaint && e.type != EventType.Layout)
                        {
                            e.Use();
                        }

                        OnEndEdit?.Invoke(mSearchContent);
                    }
                }
            }
        }

        protected override void OnDispose()
        {
            throw new System.NotImplementedException();
        }
    }
}