using FlowR.Library.Client;

namespace FlowR.Library.Node
{
    public class DomNodeApplication : DomNodeOwner
    {
        private Application _application;

        public void SetApplication(Application application)
        {
            _application = application;
        }

        public Application GetApplication()
        {
            return _application;
        }
    }
}