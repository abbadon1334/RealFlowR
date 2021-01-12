using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FlowR.Library.Client.Message
{
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'MessageEvent' visibile pubblicamente
    public class MessageEvent : Message
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'MessageEvent' visibile pubblicamente
    {
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'MessageEvent.EventArgs' visibile pubblicamente
        public readonly Dictionary<string, string> EventArgs = new();
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'MessageEvent.EventArgs' visibile pubblicamente
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'MessageEvent.EventName' visibile pubblicamente
        public string EventName;
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'MessageEvent.EventName' visibile pubblicamente

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'MessageEvent.FromJson(string)' visibile pubblicamente
        public static MessageEvent FromJson(string json)
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'MessageEvent.FromJson(string)' visibile pubblicamente
        {
            return JsonConvert.DeserializeObject<MessageEvent>(json);
        }
    }

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'MessageEventArgs' visibile pubblicamente
    public class MessageEventArgs : EventArgs
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'MessageEventArgs' visibile pubblicamente
    {
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'MessageEventArgs.Data' visibile pubblicamente
        public Dictionary<string, string> Data = new();
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'MessageEventArgs.Data' visibile pubblicamente
    }
}