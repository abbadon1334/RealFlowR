using System;
using FlowR.Library.Client;

namespace FlowR.Library.Node
{
    /// <summary>
    /// Manage Application
    /// </summary>
    public abstract class DomNodeApplication : DomNodeOwner
    {
        private Application _application;

        /// <summary>
        /// Set the Application
        /// </summary>
        /// <exception cref="Exception">Cannot be set multiple times</exception>
        public void SetApplication(Application application)
        {
            if (_application != null)
            {
                throw new Exception("Application already defined");
            }
            
            _application = application;
        }

        /// <summary>
        /// Get the Application
        /// </summary>
        /// <returns></returns>
        public Application GetApplication()
        {
            return _application;
        }
    }
}