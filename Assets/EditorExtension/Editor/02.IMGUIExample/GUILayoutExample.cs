using UnityEditor;
using UnityEngine;

namespace EditorExtension.Editor.IMGUIExample
{
    public class GUILayoutExample : EditorWindow
    {
        [MenuItem("EditorExtension/02.IMGUI/01.GUILayoutExample")]
        static void OpenGUILayoutExample()
        {
            GetWindow<GUILayoutExample>().Show();
        }

        private void OnGUI()
        {
            GUILayout.Label("Hello IMGUI");
        }
    }
}