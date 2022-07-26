using UnityEditor;
using UnityEngine;

namespace EditorExtension.PopupWindowExample.Editor
{
    public class PopupWindowExample : EditorWindow
    {
        [MenuItem("EditorExtension/09.PopupWindow/Open")]
        private static void Open()
        {
            GetWindow<PopupWindowExample>().Show();
        }

        private Rect mButtonRect;

        private void OnGUI()
        {
            if (GUILayout.Button("Popup Options",GUILayout.Width(200)))
            {
                PopupWindow.Show(mButtonRect,new PopupWindowContentExample());
            }

            if (Event.current.type == EventType.Repaint)
            {
                mButtonRect = GUILayoutUtility.GetLastRect();
            }
        }
        
        public class PopupWindowContentExample: PopupWindowContent
        {
            private bool mToggle1 = true;
            private bool mToggle2 = true;
            private bool mToggle3 = true;

            public override void OnGUI(Rect rect)
            {
                GUILayout.Label("Popup Options Example", EditorStyles.boldLabel);

                mToggle1 = EditorGUILayout.Toggle("Toggle 1", mToggle1);
                mToggle2 = EditorGUILayout.Toggle("Toggle 2", mToggle2);
                mToggle3 = EditorGUILayout.Toggle("Toggle 3", mToggle3);
            }

            #region 生命周期

            /// <summary>
            /// 打开
            /// </summary>
            public override void OnOpen()
            {
                Debug.Log("OnOpen");
            }

            /// <summary>
            /// 关闭
            /// </summary>
            public override void OnClose()
            {
                Debug.Log("OnClose");
            }

            /// <summary>
            /// （返回）大小
            /// </summary>
            /// <returns></returns>
            public override Vector2 GetWindowSize()
            {
                return new Vector2(200, 150);
            }

            #endregion


        }
    }
}