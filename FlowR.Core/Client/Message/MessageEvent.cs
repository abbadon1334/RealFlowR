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
        // {"Uuid":"33db7762-0f15-4991-b264-7c3cc2e617b7","EventName":"click","EventArgs":{}}

        /// <summary>
        ///     Event arguments
        /// </summary>
        public readonly Dictionary<string, string> EventArgs = new();

        /// <summary>
        ///     Name of the Event
        /// </summary>
        public string EventName { get; set; }

        /// <summary>
        ///     Convert JSON to MessageEvent
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static MessageEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<MessageEvent>(json);
        }

        /// <inheritdoc />
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