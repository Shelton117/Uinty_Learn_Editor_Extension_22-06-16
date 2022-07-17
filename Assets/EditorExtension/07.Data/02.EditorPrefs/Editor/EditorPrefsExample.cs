using System;
using UnityEditor;
using UnityEngine;

namespace EditorExtension.Data.EditorPrefs.Editor
{
    /// <summary>
    /// ¥Ê¥¢∫Õ∑√Œ  Unity ±‡º≠∆˜∆´∫√…Ë÷√
    /// </summary>
    public class EditorPrefsExample
    {
        private const string key = "123123";

        [MenuItem("EditorExtension/04.Data/EditorPrefs/SaveTime")]
        private static void SaveTime()
        {
            UnityEditor.EditorPrefs.SetString(key,DateTime.Now.ToString());
        }

        [MenuItem("EditorExtension/04.Data/EditorPrefs/ReadTime")]
        private static void ReadTime()
        {
            Debug.Log(UnityEditor.EditorPrefs.GetString(key));
        }
    }
}