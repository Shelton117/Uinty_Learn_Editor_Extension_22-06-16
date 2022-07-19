using UnityEditor;
using UnityEngine;

namespace EditorExtension.UndoExample.Editor
{
    /// <summary>
    /// ¿É³·Ïú²Ù×÷
    /// </summary>
    public class UndoExample : MonoBehaviour
    {
        [MenuItem("EditorExtension/07.Undo/Create Obj")]
        static void CreateObj()
        {
            var newObj = new GameObject("Undo");
            Undo.RegisterCreatedObjectUndo(newObj, "CreateObj");
        }

        [MenuItem("EditorExtension/07.Undo/Move Obj")]
        static void MoveObj()
        {
            var trans = Selection.activeGameObject.transform;

            if (trans)
            {
                Undo.RecordObject(trans,"Move Obj");
                trans.position += Vector3.up;
            }
        }

        [MenuItem("EditorExtension/07.Undo/AddComponent Obj")]
        static void AddComponentObj()
        {
            var selectedObj = Selection.activeGameObject;

            if (selectedObj)
            {
                Undo.AddComponent(selectedObj, typeof(Rigidbody));
            }
        }

        [MenuItem("EditorExtension/07.Undo/Destroy Obj")]
        static void DestroyObj()
        {
            var selectedObj = Selection.activeGameObject;

            if (selectedObj)
            {
                Undo.DestroyObjectImmediate(selectedObj);
            }
        }

        [MenuItem("EditorExtension/07.Undo/SetParent Obj")]
        static void SetParentObj()
        {
            var trans = Selection.activeGameObject.transform;
            var root = Camera.main.transform;

            if (trans)
            {
                Undo.SetTransformParent(trans, root, trans.name);
            }
        }
        
        [MenuItem("EditorExtension/07.Undo/Move Obj", validate = true)]
        [MenuItem("EditorExtension/07.Undo/AddComponent Obj", validate = true)]
        [MenuItem("EditorExtension/07.Undo/Destroy Obj", validate = true)]
        [MenuItem("EditorExtension/07.Undo/SetParent Obj", validate = true)]
        static bool CheckValidate()
        {
            return Selection.activeGameObject != null;
        }
    }
}