using System;
using System.Collections.Generic;
using System.Text.Json;

namespace FlowR.Library.Client.Message
{
    public abstract class Message
    {
        public string Method { get; set; }
        public readonly Dictionary<string,object> Arguments = new();

        public void AddArgument(string name, object value)
        {
            Arguments[name] = value;
        }

        public virtual string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}