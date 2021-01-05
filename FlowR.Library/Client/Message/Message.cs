using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FlowR.Library.Client.Message
{
    public abstract class Message
    {
        private readonly Dictionary<string, object> _dictionary = new Dictionary<string, object>();

        public void SetProperty(string name, object value)
        {
            _dictionary[name] = value;
        }

        public string ToJson()
        {
            return JsonSerializer.Serialize(this._dictionary);
        }
    }
}