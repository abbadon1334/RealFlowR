using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace FlowR.Library.Client.Message
{
    public abstract class Message
    {
        public string Uuid;
        public string Method { get; set; }
        public Dictionary<string, object> Arguments = new();

        public Message()
        {
            Uuid = Guid.NewGuid().ToString();
        }

        public string GetUuid() => Uuid;
        
        public void AddArgument(string name, object value)
        {
            Arguments[name] = value;
        }

        public object[] GetArgumentValues()
        {
            return Arguments.Values.ToArray();
        }
    }
}