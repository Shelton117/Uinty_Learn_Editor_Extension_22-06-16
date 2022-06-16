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

        [MenuItem("EditorExtension/01.Menu/03.Open PersistenDataPath")]
        static void OpenPersistenDataPath()
        {
            EditorUtility.RevealInFinder(Application.persistentDataPath);
        }

        [MenuItem("EditorExtension/01.Menu/04.Open DesignerFolder")]
        static void OpenDesignerFolder()
        {
            EditorUtility.RevealInFinder(Application.dataPath.Replace("Assets","Library"));
        }

        private static bool mOpenShotCut = false;

        [MenuItem("EditorExtension/01.Menu/05.ToggleShotCut")]
        static void ToggleShotCut()
        {
            mOpenShotCut = !mOpenShotCut;

            Menu.SetChecked("EditorExtension/01.Menu/05.ToggleShotCut", mOpenShotCut);
        }
    }
}
