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
            CallMethodGetResponse,
        }

        /// <inheritdoc />
        public MessageElementWithResponse(INode node, MessageActions action, params object[] args)
        {
            AddArgument(node.GetUuid());

            foreach (var o in args)
            {
                AddArgument(o);
            }
        }
        /// <summary>
        ///     Requested Action
        /// </summary>
        private MessageActions Action { get; init; }

        /// <inheritdoc />
        public override string GetRequestedAction()
        {
            return Action.ToString();
        }

        /// <summary>
        ///     Message factory
        /// </summary>
        public static class Factory
        {
            /// <summary>
            ///     Message GetProperty and wait response
            /// </summary>
            /// <param name="node"></param>
            /// <param name="name"></param>
            /// <returns></returns>
            public static IMessageResponse MessageGetProperty(INode node, string name)
            {
                return new MessageElementWithResponse(
                    node,
                    MessageActions.GetProperty,
                    name
                );
            }

            /// <summary>
            ///     Message CallMethod and wait response
            /// </summary>
            /// <param name="node"></param>
            /// <param name="name"></param>
            /// <param name="arguments"></param>
            /// <returns></returns>
            public static IMessageResponse MessageMethodCallWaitResponse(INode node, string name, string[] arguments)
            {
                return new MessageElementWithResponse(
                    node,
                    MessageActions.CallMethodGetResponse,
                    name,
                    arguments
                );
            }
        }
    }
}