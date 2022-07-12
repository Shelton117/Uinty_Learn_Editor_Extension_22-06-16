using UnityEditor;
using UnityEngine;

namespace EditorExtension.ProjectExample.AssetPostprocessor.Editor
{
    /// <summary>
    /// 针对导入（Texture2D）进行一些修改（预处理）
    /// </summary>
    public class AssetPostprocessorExample : UnityEditor.AssetPostprocessor
    {
        /// <summary>
        /// Texture预处理
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
        /// 后期处理
        /// </summary>
        /// <param name="texture"></param>
        private void OnPostprocessTexture(Texture2D texture)
        {
            Debug.Log("OnPostprocessTexture" + texture.name);
        }
    }
}