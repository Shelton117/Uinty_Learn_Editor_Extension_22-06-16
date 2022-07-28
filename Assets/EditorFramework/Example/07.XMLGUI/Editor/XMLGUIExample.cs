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

            mXmlgui.GetGUIBaseById<XMLGUILayoutButton>("loginButton").Onclick += () =>
            {
                mXmlgui.GetGUIBaseById<XMLGUILayoutLabel>("label1").Text = "1";
                mXmlgui.GetGUIBaseById<XMLGUILayoutLabel>("label2").Text = "2";
                mXmlgui.GetGUIBaseById<XMLGUILayoutLabel>("label3").Text = "3";

                var label = mXmlgui.GetGUIBaseById<XMLGUILabel>("label5");
                label.Text = label.rect.x + ":" + label.rect.y + "  " + label.rect.width + ":" + label.rect.height;

                Debug.Log("Button OnClick");
            };
        }

        private void OnGUI()
        {
            mXmlgui.Draw();
        }
    }
}