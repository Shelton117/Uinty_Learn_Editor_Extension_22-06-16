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

            var firstLine = mXmlgui.GetGUIBaseById<XMLGUILayoutHorizontal>("firstLine");

            firstLine.Xmlgui.GetGUIBaseById<XMLGUIButton>("loginButton").Onclick += () =>
            {
                firstLine.Xmlgui.GetGUIBaseById<XMLGUILabel>("label1").Text = "1";
                firstLine.Xmlgui.GetGUIBaseById<XMLGUILabel>("label2").Text = "2";
                firstLine.Xmlgui.GetGUIBaseById<XMLGUILabel>("label3").Text = "3";

                Debug.Log("Button OnClick");
            };
        }

        private void OnGUI()
        {
            mXmlgui.Draw();
        }
    }
}