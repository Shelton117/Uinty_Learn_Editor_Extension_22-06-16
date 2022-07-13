using UnityEditor;
using UnityEditor.EditorTools;
using UnityEngine;

namespace EditorExtension.Scene.EditorTool.Editor
{
    [EditorTool("Move Right")]
    public class MoveRightEditorTool : UnityEditor.EditorTools.EditorTool
    {
        public override void OnToolGUI(EditorWindow window)
        {
            window.ShowNotification(new GUIContent("Move Right"));

            EditorGUI.BeginChangeCheck();
            Vector3 position = Tools.handlePosition;

            using (new UnityEditor.Handles.DrawingScope(Color.green))
            {
                position = UnityEditor.Handles.Slider(position, Vector3.right);
            }

            if (EditorGUI.EndChangeCheck())
            {
                Vector3 delta = position - Tools.handlePosition;

                Undo.RecordObjects(Selection.transforms,"Move Platforms");

                foreach (var transform in Selection.transforms)
                {
                    transform.position += delta;
                }
            }
        }
    }
}