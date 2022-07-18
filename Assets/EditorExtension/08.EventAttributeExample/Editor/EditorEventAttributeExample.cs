using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

namespace EditorExtension.EventAttributeExample.Editor
{
    /// <summary>
    /// 编辑器事件属性相应示例
    /// （第一被获取时生效）
    /// </summary>
    [InitializeOnLoad]
    public class EditorEventAttributeExample
    {
        static EditorEventAttributeExample()
        {
            Debug.Log("Editor Event Attribute Example");
        }

        /// <summary>
        /// editor下的运行的内容
        /// 加载脚本时初始化
        /// </summary>
        [InitializeOnLoadMethod]
        static void InitializeOnLoadMethod()
        {
            Debug.Log("Initialize OnLoad Method");
        }

        /// <summary>
        /// 编译结束后，加载脚本触发
        /// 用于标记静态方法
        /// </summary>
        [DidReloadScripts]
        static void OnScriptReload()
        {
            Debug.Log("加载完毕");
        }

        /// <summary>
        /// 加载场景
        /// </summary>
        [PostProcessScene]
        static void OnPostProcessScene()
        {
            Debug.Log("OnPostProcessScene");
        }

        /// <summary>
        /// 完成打包时调用
        /// Build 之后会收到一个回调
        /// </summary>
        [PostProcessBuild]
        static void OnPostProcessBuild(BuildTarget target, string pathToBuiltProject)
        {
            Debug.Log("OnPostProcessBuild");
        }

        /// <summary>
        /// 打开某个资源时获得回调
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