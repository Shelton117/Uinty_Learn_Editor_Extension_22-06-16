using UnityEngine;

namespace EditorExtension.Scene.Gizmos
{
    /// <summary>
    /// scene�����������ͼ��
    /// </summary>
    public class GizmosExample : MonoBehaviour
    {
        /// <summary>
        /// ֱ�ӻ���
        /// </summary>
        private void OnDrawGizmos()
        {
            var color = UnityEngine.Gizmos.color;
            UnityEngine.Gizmos.color = Color.blue;
            UnityEngine.Gizmos.DrawCube(Vector3.zero, Vector3.one);
            UnityEngine.Gizmos.DrawWireCube(Vector3.one, Vector3.one);
            UnityEngine.Gizmos.DrawGUITexture(new Rect(Vector2.zero, Vector2.one * 5f), Texture2D.whiteTexture);
            UnityEngine.Gizmos.color = color;
        }

        /// <summary>
        /// ѡ��ʱ���û���
        /// </summary>
        private void OnDrawGizmosSelected()
        {
            var color = UnityEngine.Gizmos.color;
            UnityEngine.Gizmos.color = Color.red;
            UnityEngine.Gizmos.DrawWireCube(transform.position,Vector3.one);
            UnityEngine.Gizmos.color = color;
        }

#if UNITY_EDITOR
        /// <summary>
        /// ��̬������Ⱦgizmos
        /// </summary>
        /// <param name="targer"></param>
        /// <param name="gizmoType"></param>
        [UnityEditor.DrawGizmo(UnityEditor.GizmoType.Active | UnityEditor.GizmoType.Selected)]
        private static void MyCustomOnDrawGizmos(GizmosExample targer,UnityEditor.GizmoType gizmoType)
        {
            var color = UnityEngine.Gizmos.color;
            UnityEngine.Gizmos.color = Color.green;
            UnityEngine.Gizmos.DrawCube(targer.transform.position + Vector3.one, Vector3.one);
            UnityEngine.Gizmos.color = color;
        }
#endif
    }
}