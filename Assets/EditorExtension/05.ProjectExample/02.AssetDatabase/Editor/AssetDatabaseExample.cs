using System.IO;
using UnityEditor;
using UnityEngine;

namespace EditorExtension.ProjectExample.AssetDatabase.Editor
{
    public class AssetDatabaseExample : MonoBehaviour
    {
        private const string FolderPath = "Assets/EditorExtension/05.ProjectExample/02.AssetDatabase";
        private const string FolderName = "NewFolder";
        private const string NewFolderPath = FolderPath + "/" + FolderName;
        private const string NewMaterialPath = NewFolderPath + "/New Materials.mat";

        private const string MENU_PATH = "EditorExtension/03.Project/01.AssetDatabase";

        [MenuItem(MENU_PATH + "/Create Material")]
        private static void CreateMaterial()
        {
            if (!Directory.Exists(NewFolderPath))
            {
                string guid = UnityEditor.AssetDatabase.CreateFolder(FolderPath, FolderName);
                if (!string.IsNullOrEmpty(UnityEditor.AssetDatabase.GUIDToAssetPath(guid)))
                {
                    print("Folder Asset Created!" + guid);
                }
                else
                {
                    print(guid);
                }
            }

            var material = new Material(Shader.Find("Specular"));
            UnityEditor.AssetDatabase.CreateAsset(material, NewMaterialPath);

            if (UnityEditor.AssetDatabase.Contains(material))
            {
                print(material.name + "Created!");
            }
            else
            {
                print("Failed!");
            }
        }

        [MenuItem(MENU_PATH + "/Get MaterialGUID")]
        static void GetGUID()
        {
            Debug.Log(UnityEditor.AssetDatabase.AssetPathToGUID(NewMaterialPath));
        }

        [MenuItem(MENU_PATH + "/Load Material")]
        static void LoadGUID()
        {
            Debug.Log(UnityEditor.AssetDatabase.LoadAssetAtPath<Material>(NewMaterialPath));
        }

        [MenuItem(MENU_PATH + "/Rename Material")]
        static void Rename()
        {
            Debug.Log(UnityEditor.AssetDatabase.RenameAsset(NewMaterialPath,"New Name"));
        }

        [MenuItem(MENU_PATH + "/Move Material")]
        static void Move()
        {
            Debug.Log(UnityEditor.AssetDatabase.MoveAsset(NewMaterialPath, "Assets/move.mat"));
        }

        [MenuItem(MENU_PATH + "/Copy Material")]
        static void Copy()
        {
            Debug.Log(UnityEditor.AssetDatabase.CopyAsset(NewMaterialPath, "Assets/copy.mat"));
        }

        [MenuItem(MENU_PATH + "/Delete Material")]
        static void Delete()
        {
            UnityEditor.AssetDatabase.MoveAssetToTrash(NewMaterialPath); // 进回收站

            UnityEditor.AssetDatabase.DeleteAsset(NewMaterialPath);

            UnityEditor.AssetDatabase.Refresh(); // 刷新
        }

        [MenuItem(MENU_PATH + "/Get MaterialGUID", validate = true)]
        [MenuItem(MENU_PATH + "/Load Material", validate = true)]
        [MenuItem(MENU_PATH + "/Rename Material", validate = true)]
        [MenuItem(MENU_PATH + "/Move Material", validate = true)]
        [MenuItem(MENU_PATH + "/Copy Material", validate = true)]
        [MenuItem(MENU_PATH + "/Delete Material", validate = true)]
        static bool GetGUIDValidate()
        {
            return File.Exists(NewMaterialPath);
        }
    }
}