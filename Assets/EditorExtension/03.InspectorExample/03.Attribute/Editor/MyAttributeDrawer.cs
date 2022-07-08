using UnityEditor;
using UnityEngine;

namespace EditorExtension.InspectorExample.Attribute.Editor
{
    /// <summary>
    /// 自定义绘制属性标签
    /// MyAttribute 的渲染器
    /// </summary>
    [CustomPropertyDrawer(typeof(MyAttribute))]
    public class MyAttributeDrawer : PropertyDrawer
    {
        private float high = 20;
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            GUI.Label(new Rect(position.position, new Vector2(position.width, high)), "MayAttributeDrawer");
            // ???
            EditorGUI.PropertyField(new Rect(position.x, position.y + high, position.width, position.height - high),
                property, label);
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return base.GetPropertyHeight(property, label) + high;// OnGUI中加了20
        }
    }
}