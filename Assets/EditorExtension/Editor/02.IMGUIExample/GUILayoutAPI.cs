using System;
using UnityEngine;

namespace EditorExtension.Editor
{
    public class GUILayoutAPI : MonoBehaviour
    {
        private string mTextFieldValue = "TextField";
        private string mTextAreaValue;
        private string mPasswordFieldValue = String.Empty;
        private Vector2 mScrollPostion;
        private float mSliderValue;
        private int mToolbarIndex = 0;
        private bool mToggleValue;
        private int mSelectedIndex;

        public void Draw()
        {
            mScrollPostion = GUILayout.BeginScrollView(mScrollPostion);
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
                        mTextAreaValue = GUILayout.TextArea(mTextAreaValue, GUILayout.Width(150), GUILayout.Height(150));
                    }
                    GUILayout.EndHorizontal();

                    GUILayout.Space(100);

                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.Label("PasswordField:");
                        mPasswordFieldValue = GUILayout.PasswordField(mPasswordFieldValue, '*');
                    }
                    GUILayout.EndHorizontal();

                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.Label("Button:");

                        GUILayout.FlexibleSpace();

                        if (GUILayout.Button("Button"))
                        {
                            Debug.Log("Button Clicked");
                        }
                    }
                    GUILayout.EndHorizontal();

                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.Label("RepeatButton:");
                        if (GUILayout.RepeatButton("RepeatButton", GUILayout.Width(150), GUILayout.Height(150)))
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

                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.Label("HorizontalSlider:");
                        mSliderValue = GUILayout.HorizontalSlider(mSliderValue, 0, 1);
                    }
                    GUILayout.EndHorizontal();

                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.Label("VerticalSlider:");
                        mSliderValue = GUILayout.VerticalSlider(mSliderValue, 0, 1);
                    }
                    GUILayout.EndHorizontal();

                    GUILayout.BeginArea(new Rect(0, 0, 100, 100));
                    {
                        GUI.Label(new Rect(0, 0, 20, 20), "Area");
                    }
                    GUILayout.EndArea();

                    GUILayout.Window(1, new Rect(0, 0, 100, 100), id =>
                    {

                    }, "Window");

                    GUILayout.BeginHorizontal();
                    {
                        mToolbarIndex = GUILayout.Toolbar(mToolbarIndex, new[] { "1", "2", "3", "4" });
                    }
                    GUILayout.EndHorizontal();

                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.Label("VerticalSlider:");
                        mSliderValue = GUILayout.VerticalSlider(mSliderValue, 0, 1);
                    }
                    GUILayout.EndHorizontal();

                    GUILayout.BeginHorizontal();
                    {
                        mToggleValue = GUILayout.Toggle(mToggleValue, "Toggle");
                    }
                    GUILayout.EndHorizontal();

                    mSelectedIndex = GUILayout.SelectionGrid(mSelectedIndex, new[] { "1", "2", "3", "4" }, 3);
                }
                GUILayout.EndHorizontal();
            }
            GUILayout.EndScrollView();
        }
    }
}