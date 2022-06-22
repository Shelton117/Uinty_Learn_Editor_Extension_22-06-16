using System;
using UnityEngine;

namespace EditorExtension.Editor
{
    public class GUIAPI : MonoBehaviour
    {
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
        private Rect mWindowRect = new Rect(20,490,100,100);

        private string mTextFieldValue;
        private string mTextAreaValue;
        private string mPasswordFieldValue = String.Empty;
        private bool mToggleValue;
        private int mToolbarIndex;
        private Vector2 mScrollViewPos;
        private float mHorizontalSliderValue;
        private float mVerticalSliderValue;

        public void Draw()
        {
            mScrollViewPos = GUI.BeginScrollView(new Rect(20, 0, 2000, 4000), mScrollViewPos, new Rect(20, 0, 2000, 4000));
            {
                GUI.Label(mLabelRect, "Label:Hello GUI API");

                mTextFieldValue = GUI.TextField(mTextFieldRect, mTextFieldValue);
                mTextAreaValue = GUI.TextArea(mTextAreaRect, mTextAreaValue);
                mPasswordFieldValue = GUI.PasswordField(mPasswordRect, mPasswordFieldValue, '*');

                if (GUI.Button(mButtonRect, "button"))
                {
                    Debug.Log("Button Clicked");
                }

                if (GUI.RepeatButton(mRepeatButtonRect, "RepeatButton"))
                {
                    Debug.Log("RepeatButton Clicked");
                }

                mToggleValue = GUI.Toggle(mToggleRect, mToggleValue, "GUI Toggle");

                mToolbarIndex = GUI.Toolbar(mToolbarRect, mToolbarIndex, new[] { "1", "2", "3", "4" });

                GUI.Box(mBoxRect, "GUI Box");

                mHorizontalSliderValue = GUI.HorizontalSlider(mHorizontalSliderRect, mHorizontalSliderValue, 0f, 1f);

                mVerticalSliderValue = GUI.VerticalSlider(mVerticalSliderRect, mVerticalSliderValue, 0f, 1f);

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
    }
} 