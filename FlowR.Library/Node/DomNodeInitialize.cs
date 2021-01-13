using System;

namespace FlowR.Library.Node
{
    /// <summary>
    ///     Manage the initialize method
    /// </summary>
    public abstract class DomNodeInitialize : DomNodeUuid
    {
        private bool _initialized;

        /// <summary>
        ///     Starting point of every component.
        ///     Will be called after attach to Parent.
        ///     This is the method you are looking for if you want to make a component
        /// </summary>
        /// <exception cref="Exception">Cannot be called multiple times</exception>
        public virtual void Init()
        {
            if (IsInitialized()) throw new Exception("Already initialized");
            _initialized = true;
        }

        /// <summary>
        ///     Return if the DomNode is initialized.
        /// </summary>
        /// <returns></returns>
        protected bool IsInitialized()
        {
            return _initialized;
        }
    }
}