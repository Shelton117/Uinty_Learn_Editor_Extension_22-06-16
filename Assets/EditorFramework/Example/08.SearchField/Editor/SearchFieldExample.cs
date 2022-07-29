using System;
using EditorFramework.Editor;
using UnityEditor;
using UnityEngine;

namespace EditorFramework.Example.SearchField.Editor
{
    /// <summary>
    /// ËÑË÷¿ò
    /// </summary>
    [CustomEditorWindow((int)ExampleIndex.SearchField)]
    public class SearchFieldExample : EditorWindow
    {
        private EditorFramework.Editor.GUI.Drawer.SearchField mSearchField;
        private string mSearchContent = "";
        private string[] mSearchableContents = new string[] {"mode1", "mode2", "mode3"};

        private void OnEnable()
        {
            mSearchField = new EditorFramework.Editor.GUI.Drawer.SearchField(mSearchContent, mSearchableContents, 0);

            mSearchField.OnModeChanged += SearchFiedOnModeChanged;
            mSearchField.OnValueChanged += SearchFiedOnValueChanged;
            mSearchField.OnEndEdit += SearchFiedOnEndEdit;
        }

        private void OnDisable()
        {
            mSearchField.OnModeChanged -= SearchFiedOnModeChanged;
            mSearchField.OnValueChanged -= SearchFiedOnValueChanged;
            mSearchField.OnEndEdit -= SearchFiedOnEndEdit;
        }

        private void SearchFiedOnModeChanged(int obj)
        {
            Debug.Log("OnModeChanged:" + obj);
        }

        private void SearchFiedOnValueChanged(string obj)
        {
            Debug.Log("OnValueChanged:" + obj);
        }

        private void SearchFiedOnEndEdit(string obj)
        {
            Debug.Log("OnEndEdit:" + obj);
        }

        private void OnGUI()
        {
            GUILayout.Label("SearchField");
            mSearchField.OnGUI(EditorGUILayout.GetControlRect(GUILayout.Height(20)));
        }
    }
}