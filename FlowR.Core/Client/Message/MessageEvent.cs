using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace FlowR.Library.Client.Message
{
    /// <summary>
    ///     Message Event sent from client
    /// </summary>
    public class MessageEvent : Message
    {
        
        /// <summary>
        /// Possible Actions
        /// </summary>
        public enum MessageEventActions { }
        /// <summary>
        ///     Event arguments
        /// </summary>
        public readonly Dictionary<string, string> EventArgs = new();

        /// <summary>
        ///     Name of the Event
        /// </summary>
        public string EventName;

        /// <summary>
        ///     Convert JSON to MessageEvent
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static MessageEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<MessageEvent>(json);
        }
        
        /// <summary>
        ///  
        /// </summary>
        /// <returns></returns>
        public override string GetRequestedAction()
        {
            throw new Exception("Event don't have an Action"); // @todo remove this no need
        }
    }

    /// <summary>
    ///     Message EventArguments
    /// </summary>
    public class MessageEventArgs : EventArgs
    {
        /// <summary>
        ///     Argument Dictionary Store
        /// </summary>
        public Dictionary<string, string> Data = new();
    }
}