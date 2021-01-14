using FlowR.Library.Node;

namespace FlowR.Library.Client.Message
{
    /// <summary>
    ///     Message factory class
    /// </summary>
    public static class Factory
    {
        /// <summary>
        ///     Return MessageElement
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static IMessage MessageCreate(DomNode node)
        {
            var message = GetMessageElement(null, MessageElement.MessageActions.CreateElement);
            message.AddArgument("OwnerUuid", node.Owner.Uuid);
            message.AddArgument("TagName", node.TagName);
            message.AddArgument("Attributes", node.GetAttributeDictionary());
            message.AddArgument("Text", node.Text);

            return message;
        }


        /// <summary>
        ///     Return MessageElement
        /// </summary>
        /// <param name="node"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static IMessage MessageSetAttribute(DomNode node, string name, string value)
        {
            var message = GetMessageElement(node, MessageElement.MessageActions.SetAttribute);
            message.AddArgument("Name", name);
            message.AddArgument("Value", value);

            return message;
        }

        /// <summary>
        ///     Return MessageElement
        /// </summary>
        /// <param name="node"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IMessage MessageRemoveAttribute(DomNode node, string name)
        {
            var message = GetMessageElement(node, MessageElement.MessageActions.RemoveAttribute);
            message.AddArgument("Name", name);

            return message;
        }

        /// <summary>
        ///     Return MessageElement
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static IMessage MessageRemove(DomNode node)
        {
            var message = GetMessageElement(node, MessageElement.MessageActions.RemoveElement);

            return message;
        }

        /// <summary>
        ///     Return MessageElement
        /// </summary>
        /// <param name="node"></param>
        /// <param name="eventName"></param>
        /// <returns></returns>
        public static IMessage MessageStartListenEvent(DomNode node, string eventName)
        {
            var message = GetMessageElement(node, MessageElement.MessageActions.StartListenEvent);
            message.AddArgument("Name", eventName);

            return message;
        }

        /// <summary>
        ///     Return MessageElement
        /// </summary>
        /// <param name="node"></param>
        /// <param name="eventName"></param>
        /// <returns></returns>
        public static IMessage MessageStopListenEvent(DomNode node, string eventName)
        {
            var message = GetMessageElement(node, MessageElement.MessageActions.StopListenEvent);
            message.AddArgument("Name", eventName);

            return message;
        }

        /// <summary>
        ///     Return MessageElement
        /// </summary>
        /// <param name="node"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static IMessage MessageSetText(DomNode node, string text)
        {
            var message = GetMessageElement(node, MessageElement.MessageActions.SetText);
            message.AddArgument("Value", text);

            return message;
        }

        /// <summary>
        ///     Return MessageElement
        /// </summary>
        /// <param name="node"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static IMessage MessageSetProperty(DomNode node, string name, string value)
        {
            var message = GetMessageElement(node, MessageElement.MessageActions.SetProperty);
            message.AddArgument("Name", name);
            message.AddArgument("Value", value);

            return message;
        }

        /// <summary>
        ///     Return MessageElement
        /// </summary>
        /// <param name="node"></param>
        /// <param name="name"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IMessage MessageCallMethod(DomNode node, string name, params string[] args)
        {
            var message = GetMessageElement(node, MessageElement.MessageActions.CallMethod);
            message.AddArgument("Name", name);
            message.AddArgument("Arguments", args);

            return message;
        }

        /// <summary>
        ///     Return MessageElement
        /// </summary>
        /// <param name="node"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IMessageResponse MessageGetProperty(DomNode node, string name)
        {
            var message = GetMessageElementWithResponse(node, MessageElementWithResponse.MessageActions.GetProperty);
            message.AddArgument("Name", name);

            return message;
        }

        /// <summary>
        ///     Return MessageElement
        /// </summary>
        /// <param name="node"></param>
        /// <param name="name"></param>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public static IMessage MessageMethodCall(DomNode node, string name, string[] arguments)
        {
            var message = GetMessageElement(node, MessageElement.MessageActions.CallMethod);
            message.AddArgument("Name", name);
            message.AddArgument("Arguments", arguments);

            return message;
        }

        /// <summary>
        ///     Return MessageElement
        /// </summary>
        /// <param name="node"></param>
        /// <param name="name"></param>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public static IMessageResponse MessageMethodCallWaitResponse(DomNode node, string name, string[] arguments)
        {
            var message = GetMessageElementWithResponse(node, MessageElementWithResponse.MessageActions.CallMethodGetResponse);
            message.AddArgument("Name", name);
            message.AddArgument("Arguments", arguments);

            return message;
        }
        private static MessageElementWithResponse GetMessageElementWithResponse(DomNode node, MessageElementWithResponse.MessageActions action)
        {
            var message = new MessageElementWithResponse(node)
            {
                Action = action
            };
            return message;
        }

        private static MessageElement GetMessageElement(DomNode node, MessageElement.MessageActions action)
        {
            var message = new MessageElement(node)
            {
                Action = action
            };
            return message;
        }

        private static MessageGlobal GetMessageGlobal(MessageGlobal.MessageActions action, string name, string[] arguments = null)
        {
            var message = new MessageGlobal(name, arguments)
            {
                Action = action
            };

            return message;
        }

        private static MessageGlobalWithResponse GetMessageGlobalWithResponse(MessageGlobalWithResponse.MessageActions action, string name, string[] arguments = null)
        {
            var message = new MessageGlobalWithResponse(name, arguments)
            {
                Action = action
            };

            return message;
        }

        /// <summary>
        ///     Return MessageElement
        /// </summary>
        /// <param name="name"></param>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public static IMessage MessageGlobalMethodCall(string name, string[] arguments)
        {
            return GetMessageGlobal(MessageGlobal.MessageActions.CallGlobalMethod, name, arguments);
        }


        /// <summary>
        ///     Return MessageElement
        /// </summary>
        /// <param name="name"></param>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public static IMessageResponse MessageGlobalMethodCallWaitResponse(string name, string[] arguments)
        {
            return GetMessageGlobalWithResponse(MessageGlobalWithResponse.MessageActions.CallGlobalMethodGetResponse, name, arguments);
        }

        /// <summary>
        ///     Return MessageElement
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IMessageResponse MessageGlobalGetPropertyWaitResponse(string name)
        {
            return GetMessageGlobalWithResponse(MessageGlobalWithResponse.MessageActions.GetGlobalProperty, name);
        }

        /// <summary>
        ///     Return MessageElement
        /// </summary>
        /// <param name="path"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static IMessage MessageSetGlobalProperty(string path, string value)
        {
            var message = GetMessageGlobal(MessageGlobal.MessageActions.SetProperty, path);
            message.AddArgument("Value", value);

            return message;
        }
    }
}