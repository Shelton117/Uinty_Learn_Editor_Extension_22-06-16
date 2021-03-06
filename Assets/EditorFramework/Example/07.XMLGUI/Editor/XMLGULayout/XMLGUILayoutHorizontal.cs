using UnityEngine;

namespace EditorFramework.Example.XMLGUI.Editor
{
    public class XMLGUILayoutHorizontal : XMLGUIContainerBase
    {
        public override void OnGUI(Rect position)
        {
            base.OnGUI(position);

            GUILayout.BeginHorizontal();
            {
                Xmlgui.Draw();
            }
            GUILayout.EndHorizontal();
        }
    }
}