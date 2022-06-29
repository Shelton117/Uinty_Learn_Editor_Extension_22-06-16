using UnityEditor;
using UnityEngine;

namespace EditorExtension.Editor.IMGUIExample
{
    /// <summary>
    /// 对GUI的扩展与补充
    /// </summary>
    public class EditorGUIAPI : MonoBehaviour
    {
        private Rect mLabelFieldRect = new Rect(10, 60, 200, 20);
        private Rect mTextFieldRect = new Rect(10, 90, 200, 20);
        private Rect mTextAreaRect = new Rect(10, 120, 200, 40);
        private Rect mPasswordFieldRect = new Rect(10, 170, 200, 20);
        private Rect mDropdownButtonRect = new Rect(10, 200, 200, 20);
        private Rect mLinkButtonRect = new Rect(10, 230, 200, 20);
        private Rect mToggleRect = new Rect(10, 260, 200, 20);
        private Rect mToggleLeftRect = new Rect(10, 290, 200, 20);
        private Rect mHelpBoxRect = new Rect(10, 320, 200, 20);
        private Rect mColorFieldRect = new Rect(10, 350, 200, 20);
        private Rect mBoundsFieldRect = new Rect(10, 380, 200, 20);
        private Rect mBoundsIntFieldRect = new Rect(10, 450, 200, 20);
        private Rect mCurveFieldRect = new Rect(10, 520, 200, 20);
        private Rect mDelayedDoubleFieldRect = new Rect(10, 550, 200, 20);
        private Rect mDoubleFieldRect = new Rect(10, 580, 200, 20);
        private Rect mEnumFlagsFieldRect = new Rect(10, 610, 200, 20);
        private Rect mEnumPopupRect = new Rect(10, 640, 200, 20);
        private Rect mFoldoutRect = new Rect(10, 60, 200, 20);
        private Rect mGradientFieldRect = new Rect(10, 700, 200, 20);

        private bool mDisableGroupValue;
        private string mTextFieldValie;
        private string mTextAreaValue;
        private string mPasswordFieldValue;
        private bool mToggleValue;
        private bool mToggleLeftValue;
        private Color mColorFieldValue;
        private Bounds mBoundsFieldValue;
        private BoundsInt mBoundsIntFieldValue;
        private AnimationCurve mCurveFieldValue = new AnimationCurve();
        private double mDelayedDoubleFieldValue;
        private double mDoubleFieldValue;
        private EnumFlagsField mEnumFlagsFieldValue;
        private EnumPopup mEnumPopupValue;
        private bool mFoldoutValue;
        private Gradient mGradientFieldValue = new Gradient();

        private enum EnumFlagsField
        {
            A = 1,
            B,
            C,
        }

        private enum EnumPopup
        {
            A = 1,
            B,
            C,
        }

        public void Draw()
        {
            mDisableGroupValue = EditorGUILayout.Toggle("Disable Group", mDisableGroupValue);

            mFoldoutValue = EditorGUI.Foldout(mFoldoutRect, mFoldoutValue, "Foldout");
            if (mFoldoutValue)
            {
                EditorGUI.BeginDisabledGroup(mDisableGroupValue == false);
                {
                    EditorGUI.LabelField(mLabelFieldRect, "EditorGUI LabelField");

                    mTextFieldValie = EditorGUI.TextField(mTextFieldRect, mTextFieldValie);
                    mTextAreaValue = EditorGUI.TextArea(mTextAreaRect, mTextAreaValue);
                    mPasswordFieldValue = EditorGUI.PasswordField(mPasswordFieldRect, mPasswordFieldValue);

                    if (EditorGUI.DropdownButton(mDropdownButtonRect, new GUIContent("123"), FocusType.Keyboard))
                    {
                        Debug.Log("EditorGUI DropdownButton");
                        // 渲染一个下拉菜单
                    }
                    if (EditorGUI.LinkButton(mLinkButtonRect, "Link Button"))
                    {
                        Debug.Log("EditorGUI LinkButton");
                    }

                    mToggleValue = EditorGUI.Toggle(mToggleRect, "Toggle", mToggleValue);
                    mToggleLeftValue = EditorGUI.ToggleLeft(mToggleLeftRect, "Toggle Left", mToggleLeftValue);

                    EditorGUI.HelpBox(mHelpBoxRect, "Help Box", MessageType.Info);

                    mColorFieldValue = EditorGUI.ColorField(mColorFieldRect, "Color Field", mColorFieldValue);

                    mBoundsFieldValue = EditorGUI.BoundsField(mBoundsFieldRect, "Bounds Field", mBoundsFieldValue);
                    mBoundsIntFieldValue =
                        EditorGUI.BoundsIntField(mBoundsIntFieldRect, "Bounds Int Field", mBoundsIntFieldValue);

                    mCurveFieldValue = EditorGUI.CurveField(mCurveFieldRect, "Curve Field", mCurveFieldValue);

                    // 延迟输入，需要回车或者点击空白处
                    mDelayedDoubleFieldValue =
                        EditorGUI.DelayedDoubleField(mDelayedDoubleFieldRect,
                        "DelayedDouble Field",
                        mDelayedDoubleFieldValue);
                    mDoubleFieldValue =
                        EditorGUI.DoubleField(mDoubleFieldRect, "Double Field", mDoubleFieldValue);

                    // 多选枚举
                    mEnumFlagsFieldValue =
                        (EnumFlagsField)EditorGUI.EnumFlagsField(mEnumFlagsFieldRect,
                        "EnumFlags Field",
                        mEnumFlagsFieldValue);
                    mEnumPopupValue = (EnumPopup)EditorGUI.EnumPopup(mEnumPopupRect, "EnumPopup", mEnumPopupValue);

                    mGradientFieldValue =
                        EditorGUI.GradientField(mGradientFieldRect, "Gradient Field", mGradientFieldValue);
                }
                EditorGUI.EndDisabledGroup();
            }
        }
    }
}