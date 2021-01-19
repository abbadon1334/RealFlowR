namespace FlowR.Core.Message
{
    /// <inheritdoc />
    public class MessageGlobalWithResponse : MessageResponse
    {

        /// <summary>
        ///     Possible Actions
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

        /// <inheritdoc />
        public MessageGlobalWithResponse(string name, string[] arguments = null)
        {
            AddArgument(name);
            if (arguments != null) AddArgument(arguments);
        }

        /// <summary>
        ///     Requested Action
        /// </summary>
        public MessageActions Action { get; set; }

        /// <inheritdoc />
        public override string GetRequestedAction()
        {
            return Action.ToString();
        }
    }
}