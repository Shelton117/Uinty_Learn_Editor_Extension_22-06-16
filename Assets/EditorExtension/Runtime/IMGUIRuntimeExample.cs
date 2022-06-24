using System;
using UnityEngine;

namespace EditorExtension.Runtime
{
    /// <summary>
    /// 运行场景中的两个api调用
    /// 不能调用编辑器里的脚本（Editor文件夹下的脚本），反之亦然
    /// 运行时的载体：MonoBehaviour
    /// </summary>
    public class IMGUIRuntimeExample : MonoBehaviour
    {
        private int mIndex = 0;

        private void OnGUI()
        {
            mIndex = GUILayout.Toolbar(mIndex, new[] {"GUILayout", "GUI"});

            if (mIndex == 0)
            {
                GUILayoutDraw();
            }
            else
            {
                GUIDraw();
            }
        }

        #region GUI

        private Rect mLabelRect = new Rect(20, 60, 200, 20);
        private Rect mTextFieldRect = new Rect(20, 90, 200, 20);
        private Rect mTextAreaRect = new Rect(20, 120, 200, 100);
        private Rect mPasswordRect = new Rect(20, 250, 200, 20);
        private Rect mButtonRect = new Rect(20, 280, 80, 20);
        private Rect mRepeatButtonRect = new Rect(100, 280, 80, 20);
        private Rect mToggleRect = new Rect(20, 310, 80, 20);
        private Rect mToolbarRect = new Rect(20, 340, 400, 20);
        private Rect mBoxRect = new Rect(20, 370, 400, 20);
        private Rect mHorizontalSliderRect = new Rect(20, 400, 80, 20);
        private Rect mVerticalSliderRect = new Rect(20, 430, 20, 80);
        private Rect mGroupRect = new Rect(20, 460, 100, 100);
        private Rect mWindowRect = new Rect(20, 490, 100, 100);

        private string mGUITextFieldValue;
        private string mGUITextAreaValue;
        private string mGUIPasswordFieldValue = String.Empty;
        private bool mGUIToggleValue;
        private int mGUIToolbarIndex;
        private Vector2 mGUIScrollViewPos;
        private float mGUIHorizontalSliderValue;
        private float mGUIVerticalSliderValue;

        public void GUIDraw()
        {
            mGUIScrollViewPos = GUI.BeginScrollView(new Rect(20, 0, 2000, 4000), 
                mGUIScrollViewPos, new Rect(20, 0, 2000, 4000));
            {
                GUI.Label(mLabelRect, "Label:Hello GUI API");

                mGUITextFieldValue = GUI.TextField(mTextFieldRect, mGUITextFieldValue);
                mGUITextAreaValue = GUI.TextArea(mTextAreaRect, mGUITextAreaValue);
                mGUIPasswordFieldValue = GUI.PasswordField(mPasswordRect, mGUIPasswordFieldValue, '*');

                if (GUI.Button(mButtonRect, "button"))
                {
                    Debug.Log("Button Clicked");
                }

                if (GUI.RepeatButton(mRepeatButtonRect, "RepeatButton"))
                {
                    Debug.Log("RepeatButton Clicked");
                }

                mGUIToggleValue = GUI.Toggle(mToggleRect, mGUIToggleValue, "GUI Toggle");

                mGUIToolbarIndex = GUI.Toolbar(mToolbarRect, mGUIToolbarIndex, new[] { "1", "2", "3", "4" });

                GUI.Box(mBoxRect, "GUI Box");

                mGUIHorizontalSliderValue = GUI.HorizontalSlider(mHorizontalSliderRect, mGUIHorizontalSliderValue, 0f, 1f);

                mGUIVerticalSliderValue = GUI.VerticalSlider(mVerticalSliderRect, mGUIVerticalSliderValue, 0f, 1f);

                GUI.BeginGroup(mGroupRect, "GUI Gounp");
                {

                }
                GUI.EndGroup();

                GUI.Window(10000, mWindowRect, (mBoxRect) =>
                {

                }, "GUI Window");
            }
            GUI.EndScrollView();
        }

        #endregion

        #region GUILayout
        private string mGUILayoutTextFieldValue = "TextField";
        private string mGUILayoutTextAreaValue;
        private string mGUILayoutPasswordFieldValue = String.Empty;
        private Vector2 mGUILayoutScrollPostion;
        private float mGUILayoutSliderValue;
        private int mGUILayoutToolbarIndex = 0;
        private bool mGUILayoutToggleValue;
        private int mGUILayoutSelectedIndex;

        public void GUILayoutDraw()
        {
            // 滚动区域
            mGUILayoutScrollPostion = GUILayout.BeginScrollView(mGUILayoutScrollPostion);
            {
                // 垂直分布，分布类型为box
                GUILayout.BeginVertical("box");
                {
                    GUILayout.Label("label:Hello IMGUI");

                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.Label("TextField:");
                        mGUILayoutTextFieldValue = GUILayout.TextField(mGUILayoutTextFieldValue);
                    }
                    GUILayout.EndHorizontal();

                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.Label("TextArea:");
                        mGUILayoutTextAreaValue = GUILayout.TextArea(mGUILayoutTextAreaValue, 
                            GUILayout.Width(150), GUILayout.Height(150));
                    }
                    GUILayout.EndHorizontal();

                    GUILayout.Space(100);

                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.Label("PasswordField:");
                        mGUILayoutPasswordFieldValue = GUILayout.PasswordField(mGUILayoutPasswordFieldValue, '*');
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
                        mGUILayoutSliderValue = GUILayout.HorizontalSlider(mGUILayoutSliderValue, 0, 1);
                    }
                    GUILayout.EndHorizontal();

                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.Label("VerticalSlider:");
                        mGUILayoutSliderValue = GUILayout.VerticalSlider(mGUILayoutSliderValue, 0, 1);
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
                        mGUILayoutToolbarIndex = GUILayout.Toolbar(mGUILayoutToolbarIndex, new[] { "1", "2", "3", "4" });
                    }
                    GUILayout.EndHorizontal();

                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.Label("VerticalSlider:");
                        mGUILayoutSliderValue = GUILayout.VerticalSlider(mGUILayoutSliderValue, 0, 1);
                    }
                    GUILayout.EndHorizontal();

                    GUILayout.BeginHorizontal();
                    {
                        mGUILayoutToggleValue = GUILayout.Toggle(mGUILayoutToggleValue, "Toggle");
                    }
                    GUILayout.EndHorizontal();

                    mGUILayoutSelectedIndex = GUILayout.SelectionGrid(mGUILayoutSelectedIndex, new[] { "1", "2", "3", "4" }, 3);
                }
                GUILayout.EndHorizontal();
            }
            GUILayout.EndScrollView();
        }

        #endregion
        
    }
}