using System;

namespace FlowR.Library.Client.Message
{
    /// <summary>
    /// Message waiting Response for Clientside Nodes
    /// </summary>
    public class MessageElementWithResponse : MessageResponse
    {
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
            ///     Get Property from Element
            /// </summary>
            GetProperty,

            /// <summary>
            ///     Call method and wait for response
            /// </summary>
            CallMethodGetResponse
        }

        /// <inheritdoc />
        public override string GetRequestedAction()
        {
            return Action.ToString();
        }
    }
}