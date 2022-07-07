using System.IO;
using UnityEngine;

namespace EditorFramework.Editor
{
    /// <summary>
    /// ×Ö·û´®£¨¾²Ì¬£©À©Õ¹
    /// </summary>
    public static class StringExtension
    {
        public static string ToAssetsPath(this string self)
        {
            var assetsFullPath = Path.GetFullPath(Application.dataPath);
            
            return "Assets" + Path.GetFullPath(self).Substring(assetsFullPath.Length).Replace("\\", "/");
        }

        public static bool IsDirectory(this string self)
        {
            var fileInfo = new FileInfo(self);
            return (fileInfo.Attributes & FileAttributes.Directory) != 0;
        }
    }
}