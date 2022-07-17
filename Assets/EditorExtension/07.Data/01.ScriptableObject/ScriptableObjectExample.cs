using UnityEngine;

namespace EditorExtension.Data.ScriptableObject
{
    /// <summary>
    /// ScriptableObjectʾ��
    /// </summary>
    [CreateAssetMenu()]
    public class ScriptableObjectExample : UnityEngine.ScriptableObject
    {
        public int InValue;
        public string StringValue;
    }
}