using System;
using UnityEditor;
using UnityEngine;

namespace EditorExtension.Editor.IMGUIExample
{
    public class GUILayoutExample : EditorWindow
    {

        enum PageID
        {
            Basic,
            Enabled,
            Rotate,
            Scale,
            Color,
            Other,
        }
        
        [MenuItem("EditorExtension/02.IMGUI/01.GUILayoutExample")]
        static void OpenGUILayoutExample()
        {
            GetWindow<GUILayoutExample>().Show();
        }

        private PageID mCurrentPageId = PageID.Basic;

        private void OnGUI()
        {
            mCurrentPageId = (PageID) GUILayout.Toolbar((int) mCurrentPageId, Enum.GetNames(typeof(PageID)));
            if (mCurrentPageId == PageID.Basic)
            {
                Basic();
            }
            else if (mCurrentPageId == PageID.Enabled)
            {
                Enabled();
            }
            else if (mCurrentPageId == PageID.Rotate)
            {
                Rotate();
            }
            else if (mCurrentPageId == PageID.Scale)
            {
                Scale();
            }
            else if (mCurrentPageId == PageID.Color)
            {
                Color();
            }
            else if (mCurrentPageId == PageID.Other)
            {
                
            }
        }

        #region Basic

        private string mTextFieldValue = "TextField";
        private string mTextAreaValue;
        private string mPasswordFieldValue = String.Empty;
        private Vector2 mScrollPostion;
        private float mSliderValue;
        private int mToolbarIndex = 0;
        private bool mToggleValue;
        private int mSelectedIndex;

        private void Basic()
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

        #endregion

        #region Enabled

        private bool mEnableInteractive = true;

        private void Enabled()
        {
            mEnableInteractive = GUILayout.Toggle(mEnableInteractive, "是否可交互");

            if (GUI.enabled != mEnableInteractive)
            {
                GUI.enabled = mEnableInteractive;
            }

            Basic();
        }

        #endregion

        #region Rotate

        private bool mOpenRotateEffect;
        private void Rotate()
        {
            mOpenRotateEffect = GUILayout.Toggle(mOpenRotateEffect, "是否旋转");

            if (mOpenRotateEffect)
            {
                GUIUtility.RotateAroundPivot(45, Vector2.zero);
            }

            Basic();
        }

        #endregion

        #region Scale

        private bool mOpenScaleEffect;
        private void Scale()
        {
            mOpenScaleEffect = GUILayout.Toggle(mOpenScaleEffect, "是否缩放");

            if (mOpenScaleEffect)
            {
                GUIUtility.ScaleAroundPivot(new Vector2(1.5f,1.5f), Vector2.zero);
            }

            Basic();
        }

        #endregion

        #region Color

        private bool mOpenColorEffect;
        private void Color()
        {
            mOpenColorEffect = GUILayout.Toggle(mOpenColorEffect, "是否变换颜色");
            if (mOpenColorEffect)
            {
                GUI.color = UnityEngine.Color.blue;
            }

            Basic();
        }

        #endregion
    }
}