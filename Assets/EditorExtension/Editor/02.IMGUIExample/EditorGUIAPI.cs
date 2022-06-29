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

        private bool mDisableGroupValue;
        private string  mTextFieldValie;
        private string mTextAreaValue;
        private string mPasswordFieldValue;
        private bool mToggleValue;
        private bool mToggleLeftValue;
        private Color mColorFieldValue;
        private Bounds mBoundsFieldValue;

        public void Draw()
        {
            mDisableGroupValue = EditorGUILayout.Toggle("Disable Group", mDisableGroupValue);

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
            }
            EditorGUI.EndDisabledGroup();
        }
    }
}