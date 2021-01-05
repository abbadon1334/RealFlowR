using System;

namespace FlowR.Library.Node
{
    public class DomNodeInitialize : DomNodeApplication
    {
        private bool _initialized = false;
        
        public void Init()
        {
            if (_initialized)
            {
                throw new Exception("Already initialized");
            }

            _initialized = true;
        }
    }
}