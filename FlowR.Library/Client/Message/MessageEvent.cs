using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FlowR.Library.Client.Message
{
    public class MessageEvent : Message
    {
        public string EventName;
        public readonly Dictionary<string, string> EventArgs = new();

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