using UnityEditor;
using UnityEngine;

namespace EditorExtension.Editor.IMGUIExample
{
    public class EditorGUIAPI : MonoBehaviour
    {
        private Rect mLabelFieldRect = new Rect(10,60,200,20);

        bool mDisableGroupValue;

        public void Draw()
        {
            mDisableGroupValue = EditorGUILayout.Toggle("Disable Group", mDisableGroupValue);

            EditorGUI.BeginDisabledGroup(mDisableGroupValue == false);
            {
                EditorGUI.LabelField(mLabelFieldRect, "EditorGUI LabelField");
            }
            EditorGUI.EndDisabledGroup();
        }
    }
}