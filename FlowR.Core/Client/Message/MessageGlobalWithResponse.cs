namespace FlowR.Library.Client.Message
{
    /// <inheritdoc />
    public class MessageGlobalWithResponse : MessageResponse
    {
        /// <inheritdoc />
        public MessageGlobalWithResponse(string name, string[] arguments = null) : base()
        {
            AddArgument("Name", name);
            if (arguments != null)
            {
                AddArgument("Arguments", arguments);
            }
        }

        /// <summary>
        /// Requested Action
        /// </summary>
        public MessageActions Action { get; set; }
        
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

        /// <inheritdoc />
        public override string GetRequestedAction()
        {
            return Action.ToString();
        }
    }
}