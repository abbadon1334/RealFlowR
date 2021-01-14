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
            var message = new MessageElement(null)
            {
                Action = MessageElement.MessageActions.CreateElement
            };
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
            var message = new MessageElement(node)
            {
                Action = MessageElement.MessageActions.SetAttribute
            };
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
            var message = new MessageElement(node)
            {
                Action = MessageElement.MessageActions.RemoveAttribute
            };
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
            var message = new MessageElement(node)
            {
                Action = MessageElement.MessageActions.RemoveElement
            };

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
            var message = new MessageElement(node)
            {
                Action = MessageElement.MessageActions.StartListenEvent
            };
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
            var message = new MessageElement(node)
            {
                Action = MessageElement.MessageActions.StopListenEvent
            };
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
            var message = new MessageElement(node)
            {
                Action = MessageElement.MessageActions.SetText
            };
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
            var message = new MessageElement(node);
            message.Action = MessageElement.MessageActions.SetProperty;
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
            var message = new MessageElement(node)
            {
                Action = MessageElement.MessageActions.CallMethod
            };
            message.AddArgument("Name", name);
            message.AddArgument("Arguments", args);

            return message;
        }

        /// <summary>
        /// Return MessageElement
        /// </summary>
        /// <param name="node"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IMessageResponse MessageGetProperty(DomNode node, string name)
        {
            var message = new MessageElementWithResponse(node)
            {
                Action = MessageElementWithResponse.MessageActions.GetProperty
            };
            message.AddArgument("Name", name);

            return message;
        }

        /// <summary>
        /// Return MessageElement
        /// </summary>
        /// <param name="node"></param>
        /// <param name="name"></param>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public static IMessage MessageMethodCall(DomNode node, string name, string[] arguments)
        {
            var message = new MessageElement(node)
            {
                Action = MessageElement.MessageActions.CallMethod
            };
            message.AddArgument("Name", name);
            message.AddArgument("Arguments", arguments);

            return message;
        }

        /// <summary>
        /// Return MessageElement
        /// </summary>
        /// <param name="node"></param>
        /// <param name="name"></param>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public static IMessageResponse MessageMethodCallWaitResponse(DomNode node, string name, string[] arguments)
        {
            var message = new MessageElementWithResponse(node)
            {
                Action = MessageElementWithResponse.MessageActions.CallMethodGetResponse
            };
            message.AddArgument("Name", name);
            message.AddArgument("Arguments", arguments);

            return message;
        }

        /// <summary>
        /// Return MessageElement
        /// </summary>
        /// <param name="name"></param>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public static IMessage MessageGlobalMethodCall(string name, string[] arguments)
        {
            var message = new MessageGlobal(name, arguments)
            {
                Action = MessageGlobal.MessageActions.CallGlobalMethod
            };

            return message;
        }


        /// <summary>
        /// Return MessageElement
        /// </summary>
        /// <param name="name"></param>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public static IMessageResponse MessageGlobalMethodCallWaitResponse(string name, string[] arguments)
        {
            var message = new MessageGlobalWithResponse(name, arguments)
            {
                Action = MessageGlobalWithResponse.MessageActions.CallGlobalMethodGetResponse
            };

            return message;
        }

        /// <summary>
        /// Return MessageElement
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IMessageResponse MessageGlobalGetPropertyWaitResponse(string name)
        {
            var message = new MessageGlobalWithResponse(name)
            {
                Action = MessageGlobalWithResponse.MessageActions.GetGlobalProperty
            };

            return message;
        }

        /// <summary>
        /// Return MessageElement
        /// </summary>
        /// <param name="path"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static IMessage MessageSetGlobalProperty(string path, string value)
        {
            var message = new MessageGlobal(path)
            {
                Action = MessageGlobal.MessageActions.SetProperty
            };
            message.AddArgument("Value", value);

            return message;
        }
    }
}