using UnityEngine;

namespace EditorExtension.InspectorExample.Attribute
{
    /// <summary>
    /// 属性工具示例
    /// 包含自定义
    /// </summary>
    [HelpURL("https://unity.cn")]
    public class AttributeExample : MonoBehaviour
    {
        public int Age;
        [HideInInspector] public int Age1;

        [Header("年龄")] [SerializeField] private int Age2;

        [Space(20)] // 行距（像素）
        public int Age3;
        [Multiline(3)] // （显示）默认为3行
        public string Comment;
        [TextArea]
        public string Comment1;
        [Range(5,10)]
        public int Age4;
        [My]
        public int Age5;
    }
}