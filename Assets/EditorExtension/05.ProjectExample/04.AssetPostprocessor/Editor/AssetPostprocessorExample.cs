using UnityEditor;
using UnityEngine;

namespace EditorExtension.ProjectExample.AssetPostprocessor.Editor
{
    /// <summary>
    /// ��Ե��루Texture2D������һЩ�޸ģ�Ԥ����
    /// </summary>
    public class AssetPostprocessorExample : UnityEditor.AssetPostprocessor
    {
        /// <summary>
        /// TextureԤ����
        /// </summary>
        private void OnPreprocessTexture()
        {
            Debug.Log("OnPreprocessTexture" + this.assetPath);

            TextureImporter importer = this.assetImporter as TextureImporter;
            importer.textureType = TextureImporterType.Sprite;
            importer.maxTextureSize = 512;
            importer.mipmapEnabled = false;
        }

        /// <summary>
        /// ���ڴ���
        /// </summary>
        /// <param name="texture"></param>
        private void OnPostprocessTexture(Texture2D texture)
        {
            Debug.Log("OnPostprocessTexture" + texture.name);
        }
    }
}