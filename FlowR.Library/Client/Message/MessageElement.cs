namespace FlowR.Library.Client.Message
{
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'MessageElement' visibile pubblicamente
    /// <summary>
    /// Message for Clientside Nodes
    /// </summary>
    public class MessageElement : Message
    {
        /// <summary>
        /// Name of the method to be called on client side signalr
        /// </summary>
        public enum MethodName
        {
            /// <summary>
            /// Create a new Element
            /// </summary>
            CreateElement,
            /// <summary>
            /// Remove an Element
            /// </summary>
            RemoveElement,
            /// <summary>
            /// Element Set Attribute
            /// </summary>
            SetAttribute,
            /// <summary>
            /// Element Remover Attribute
            /// </summary>
            RemoveAttribute,
            /// <summary>
            /// Start listen for an EventName
            /// </summary>
            StartListenEvent,
            /// <summary>
            /// Stop listen for an EventName
            /// </summary>
            StopListenEvent,
            /// <summary>
            /// Set Element Text
            /// </summary>
            SetText,
            /// <summary>
            /// Element Set Property
            /// </summary>
            SetProperty,
            /// <summary>
            /// Element Call Method
            /// </summary>
            CallMethod
        }
    }

    /// <summary>
    /// Message waiting Response for Clientside Nodes
    /// </summary>
    public class MessageElementWithResponse : MessageWithResponse
    {
        /// <inheritdoc cref="Message.Method"/>>
        public enum MethodName
        {
            /// <summary>
            /// Get Property from Element
            /// </summary>
            GetProperty,
            /// <summary>
            /// Call method and wait for response 
            /// </summary>
            CallMethodGetResponse
        }
    }
}