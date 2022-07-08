using UnityEditor;
using UnityEngine;

namespace EditorExtension.InspectorExample.ObjectPreview.Editor
{
    /// <summary>
    /// ∂‘œÛ‘§¿¿¿©’π
    /// </summary>
    [CustomPreview(typeof(GameObject))]
    public class ObjectPreviewExample : UnityEditor.ObjectPreview
    {
        public override bool HasPreviewGUI()
        {
            return true;
        }

        public override void OnPreviewGUI(Rect r, GUIStyle background)
        {
            GUI.Label(r,target.name + " Preview");
        }
    }
}