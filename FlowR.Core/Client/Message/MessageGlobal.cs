namespace FlowR.Library.Client.Message
{
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'MessageGlobal' visibile pubblicamente
    /// <inheritdoc />
    public class MessageGlobal : Message
    {
        /// <summary>
        /// Requested Action
        /// </summary>
        public MessageGlobal.MessageActions Action { get; set; }
        
        /// <summary>
        /// Possible Actions
        /// </summary>
        public enum MessageActions
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

        public override string GetRequestedAction()
        {
            return Action.ToString();
        }
    }

    /// <inheritdoc />
    public class MessageGlobalWithResponse : MessageWithResponse
    {
        
        /// <summary>
        /// Requested Action
        /// </summary>
        public MessageGlobalWithResponse.MessageActions Action { get; set; }
        
        /// <summary>
        /// Possible Actions
        /// </summary>
        public enum MessageActions
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

        public override string GetRequestedAction()
        {
            return Action.ToString();
        }
    }
}