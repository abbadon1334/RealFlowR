using System;
using System.Collections.Generic;
using System.Linq;

namespace FlowR.Library.Client.Message
{
    /// <summary>
    /// Base message Class
    /// </summary>
    public abstract class Message
    {
        private readonly Dictionary<string, object> Arguments = new();
        /// <summary>
        /// Message Uuid
        /// </summary>
        public string Uuid;

        /// <summary>
        /// Constructor
        /// </summary>
        protected Message()
        {
            // Generate Uuid
            Uuid = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Message Method name @todo i think is better to be changed in Action
        /// </summary>
        public string Method { get; set; }
        
        /// <summary>
        /// Get the Uuid of the message.
        /// </summary>
        /// <returns></returns>
        public string GetUuid() => Uuid;

        /// <summary>
        /// Add Argument to Argument list for the message.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void AddArgument(string name, object value)
        {
            Arguments[name] = value;
        }

        /// <summary>
        /// Get Arguments as array
        /// </summary>
        /// <returns></returns>
        public object[] GetArgumentValues()
        {
            return Arguments.Values.ToArray();
        }
    }
}