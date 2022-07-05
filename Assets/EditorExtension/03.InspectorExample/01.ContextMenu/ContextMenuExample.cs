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
        /// CONTEXT为当前目录对象，即为选中的脚本本身
        /// CONTEXT/MonoBehaviour 目录下的内容与UnityEngine.ContextMenu里的等价
        /// 查找脚本（继承于MonoBehaviour）并选中
        /// </summary>
        private const string mFindScriptPath = "CONTEXT/MonoBehaviour/FindScript";
        [UnityEditor.MenuItem(mFindScriptPath)]
        private static void FindScript(UnityEditor.MenuCommand command)
        {
            UnityEditor.Selection.activeObject =
                UnityEditor.MonoScript.FromMonoBehaviour(command.context as MonoBehaviour);
        }

        /// <summary>
        /// 查找脚本（非继承于MonoBehaviour）并打印目录
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
