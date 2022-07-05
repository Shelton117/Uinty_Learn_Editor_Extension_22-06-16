using UnityEditor;
using UnityEngine;

namespace EditorExtension.InspectorExample.CustomEditor.Editor
{
    /// <summary>
    /// Inspector拓展
    /// Editor去修改Inspector里的属性渲染方式
    /// </summary>
    [UnityEditor.CustomEditor(typeof(CustomEditorExample))]
    public class CustomEditorExampleInspector : UnityEditor.Editor
    {
        private CustomEditorExample mTarget
        {
            get { return target as CustomEditorExample; }
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var hpRect = GUILayoutUtility.GetRect(18, 18, "TextField");
            EditorGUI.ProgressBar(hpRect, mTarget.HP,"HP");
            var rangeRect = GUILayoutUtility.GetRect(18, 18, "TextField");
            mTarget.Range = EditorGUI.Slider(rangeRect, mTarget.Range, 0,1f);

            EditorGUILayout.BeginHorizontal("box");
            {
                EditorGUILayout.LabelField("RoleName", GUILayout.Width(100));
                mTarget.RoleName = EditorGUILayout.TextArea(mTarget.RoleName);
            }
            EditorGUILayout.EndHorizontal();
            
            //var serializedObject = new SerializedObject(mTarget);
            var otherObjProperty = serializedObject.FindProperty("OtherObj");
            EditorGUILayout.ObjectField(otherObjProperty);
            serializedObject.ApplyModifiedProperties();
        }
    }
}