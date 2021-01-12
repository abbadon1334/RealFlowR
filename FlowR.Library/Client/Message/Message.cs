using System;
using System.Collections.Generic;
using System.Linq;

namespace FlowR.Library.Client.Message
{
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'Message' visibile pubblicamente
    public abstract class Message
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'Message' visibile pubblicamente
    {
        private readonly Dictionary<string, object> Arguments = new();
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'Message.Uuid' visibile pubblicamente
        public string Uuid;
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'Message.Uuid' visibile pubblicamente

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'Message.Message()' visibile pubblicamente
        protected Message()
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'Message.Message()' visibile pubblicamente
        {
            Uuid = Guid.NewGuid().ToString();
        }

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'Message.Method' visibile pubblicamente
        public string Method { get; set; }
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'Message.Method' visibile pubblicamente

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'Message.GetUuid()' visibile pubblicamente
        public string GetUuid()
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'Message.GetUuid()' visibile pubblicamente
        {
            return Uuid;
        }

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'Message.AddArgument(string, object)' visibile pubblicamente
        public void AddArgument(string name, object value)
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'Message.AddArgument(string, object)' visibile pubblicamente
        {
            Arguments[name] = value;
        }

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'Message.GetArgumentValues()' visibile pubblicamente
        public object[] GetArgumentValues()
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'Message.GetArgumentValues()' visibile pubblicamente
        {
            return Arguments.Values.ToArray();
        }
    }
}