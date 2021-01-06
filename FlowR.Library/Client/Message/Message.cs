using System;
using System.Collections.Generic;
using System.Text.Json;

namespace FlowR.Library.Client.Message
{
    public abstract class Message
    {
        private readonly Dictionary<string, object> _dictionary = new();

        public void SetProperty(string name, object value)
        {
            _dictionary[name] = value;
        }

        public virtual string ToJson()
        {
            return JsonSerializer.Serialize(_dictionary);
        }
    }
}