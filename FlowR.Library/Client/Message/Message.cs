using System;
using System.Collections.Generic;
using System.Linq;

namespace FlowR.Library.Client.Message
{
    public abstract class Message
    {
        public Dictionary<string, object> Arguments = new();
        public string Uuid;

        public Message()
        {
            Uuid = Guid.NewGuid().ToString();
        }

        public string Method { get; set; }

        public string GetUuid()
        {
            return Uuid;
        }

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