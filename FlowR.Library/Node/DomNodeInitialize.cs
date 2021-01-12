using System;

namespace FlowR.Library.Node
{
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeInitialize' visibile pubblicamente
    public class DomNodeInitialize : DomNodeUuid
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeInitialize' visibile pubblicamente
    {
        private bool _initialized;

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeInitialize.Init()' visibile pubblicamente
        public void Init()
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeInitialize.Init()' visibile pubblicamente
        {
            if (IsInitialized()) throw new Exception("Already initialized");

            _initialized = true;
        }

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeInitialize.IsInitialized()' visibile pubblicamente
        protected bool IsInitialized()
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeInitialize.IsInitialized()' visibile pubblicamente
        {
            return _initialized;
        }
    }
}