using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

namespace EditorExtension.EventAttributeExample.Editor
{
    /// <summary>
    /// �༭���¼�������Ӧʾ��
    /// ����һ����ȡʱ��Ч��
    /// </summary>
    [InitializeOnLoad]
    public class EditorEventAttributeExample
    {
        static EditorEventAttributeExample()
        {
            Debug.Log("Editor Event Attribute Example");
        }

        /// <summary>
        /// editor�µ����е�����
        /// ���ؽű�ʱ��ʼ��
        /// </summary>
        [InitializeOnLoadMethod]
        static void InitializeOnLoadMethod()
        {
            Debug.Log("Initialize OnLoad Method");
        }

        /// <summary>
        /// ��������󣬼��ؽű�����
        /// ���ڱ�Ǿ�̬����
        /// </summary>
        [DidReloadScripts]
        static void OnScriptReload()
        {
            Debug.Log("�������");
        }

        /// <summary>
        /// ���س���
        /// </summary>
        [PostProcessScene]
        static void OnPostProcessScene()
        {
            Debug.Log("OnPostProcessScene");
        }

        /// <summary>
        /// ��ɴ��ʱ����
        /// Build ֮����յ�һ���ص�
        /// </summary>
        [PostProcessBuild]
        static void OnPostProcessBuild(BuildTarget target, string pathToBuiltProject)
        {
            Debug.Log("OnPostProcessBuild");
        }

        /// <summary>
        /// ��ĳ����Դʱ��ûص�
        /// </summary>
        /// <param name="instanceID"></param>
        /// <param name="line"></param>
        /// <returns></returns>
        [OnOpenAsset(1)]
        static bool OpenAsset(int instanceID, int line)
        {
            var name = EditorUtility.InstanceIDToObject(instanceID);
            Debug.Log("Open Asset Step:1 ( " + name + " )");
            return false;
        }

        [OnOpenAsset(2)]
        static bool OpenAsset2(int instanceID, int line)
        {
            var name = EditorUtility.InstanceIDToObject(instanceID);
            Debug.Log("Open Asset Step:2 ( " + name + " )");
            return false;
        }
    }
}