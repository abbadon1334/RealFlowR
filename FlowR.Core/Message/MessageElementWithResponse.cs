namespace FlowR.Core.Message
{
    /// <summary>
    ///     Message waiting Response for Clientside Nodes
    /// </summary>
    public class MessageElementWithResponse : MessageResponse
    {

        /// <summary>
        ///     Possible Actions
        /// </summary>
        public enum MessageActions
        {
            /// <summary>
            ///     Get Property from Element
            /// </summary>
            GetProperty,

            /// <summary>
            ///     Call method and wait for response
            /// </summary>
            CallMethodGetResponse
        }

        /// <inheritdoc />
        public MessageElementWithResponse(Node node)
        {
            AddArgument(node.Uuid);
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