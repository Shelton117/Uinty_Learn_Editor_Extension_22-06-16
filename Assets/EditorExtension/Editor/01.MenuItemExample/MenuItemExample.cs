using UnityEngine;
using UnityEditor;

namespace EditorExtension.Editor.MenuItemExample
{
    public class MenuItemExample
    {
        [MenuItem("EditorExtension/01.Menu/01.Hello Editor")]
        static void HelloEditor()
        {
            Debug.Log("HelloEditor");
        }

        [MenuItem("EditorExtension/01.Menu/02.Open Bilibili")]
        static void OpenBilibili()
        {
            Application.OpenURL("https://bilibili.com");
        }
    }
}
