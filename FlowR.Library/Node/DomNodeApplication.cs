using FlowR.Library.Client;

namespace FlowR.Library.Node
{
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeApplication' visibile pubblicamente
    public class DomNodeApplication : DomNodeOwner
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeApplication' visibile pubblicamente
    {
        private Application _application;

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeApplication.SetApplication(Application)' visibile pubblicamente
        public void SetApplication(Application application)
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeApplication.SetApplication(Application)' visibile pubblicamente
        {
            _application = application;
        }

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeApplication.GetApplication()' visibile pubblicamente
        public Application GetApplication()
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'DomNodeApplication.GetApplication()' visibile pubblicamente
        {
            return _application;
        }
    }
}