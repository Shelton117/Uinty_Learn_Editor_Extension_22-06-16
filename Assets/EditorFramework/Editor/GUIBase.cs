using System;
using UnityEngine;

namespace EditorFramework.Editor
{
    /// <summary>
    /// ���׵�GUI���
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
        /// �Զ���������
        /// using��new GUIBase������{}���Զ����ٶ���
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