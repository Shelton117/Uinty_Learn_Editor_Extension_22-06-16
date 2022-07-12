using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace EditorExtension.ProjectExample.AssetModificationProcessor.Editor
{
    /// <summary>
    /// ������ԴĿ¼�����½��ƶ�ɾ���ȣ�
    /// </summary>
    public class AssetModificationProcessorExample : UnityEditor.AssetModificationProcessor
    {
        /// <summary>
        /// ����asset��ʱ����õĺ���
        /// </summary>
        /// <param name="assetName">��Դ����</param>
        private static void OnWillCreateAsset(string assetName)
        {
            Debug.Log($"OnWillCreateAsset{assetName}");
        }

        /// <summary>
        /// ɾ��asset��ʱ�����
        /// </summary>
        /// <param name="assetPath">ɾ��·��</param>
        /// <param name="options">ɾ����ʽ</param>
        /// <returns></returns>
        private static AssetDeleteResult OnWillDeleteAsset(string assetPath, RemoveAssetOptions options)
        {
            Debug.Log($"OnWillDeleteAsset{assetPath}/{options}");

            // ϵͳ������������ť�ģ�
            if (EditorUtility.DisplayDialog("Warning!","Delete or not?","yes","no"))
            {
                return AssetDeleteResult.DidNotDelete;
            }

            return AssetDeleteResult.FailedDelete;
        }

        /// <summary>
        /// �ƶ�asset��ʱ�����
        /// </summary>
        /// <param name="sourcePath">��ʼĿ¼</param>
        /// <param name="destinationPath">Ŀ��Ŀ¼</param>
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
        /// ����asset��ʱ�����
        /// </summary>
        /// <param name="paths"></param>
        /// <returns></returns>
        private static string[] OnWillSaveAssets(string[] paths)
        {
            Debug.Log($"OnWillSaveAssets{paths.Length}");

            return paths;
        }

        /// <summary>
        /// �Ƿ���Դ򿪱༭
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
        /// �Ƿ��Ѿ��򿪱༭
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
        /// �ļ�ģʽ���ʱ����
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
        /// �Ƿ���Ա༭
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