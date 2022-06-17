using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace EditorExtension.Editor.IMGUIExample
{
    public class GUILayoutExample : EditorWindow
    {
        [MenuItem("EditorExtension/02.IMGUI/01.GUILayoutExample")]
        static void OpenGUILayoutExample()
        {
            GetWindow<GUILayoutExample>().Show();
        }

        private string mTextFieldValue = "TextField";
        private string mTextAreaValue;
        private string mPasswordFieldValue = String.Empty;

        private void OnGUI()
        {
            GUILayout.BeginVertical("box");
            {
                GUILayout.Label("label:Hello IMGUI");

                GUILayout.BeginHorizontal();
                {
                    GUILayout.Label("TextField:");
                    mTextFieldValue = GUILayout.TextField(mTextFieldValue);
                }
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                {
                    GUILayout.Label("TextArea:");
                    mTextAreaValue = GUILayout.TextArea(mTextAreaValue);
                }
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                {
                    GUILayout.Label("PasswordField:");
                    mPasswordFieldValue = GUILayout.PasswordField(mPasswordFieldValue, '*');
                }
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                {
                    GUILayout.Label("Button:");
                    if (GUILayout.Button("Button"))
                    {
                        Debug.Log("Button Clicked");
                    }
                }
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                {
                    GUILayout.Label("RepeatButton:");
                    if (GUILayout.RepeatButton("RepeatButton"))
                    {
                        Debug.Log("RepeatButton Clicked");
                    }
                }
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                {
                    GUILayout.Label("RepeatButton:");
                    GUILayout.Box("AutoLayout Box");
                }
                GUILayout.EndHorizontal();
            }
            GUILayout.EndHorizontal();
        }
    }
}