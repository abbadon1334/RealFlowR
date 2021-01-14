using System;

namespace FlowR.Library.Client.Message
{
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'MessageElement' visibile pubblicamente
    /// <summary>
    ///     Message for Clientside Nodes
    /// </summary>
    public class MessageElement : Message
    {
        /// <summary>
        /// Requested Action
        /// </summary>
        public MessageActions Action { get; set; }
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
            CallMethod
        }

        public override string GetRequestedAction()
        {
            return Action.ToString();
        }
    }

    /// <summary>
    ///     Message waiting Response for Clientside Nodes
    /// </summary>
    public class MessageElementWithResponse : MessageWithResponse
    {
        /// <summary>
        /// Requested Action
        /// </summary>
        public MessageElementWithResponse.MessageActions Action { get; set; }

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

        public override string GetRequestedAction()
        {
            return Action.ToString();
        }
    }
}