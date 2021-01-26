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
            AddMethod,
        }

        /// <inheritdoc />
        public MessageElement(INode node, MessageActions action, params object[] args)
        {
            Action = action;

            if (node != null)
            {
                AddArgument(node.GetUuid());
            }

            foreach (var o in args)
            {
                AddArgument(o);
            }
        }
        /// <summary>
        ///     Requested Action
        /// </summary>
        private MessageActions Action { get; }

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
            ///     Message Create Node
            /// </summary>
            /// <param name="node"></param>
            /// <returns></returns>
            public static IMessage MessageCreate(INode node)
            {
                return new MessageElement(
                    null,
                    MessageActions.CreateElement,
                    node.GetOwner().GetUuid(),
                    node.GetTagName(),
                    node.GetAttributes() as object,
                    node.GetText()
                );
            }

            /// <summary>
            ///     Message SetAttribute
            /// </summary>
            /// <param name="node"></param>
            /// <param name="name"></param>
            /// <param name="value"></param>
            /// <returns></returns>
            public static IMessage MessageSetAttribute(INode node, string name, string value)
            {
                return new MessageElement(
                    node,
                    MessageActions.SetAttribute,
                    name,
                    value
                );
            }

            /// <summary>
            ///     Message RemoveAttribute
            /// </summary>
            /// <param name="node"></param>
            /// <param name="name"></param>
            /// <returns></returns>
            public static IMessage MessageRemoveAttribute(INode node, string name)
            {
                return new MessageElement(
                    node,
                    MessageActions.RemoveAttribute,
                    name
                );
            }

            /// <summary>
            ///     Message Remove Node
            /// </summary>
            /// <param name="node"></param>
            /// <returns></returns>
            public static IMessage MessageRemove(INode node)
            {
                return new MessageElement(
                    node,
                    MessageActions.RemoveElement
                );
            }

            /// <summary>
            ///     Message StartListenEvent
            /// </summary>
            /// <param name="node"></param>
            /// <param name="eventName"></param>
            /// <returns></returns>
            public static IMessage MessageStartListenEvent(INode node, string eventName)
            {
                return new MessageElement(
                    node,
                    MessageActions.StartListenEvent,
                    eventName
                );
            }

            /// <summary>
            ///     Message StopListenEvent
            /// </summary>
            /// <param name="node"></param>
            /// <param name="eventName"></param>
            /// <returns></returns>
            public static IMessage MessageStopListenEvent(INode node, string eventName)
            {
                return new MessageElement(
                    node,
                    MessageActions.StopListenEvent,
                    eventName
                );
            }

            /// <summary>
            ///     Message SetText
            /// </summary>
            /// <param name="node"></param>
            /// <param name="text"></param>
            /// <returns></returns>
            public static IMessage MessageSetText(INode node, string text)
            {
                return new MessageElement(
                    node,
                    MessageActions.SetText,
                    text
                );
            }

            /// <summary>
            ///     Message Set Node Property
            /// </summary>
            /// <param name="node"></param>
            /// <param name="name"></param>
            /// <param name="value"></param>
            /// <returns></returns>
            public static IMessage MessageSetProperty(INode node, string name, string value)
            {
                return new MessageElement(
                    node,
                    MessageActions.SetProperty,
                    name,
                    value
                );
            }

            /// <summary>
            ///     Message CallMethod
            /// </summary>
            /// <param name="node"></param>
            /// <param name="name"></param>
            /// <param name="args"></param>
            /// <returns></returns>
            public static IMessage MessageCallMethod(INode node, string name, params string[] args)
            {
                return new MessageElement(
                    node,
                    MessageActions.CallMethod,
                    name,
                    args
                );
            }

            /// <summary>
            ///     Message AddMethod
            /// </summary>
            /// <param name="node"></param>
            /// <param name="name"></param>
            /// <param name="jsStatement"></param>
            /// <returns></returns>
            public static IMessage MessageAddMethod(INode node, string name, string jsStatement)
            {
                return new MessageElement(
                    node,
                    MessageActions.AddMethod,
                    name,
                    jsStatement
                );
            }
        }
    }
}