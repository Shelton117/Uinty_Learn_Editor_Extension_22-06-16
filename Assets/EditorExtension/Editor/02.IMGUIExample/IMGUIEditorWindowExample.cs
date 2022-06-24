using System;
using UnityEditor;
using UnityEngine;

namespace EditorExtension.Editor.IMGUIExample
{
    /// <summary>
    /// 非运行状态下的IMGUI载体：EditorWindow
    /// </summary>
    public class IMGUIEditorWindowExample : EditorWindow
    {
        enum APIMode
        {
            GUILayout,
            GUI,
        }

        enum PageID
        {
            Basic,
            Enabled,
            Rotate,
            Scale,
            Color,
            Other,
        }

        private APIMode mCurrentAPIMode = APIMode.GUILayout;
        private PageID mCurrentPageId = PageID.Basic;
        private GUILayoutAPI mGUILayoutAPI = new GUILayoutAPI();
        private GUIAPI mGUIAPI = new GUIAPI();

        [MenuItem("EditorExtension/02.IMGUI/01.IMGUIEditorWindowExample")]
        static void OpenGUILayoutExample()
        {
            GetWindow<IMGUIEditorWindowExample>().Show();
        }

        private void OnGUI()
        {
            // 从枚举中获取页签id（int）和名称（string[]）
            mCurrentAPIMode = (APIMode)GUILayout.Toolbar((int)mCurrentAPIMode, Enum.GetNames(typeof(APIMode)));
            mCurrentPageId = (PageID) GUILayout.Toolbar((int) mCurrentPageId, Enum.GetNames(typeof(PageID)));

            if (mCurrentPageId == PageID.Basic)
            {
                Basic();
            }
            else if (mCurrentPageId == PageID.Enabled)
            {
                Enabled();
            }
            else if (mCurrentPageId == PageID.Rotate)
            {
                Rotate();
            }
            else if (mCurrentPageId == PageID.Scale)
            {
                Scale();
            }
            else if (mCurrentPageId == PageID.Color)
            {
                Color();
            }
            else if (mCurrentPageId == PageID.Other)
            {
                // 函数体为空，对照
            }
        }

        #region Basic

        private void Basic()
        {
            if (mCurrentAPIMode == APIMode.GUILayout)
            {
                mGUILayoutAPI.Draw();
            }
            else if (mCurrentAPIMode == APIMode.GUI)
            {
                mGUIAPI.Draw();
            }
        }

        #endregion

        #region Enabled

        private bool mEnableInteractive = true;
        private void Enabled()
        {
            mEnableInteractive = GUILayout.Toggle(mEnableInteractive, "是否可交互");

            if (GUI.enabled != mEnableInteractive)
            {
                GUI.enabled = mEnableInteractive;
            }

            Basic();
        }

        #endregion

        #region Rotate

        private bool mOpenRotateEffect;
        private void Rotate()
        {
            mOpenRotateEffect = GUILayout.Toggle(mOpenRotateEffect, "是否旋转");

            if (mOpenRotateEffect)
            {
                GUIUtility.RotateAroundPivot(45, Vector2.zero);
            }

            Basic();
        }

        #endregion

        #region Scale

        private bool mOpenScaleEffect;
        private void Scale()
        {
            mOpenScaleEffect = GUILayout.Toggle(mOpenScaleEffect, "是否缩放");

            if (mOpenScaleEffect)
            {
                GUIUtility.ScaleAroundPivot(new Vector2(1.5f,1.5f), Vector2.zero);
            }

            Basic();
        }

        #endregion

        #region Color

        private bool mOpenColorEffect;
        private void Color()
        {
            mOpenColorEffect = GUILayout.Toggle(mOpenColorEffect, "是否变换颜色");
            if (mOpenColorEffect)
            {
                GUI.color = UnityEngine.Color.blue;
            }

            Basic();
        }

        #endregion
    }
}