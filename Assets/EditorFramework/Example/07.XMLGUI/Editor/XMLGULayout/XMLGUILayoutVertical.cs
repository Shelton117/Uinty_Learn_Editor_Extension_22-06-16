using UnityEngine;

namespace EditorFramework.Example.XMLGUI.Editor
{
    public class XMLGUILayoutVertical : XMLGUIContainerBase
    {
        public override void OnGUI(Rect position)
        {
            base.OnGUI(position);

            GUILayout.BeginVertical();
            {
                Xmlgui.Draw();
            }
            GUILayout.EndVertical();
        }
    }
}