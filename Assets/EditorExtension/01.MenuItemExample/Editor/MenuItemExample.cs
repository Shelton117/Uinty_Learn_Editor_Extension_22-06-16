using UnityEngine;
using UnityEditor;

namespace EditorExtension.MenuItemExample.Editor
{
    public static class MenuItemExample
    {
        /// <summary>
        /// ��̬����+[MenuItem(Path)] �ڲ˵�����ʾ������
        /// </summary>
        [MenuItem("EditorExtension/01.Menu/01.Hello Editor")]
        static void HelloEditor()
        {
            Debug.Log("Hello Editor");
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

        /// <summary>
        /// ������ݼ�
        /// </summary>
        private static bool mOpenShotCut = false;

        [MenuItem("EditorExtension/01.Menu/05.ToggleShotCut")]
        static void ToggleShotCut()
        {
            mOpenShotCut = !mOpenShotCut;

            Menu.SetChecked("EditorExtension/01.Menu/05.ToggleShotCut", mOpenShotCut);
        }

        /// <summary>
        /// ��ݷ�ʽת��
        /// # - Shift
        /// & - Alt
        /// % - Ctrl/Command
        /// _a-zA-Z - a-zA-Z
        /// </summary>
        [MenuItem("EditorExtension/01.Menu/06.Hello EditorWithShotCut _c")]
        static void HelloEditorWithShotCut()
        {
            // ����ģ��
            EditorApplication.ExecuteMenuItem("EditorExtension/01.Menu/01.Hello Editor");
        }

        [MenuItem("EditorExtension/01.Menu/07.Open BilibiliWithShotCut %e")]
        static void OpenBilibiliWithShotCut()
        {
            EditorApplication.ExecuteMenuItem("EditorExtension/01.Menu/02.Open Bilibili");
        }

        [MenuItem("EditorExtension/01.Menu/08.Open PersistenDataPathWithShotCut %#t")]
        static void OpenPersistenDataPathWithShotCut()
        {
            EditorApplication.ExecuteMenuItem("EditorExtension/01.Menu/03.Open PersistenDataPath");
        }

        [MenuItem("EditorExtension/01.Menu/09.Open DesignerFolderWithShotCut &r")]
        static void OpenDesignerFolderWithShotCut()
        {
            EditorApplication.ExecuteMenuItem("EditorExtension/01.Menu/04.Open DesignerFolder");
        }

        /// <summary>
        /// ������֤
        /// </summary>
        /// <returns></returns>
        [MenuItem("EditorExtension/01.Menu/06.Hello EditorWithShotCut _c", validate = true)]
        static bool HelloEditorWithShotCutValidate()
        {
            return mOpenShotCut;
        }

        [MenuItem("EditorExtension/01.Menu/07.Open BilibiliWithShotCut %e", validate = true)]
        static bool OpenBilibiliWithShotCutValidate()
        {
            return mOpenShotCut;
        }

        [MenuItem("EditorExtension/01.Menu/08.Open PersistenDataPathWithShotCut %#t", validate = true)]
        static bool OpenPersistenDataPathWithShotCutValidate()
        {
            return mOpenShotCut;
        }

        [MenuItem("EditorExtension/01.Menu/09.Open DesignerFolderWithShotCut &r", validate = true)]
        static bool OpenDesignerFolderWithShotCutValidate()
        {
            return mOpenShotCut;
        }

        /// <summary>
        /// ���캯����ʼ��״̬
        /// </summary>
        static MenuItemExample()
        {
            Menu.SetChecked("EditorExtension/01.Menu/05.ToggleShotCut", mOpenShotCut);
        }
    }
}
