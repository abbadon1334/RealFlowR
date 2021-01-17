namespace FlowR.Core.Message
{
    /// <summary>
    ///     Message for Clientside Nodes
    /// </summary>
    public class MessageElement : Message
    {
        /// <summary>
        ///     Name of the method to be called on client side signalr
        /// </summary>
        public enum MessageActions
        {
            /// <summary>
            ///     Create a new Element
            /// </summary>
            CreateElement,

            /// <summary>
            ///     Remove an Element
            /// </summary>
            RemoveElement,

            /// <summary>
            ///     Element Set Attribute
            /// </summary>
            SetAttribute,

            /// <summary>
            ///     Element Remover Attribute
            /// </summary>
            RemoveAttribute,

            /// <summary>
            ///     Start listen for an EventName
            /// </summary>
            StartListenEvent,

            /// <summary>
            ///     Stop listen for an EventName
            /// </summary>
            StopListenEvent,

            /// <summary>
            ///     Set Element Text
            /// </summary>
            SetText,

            /// <summary>
            ///     Element Set Property
            /// </summary>
            SetProperty,

            /// <summary>
            ///     Element Call Method
            /// </summary>
            CallMethod,

            /// <summary>
            ///     Add a custom method to an Element
            /// </summary>
            AddMethod
        }

        /// <inheritdoc />
        public MessageElement(Node node)
        {
            if (node != null) AddArgument("Uuid", node.Uuid);
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