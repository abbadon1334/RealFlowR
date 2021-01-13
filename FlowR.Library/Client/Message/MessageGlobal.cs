namespace FlowR.Library.Client.Message
{
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'MessageGlobal' visibile pubblicamente
    /// <inheritdoc />
    public class MessageGlobal : Message
    {
        /// <inheritdoc cref="Message.Method" />
        /// >
        public enum MethodName
        {
            /// <summary>
            ///     Call Global Method
            /// </summary>
            CallGlobalMethod,

            /// <summary>
            ///     Set Property
            /// </summary>
            SetProperty
        }
    }

    /// <inheritdoc />
    public class MessageGlobalWithResponse : MessageWithResponse
    {
        /// <inheritdoc cref="Message.Method" />
        /// />
        public enum MethodName
        {
            /// <summary>
            ///     Call a Global method and wait for response
            /// </summary>
            CallGlobalMethodGetResponse,

            /// <summary>
            ///     Call a Global method and wait for response
            /// </summary>
            GetGlobalProperty
        }
    }
}