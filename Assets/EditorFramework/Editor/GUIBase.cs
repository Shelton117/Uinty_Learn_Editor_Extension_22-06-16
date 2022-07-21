using System;
using UnityEngine;

namespace EditorFramework.Editor
{
    /// <summary>
    /// 简易的GUI框架
    /// </summary>
    public abstract class GUIBase:IDisposable
    {
        protected bool mDisposed { get; private set; }
        protected Rect mPosition { get; set; }

        public virtual void OnGUI(Rect position)
        {
            mPosition = position;
        }

        /// <summary>
        /// 自动垃圾回收
        /// using（new GUIBase（））{}后自动销毁对象
        /// </summary>
        public virtual void Dispose()
        {
            if (mDisposed) return;
            OnDispose();
            mDisposed = true;
        }

        protected abstract void OnDispose();
    }
}