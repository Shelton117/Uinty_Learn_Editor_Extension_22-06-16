using UnityEngine;

namespace EditorExtension.InspectorExample.Attribute
{
    /// <summary>
    /// ���Թ���ʾ��
    /// �����Զ���
    /// </summary>
    [HelpURL("https://unity.cn")]
    public class AttributeExample : MonoBehaviour
    {
        public int Age;
        [HideInInspector] public int Age1;

        [Header("����")] [SerializeField] private int Age2;

        [Space(20)] // �оࣨ���أ�
        public int Age3;
        [Multiline(3)] // ����ʾ��Ĭ��Ϊ3��
        public string Comment;
        [TextArea]
        public string Comment1;
        [Range(5,10)]
        public int Age4;
        [My]
        public int Age5;
    }
}