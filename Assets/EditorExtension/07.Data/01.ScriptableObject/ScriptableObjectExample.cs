using UnityEngine;

namespace EditorExtension.Data.ScriptableObject
{
    /// <summary>
    /// ScriptableObjectÊ¾Àý
    /// </summary>
    [CreateAssetMenu()]
    public class ScriptableObjectExample : UnityEngine.ScriptableObject
    {
        public int InValue;
        public string StringValue;
    }
}