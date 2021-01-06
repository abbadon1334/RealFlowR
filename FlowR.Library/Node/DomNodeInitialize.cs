using System;

namespace FlowR.Library.Node
{
    public class DomNodeInitialize
    {
        private bool _initialized;

        public void Init()
        {
            if (IsInitialized()) throw new Exception("Already initialized");

            _initialized = true;
        }

        public bool IsInitialized()
        {
            return _initialized;
        }
    }
}