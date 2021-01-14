using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FlowR.Library.Client.Message
{
    /// <summary>
    ///     Message Class
    /// </summary>
    public abstract class Message : IMessage
    {
        private readonly Dictionary<string, object> _arguments = new();

        /// <summary>
        ///     Message Uuid
        /// </summary>
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
        ///     Add Argument to Argument list for the message.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void AddArgument(string name, object value)
        {
            _arguments[name] = value;
        }

        /// <summary>
        /// Get Action as string
        /// </summary>
        /// <returns></returns>
        public abstract string GetRequestedAction();
        
        /// <summary>
        ///     Get Arguments as array
        /// </summary>
        /// <returns></returns>
        public object[] GetArgumentValues()
        {
            return _arguments.Values.ToArray();
        }
    }
}