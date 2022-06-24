using System;
using UnityEngine;

namespace EditorFramework.Editor
{
    /// <summary>
    /// ���׵�GUI���
    /// </summary>
    public abstract class GUIBase:IDisposable
    {
        public bool mDisposed { get; private set; }
        public Rect mPosition { get; private set; }

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