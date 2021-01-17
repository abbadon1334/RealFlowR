using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace FlowR.Core.Message
{
    /// <summary>
    ///     Message Class
    /// </summary>
    public abstract class Message : IMessage
    {
        private readonly List<object> _arguments = new();

        /// <summary>
        ///     Message Uuid
        /// </summary>
        [JsonInclude]
        public string Uuid;

        /// <summary>
        ///     Constructor
        /// </summary>
        protected Message()
        {
            // Generate Uuid
            Uuid = Guid.NewGuid().ToString();
        }

        /// <summary>
        ///     Get the Uuid of the message.
        /// </summary>
        /// <returns></returns>
        public string GetUuid()
        {
            return Uuid;
        }

        /// <summary>
        ///     Get Action as string
        /// </summary>
        /// <returns></returns>
        public abstract string GetRequestedAction();

        /// <summary>
        ///     Get Arguments as array
        /// </summary>
        /// <returns></returns>
        public object[] GetArgumentValues()
        {
            return _arguments.ToArray();
        }

        /// <summary>
        ///     Add Argument to Argument list for the message.
        /// </summary>
        /// <param name="values"></param>
        public void AddArgument(params object[] values)
        {
            foreach (var value in values)
            {
                _arguments.Add(value);   
            }
        }
    }
}