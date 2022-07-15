using System.Collections.Generic;
using System.Xml;
using EditorFramework.Editor;
using UnityEditor;
using UnityEngine;

namespace EditorFramework.Example.XMLGUI.Editor
{
    /// <summary>
    /// Ê¹ÓÃxml±àÐ´±à¼­Æ÷UI
    /// </summary>
    [CustomEditorWindow((int)ExampleIndex.XMLGUI)]
    public class XMLGUIExample : EditorWindow
    {
        private const string XMLFilePath = "Assets/EditorFramework/Example/07.XMLGUI/Editor/XMLGUIExample.xml";
        private string mXmlContent;
        private XMLGUI mXmlgui;

        private void OnEnable()
        {
            var xmlFileAsset = AssetDatabase.LoadAssetAtPath<TextAsset>(XMLFilePath);
            mXmlContent = xmlFileAsset.text;
            mXmlgui = new XMLGUI();
            mXmlgui.ReadXML(mXmlContent);

            mXmlgui.GetGUIBaseById<XMLGUIButton>("loginButton").Onclick += () =>
            {
                Debug.Log("Button OnClick");
            };
        }

        private void OnGUI()
        {
            foreach (var guiBase in mXmlgui.GUIBases)
            {
                guiBase.OnGUI(default);
            }
        }
    }
}