using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

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
        [JsonInclude] public string Uuid;

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


        /// <inheritdoc />
        public object[] GetArgumentValues()
        {
            return _arguments.ToArray();
        }

        /// <inheritdoc />
        public virtual Task SendMessageAsync(ApplicationCommunication comm)
        {
            return comm.SendMessage(this);
        }

        /// <summary>
        ///     Add Argument to Argument list for the message.
        /// </summary>
        /// <param name="values"></param>
        protected void AddArgument(params object[] values)
        {
            foreach (var value in values) _arguments.Add(value);
        }
    }
}