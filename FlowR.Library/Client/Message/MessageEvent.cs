using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace FlowR.Library.Client.Message
{
    public class MessageEvent : Message
    {
        public readonly Dictionary<string, string> EventArgs = new();
        public string EventName;

        public static MessageEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<MessageEvent>(json);
        }
    }

    public class MessageEventArgs : EventArgs
    {
        public Dictionary<string, string> Data = new();
    }
}