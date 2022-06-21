using UnityEngine;

namespace EditorExtension.Editor
{
    public class GUIAPI : MonoBehaviour
    {
        private Rect mLabelRect = new Rect(20,60,200,20);
        private Rect mTextFieldRect = new Rect(20,90,200,20);
        private Rect mTextAreaRect = new Rect(20,120,200,200);

        private string mTextFieldValue;
        private string mTextAreaValue;

        public void Draw()
        {
            GUI.Label(mLabelRect,"Label:Hello GUI API");
            mTextFieldValue = GUI.TextField(mTextFieldRect, mTextFieldValue);
            mTextAreaValue = GUI.TextArea(mTextAreaRect, mTextAreaValue);
        }
    }
}