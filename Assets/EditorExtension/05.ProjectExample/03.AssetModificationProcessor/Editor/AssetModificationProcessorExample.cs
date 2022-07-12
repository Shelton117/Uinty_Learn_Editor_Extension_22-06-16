using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace EditorExtension.ProjectExample.AssetModificationProcessor.Editor
{
    /// <summary>
    /// 建立资源目录规则（新建移动删除等）
    /// </summary>
    public class AssetModificationProcessorExample : UnityEditor.AssetModificationProcessor
    {
        /// <summary>
        /// 创建asset的时候调用的函数
        /// </summary>
        /// <param name="assetName">资源名称</param>
        private static void OnWillCreateAsset(string assetName)
        {
            Debug.Log($"OnWillCreateAsset{assetName}");
        }

        /// <summary>
        /// 删除asset的时候调用
        /// </summary>
        /// <param name="assetPath">删除路径</param>
        /// <param name="options">删除方式</param>
        /// <returns></returns>
        private static AssetDeleteResult OnWillDeleteAsset(string assetPath, RemoveAssetOptions options)
        {
            Debug.Log($"OnWillDeleteAsset{assetPath}/{options}");

            // 系统弹窗（两个按钮的）
            if (EditorUtility.DisplayDialog("Warning!","Delete or not?","yes","no"))
            {
                return AssetDeleteResult.DidNotDelete;
            }

            return AssetDeleteResult.FailedDelete;
        }

        /// <summary>
        /// 移动asset的时候调用
        /// </summary>
        /// <param name="sourcePath">起始目录</param>
        /// <param name="destinationPath">目标目录</param>
        /// <returns></returns>
        private static AssetMoveResult OnWillMoveAsset(string sourcePath,string destinationPath)
        {
            Debug.Log($"OnWillMoveAsset{sourcePath}=>{destinationPath}");

            if (EditorUtility.DisplayDialog("Prompt!", "Move or not?", "yes", "no"))
            {
                return AssetMoveResult.DidNotMove;
            }

            return AssetMoveResult.FailedMove;
        }

        /// <summary>
        /// 保存asset的时候调用
        /// </summary>
        /// <param name="paths"></param>
        /// <returns></returns>
        private static string[] OnWillSaveAssets(string[] paths)
        {
            Debug.Log($"OnWillSaveAssets{paths.Length}");

            return paths;
        }

        /// <summary>
        /// 是否可以打开编辑
        /// </summary>
        /// <param name="assetOrMetaFilePaths"></param>
        /// <param name="outNotEditablePaths"></param>
        /// <param name="statusQueryOptions"></param>
        /// <returns></returns>
        private static bool CanOpenForEdit(string[] assetOrMetaFilePaths, List<string> outNotEditablePaths, StatusQueryOptions statusQueryOptions)
        {
            Debug.Log("CanOpenForEdit:");

            foreach (var path in assetOrMetaFilePaths)
                Debug.Log(path);

            return true;
        }

        /// <summary>
        /// 是否已经打开编辑
        /// </summary>
        /// <param name="paths"></param>
        /// <param name="outNotEditablePaths"></param>
        /// <param name="statusQueryOptions"></param>
        /// <returns></returns>
        static bool IsOpenForEdit(string[] paths, List<string> outNotEditablePaths, StatusQueryOptions statusQueryOptions)
        {
            Debug.Log("IsOpenForEdit:");

            foreach (var path in paths)
                Debug.Log(path);

            return true;
        }

        /// <summary>
        /// 文件模式变更时调用
        /// </summary>
        /// <param name="paths"></param>
        /// <param name="mode"></param>
        private static void FileModeChanged(string[] paths, FileMode mode)
        {
            Debug.Log($"FileModeChanged{mode}");

            foreach (var path in paths)
            {
                Debug.Log(path);
            }
        }

        /// <summary>
        /// 是否可以编辑
        /// </summary>
        /// <param name="paths"></param>
        /// <param name="prompt"></param>
        /// <param name="outNotEditablePaths"></param>
        /// <returns></returns>
        private static bool MakeEditable(string[] paths, string prompt, List<string> outNotEditablePaths)
        {
            Debug.Log("MakeEditable:");

            foreach (var path in paths)
                Debug.Log(path);

            return true;
        }
    }
}