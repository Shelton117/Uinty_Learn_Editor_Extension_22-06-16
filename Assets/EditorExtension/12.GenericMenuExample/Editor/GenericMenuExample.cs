using UnityEditor;
using UnityEngine;

namespace EditorExtension.GenericMenuExample.Editor
{
    /// <summary>
    /// 鼠标右键菜单栏
    /// </summary>
    public class GenericMenuExample : EditorWindow
    {
        [MenuItem("EditorExtension/07.GenericMenu/Open")]
        static void Open()
        {
            GetWindow<GenericMenuExample>().Show();
        }

        private void OnGUI()
        {
            var e = Event.current;

            if (e != null)
            {
                if (e.type == EventType.MouseDown && e.button == 1)
                {
                    var genericMenu = new GenericMenu();
                    genericMenu.AddItem(new GUIContent("功能1"),false, () => { Debug.Log("功能1");});
                    genericMenu.AddItem(new GUIContent("功能合集/功能2"), false, () => { Debug.Log("功能2"); });
                    genericMenu.AddItem(new GUIContent("功能合集/功能3"), false, () => { Debug.Log("功能3"); });
                    genericMenu.AddSeparator("功能合集/");
                    genericMenu.AddItem(new GUIContent("功能合集/功能4"), false, () => { Debug.Log("功能4"); });
                    genericMenu.ShowAsContext();
                }
            }
        }
    }
}