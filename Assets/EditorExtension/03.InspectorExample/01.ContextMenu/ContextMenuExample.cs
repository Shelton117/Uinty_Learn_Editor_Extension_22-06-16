using UnityEngine;

namespace EditorExtension.InspectorExample.ContextMenu
{
    public class ContextMenuExample : MonoBehaviour
    {
        [UnityEngine.ContextMenu("Hello ContextMenu")]
        private void HelloContextMenu()
        {
            Debug.Log("Hello ContextMenu");
        }

        [ContextMenuItem("Print Value", "HelloContextMenuIem")]
        [SerializeField]
        private string mContextMenuIemValue;
        
        private void HelloContextMenuIem()
        {
            Debug.Log(mContextMenuIemValue);
        }

#if UNITY_EDITOR
        /// <summary>
        /// CONTEXTΪ��ǰĿ¼���󣬼�Ϊѡ�еĽű�����
        /// CONTEXT/MonoBehaviour Ŀ¼�µ�������UnityEngine.ContextMenu��ĵȼ�
        /// ���ҽű����̳���MonoBehaviour����ѡ��
        /// </summary>
        private const string mFindScriptPath = "CONTEXT/MonoBehaviour/FindScript";
        [UnityEditor.MenuItem(mFindScriptPath)]
        private static void FindScript(UnityEditor.MenuCommand command)
        {
            UnityEditor.Selection.activeObject =
                UnityEditor.MonoScript.FromMonoBehaviour(command.context as MonoBehaviour);
        }

        /// <summary>
        /// ���ҽű����Ǽ̳���MonoBehaviour������ӡĿ¼
        /// </summary>
        private const string mCameraScriptPath = "CONTEXT/Camera/LogSelf";
        [UnityEditor.MenuItem(mCameraScriptPath)]
        private static void LogSelf(UnityEditor.MenuCommand command)
        {
            Debug.Log(command.context);
        }
#endif
    }
}
