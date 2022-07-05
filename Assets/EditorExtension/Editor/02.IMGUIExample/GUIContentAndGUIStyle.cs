using System;
using UnityEditor;
using UnityEngine;

namespace EditorExtension.Editor.IMGUIExample
{
    public class GUIContentAndGUIStyle : EditorWindow
    {
        enum Mode
        {
            GUIContent,
            GUIStyle,
        }

        private int mToolbarIndex;
        private GUIStyle mBoxStyle = "box";
        /// <summary>
        /// 拷贝GUIStyle效果
        /// 防止全局应用
        /// </summary>
        private Lazy<GUIStyle> mFontStyle = new Lazy<GUIStyle>(() =>
        {
            var retStyle = new GUIStyle("label");
            retStyle.fontSize = 30;
            retStyle.fontStyle = FontStyle.BoldAndItalic;

            // 设置字体颜色
            // 根据状态
            retStyle.normal.textColor = Color.red;
            retStyle.hover.textColor = Color.black;
            retStyle.focused.textColor = Color.yellow;
            retStyle.active.textColor = Color.cyan;

            // 设置背景
            retStyle.normal.background = Texture2D.whiteTexture;

            return retStyle;
        });

        private Lazy<GUIStyle> mButtonStyle = new Lazy<GUIStyle>(() =>
        {
            var retStyle = new GUIStyle("button");
            retStyle.fontSize = 30;
            retStyle.fontStyle = FontStyle.BoldAndItalic;

            // 设置字体颜色
            // 根据状态
            retStyle.normal.textColor = Color.red;
            retStyle.hover.textColor = Color.black;
            retStyle.focused.textColor = Color.yellow;
            retStyle.active.textColor = Color.cyan;

            // 设置背景
            retStyle.normal.background = Texture2D.whiteTexture;

            return retStyle;
        });

        private void OnEnable()
        {
            
        }

        private void OnGUI()
        {
            mToolbarIndex = GUILayout.Toolbar(mToolbarIndex, Enum.GetNames(typeof(Mode)));

            if (mToolbarIndex == (int)Mode.GUIContent)
            {
                GUILayout.Label("GUIContent");
                GUILayout.Label(new GUIContent("GUIContent"));
                GUILayout.Label(new GUIContent("GUIContent", "OnMouse"));
                GUILayout.Label(new GUIContent("GUIContent", Texture2D.grayTexture));
                GUILayout.Label(new GUIContent("GUIContent", Texture2D.grayTexture, "OnMouse"));
            }
            else if (mToolbarIndex == (int)Mode.GUIStyle)
            {
                GUILayout.Label("GUIStyle");
                GUILayout.Label("GUIStyle", mBoxStyle);
                GUILayout.Label("GUIStyle", mFontStyle.Value);

                GUILayout.Button("Button font", mButtonStyle.Value);
            }
        }

        [MenuItem("EditorExtension/02.IMGUI/02.GUIContentAndGUIStyle")]
        static void Open()
        {
            GetWindow<GUIContentAndGUIStyle>().Show();
        }
    }
}