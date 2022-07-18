using UnityEditor;
using UnityEngine;

namespace EditorExtension.EventCurrentExample.Editor
{
    [InitializeOnLoad]
    public class EventCurrentExample : EditorWindow
    {
        [MenuItem("EditorExtension/05.Event/Current")]
        static void Open()
        {
            GetWindow<EventCurrentExample>().Show();
        }

        void OnGUI()
        {
            var e = Event.current;

            EditorGUILayout.Toggle("alt", e.alt);
            EditorGUILayout.IntField("button", e.button);
            EditorGUILayout.Toggle("capsLock", e.capsLock);
            EditorGUILayout.IntField(nameof(e.clickCount), e.clickCount);
            EditorGUILayout.Toggle(nameof(e.command), e.command);
            EditorGUILayout.LabelField(nameof(e.commandName), e.commandName);
            EditorGUILayout.Toggle("control", e.control);
            EditorGUILayout.Vector2Field("delta", e.delta);
            EditorGUILayout.IntField("displayIndex", e.displayIndex);
            EditorGUILayout.Toggle("functionKey", e.functionKey);
            EditorGUILayout.Toggle("isKey ", e.isKey);
            EditorGUILayout.Toggle("isMouse", e.isMouse);
            EditorGUILayout.Toggle("isScrollWheel", e.isScrollWheel);
            EditorGUILayout.EnumPopup("keyCode", e.keyCode);

            EditorGUILayout.EnumPopup("modifiers", e.modifiers);
            EditorGUILayout.Vector2Field("mousePosition", e.mousePosition);
            EditorGUILayout.Toggle("numeric", e.numeric);
            EditorGUILayout.EnumPopup("pointerType", e.pointerType);
            EditorGUILayout.FloatField("pressure", e.pressure);
            EditorGUILayout.EnumPopup("rawType", e.rawType);
            EditorGUILayout.Toggle("shift", e.shift);
            EditorGUILayout.EnumPopup("type", e.type);

            Repaint(); // ÷ÿ∏¥ªÊ÷∆
        }
    }
}