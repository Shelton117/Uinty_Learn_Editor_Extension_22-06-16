using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine;

namespace EditorExtension.Editor.IMGUIExample
{
    public class EditorGUILayoutAPI : MonoBehaviour
    {
        private BuildTargetGroup mbBuildTargetGroupValue;
        private bool mFoldOutGroup = false;
        private AnimBool mAnimBoolValue = new AnimBool(false);
        private bool mGroupValue = false;
        private bool mToggle1Value = false;
        private bool mToggle2Value = true;

        public void Draw()
        {
            mAnimBoolValue.target = EditorGUILayout.ToggleLeft("Toggle Left", mAnimBoolValue.target);

            mFoldOutGroup = EditorGUILayout.BeginFoldoutHeaderGroup(mFoldOutGroup, "BeginFoldoutHeaderGroup");
            if (mFoldOutGroup)
            {
                EditorGUILayout.BeginFadeGroup(mAnimBoolValue.faded);

                if (mAnimBoolValue.target)
                {
                    mbBuildTargetGroupValue = EditorGUILayout.BeginBuildTargetSelectionGrouping();
                    if (mbBuildTargetGroupValue == BuildTargetGroup.Standalone)
                    {
                        EditorGUILayout.LabelField("Label Field");
                    }
                    EditorGUILayout.EndBuildTargetSelectionGrouping();
                }
                EditorGUILayout.EndFadeGroup();
            }
            EditorGUILayout.EndFoldoutHeaderGroup();

            mGroupValue = EditorGUILayout.BeginToggleGroup("BeginToggleGroup", mGroupValue);
            mToggle1Value = EditorGUILayout.Toggle("1", mToggle1Value);
            mToggle2Value = EditorGUILayout.Toggle("2", mToggle2Value);
            EditorGUILayout.EndToggleGroup();
        }
    }
}