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
        public static MessageElement MessageCreate(DomNode node)
        {
            var message = new MessageElement();
            message.Action = MessageElement.MessageActions.CreateElement;
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
        public static MessageElement MessageSetAttribute(DomNode node, string name, string value)
        {
            var message = new MessageElement();
            message.Action = MessageElement.MessageActions.SetAttribute;
            message.AddArgument("Uuid", node.Uuid);
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
        public static MessageElement MessageRemoveAttribute(DomNode node, string name)
        {
            var message = new MessageElement();
            message.Action = MessageElement.MessageActions.RemoveAttribute;
            message.AddArgument("Uuid", node.Uuid);
            message.AddArgument("Name", name);

            return message;
        }

        /// <summary>
        ///     Return MessageElement
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static MessageElement MessageRemove(DomNode node)
        {
            var message = new MessageElement();
            message.Action = MessageElement.MessageActions.RemoveElement;
            message.AddArgument("Uuid", node.Uuid);

            return message;
        }

        /// <summary>
        ///     Return MessageElement
        /// </summary>
        /// <param name="node"></param>
        /// <param name="eventName"></param>
        /// <returns></returns>
        public static MessageElement MessageStartListenEvent(DomNode node, string eventName)
        {
            var message = new MessageElement();
            message.Action = MessageElement.MessageActions.StartListenEvent;
            message.AddArgument("Uuid", node.Uuid);
            message.AddArgument("Name", eventName);

            return message;
        }

        /// <summary>
        ///     Return MessageElement
        /// </summary>
        /// <param name="node"></param>
        /// <param name="eventName"></param>
        /// <returns></returns>
        public static MessageElement MessageStopListenEvent(DomNode node, string eventName)
        {
            var message = new MessageElement();
            message.Action = MessageElement.MessageActions.StopListenEvent;
            message.AddArgument("Uuid", node.Uuid);
            message.AddArgument("Name", eventName);

            return message;
        }

        /// <summary>
        ///     Return MessageElement
        /// </summary>
        /// <param name="node"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static MessageElement MessageSetText(DomNode node, string text)
        {
            var message = new MessageElement();
            message.Action = MessageElement.MessageActions.SetText;
            message.AddArgument("Uuid", node.Uuid);
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
        public static Message MessageSetProperty(DomNode node, string name, string value)
        {
            var message = new MessageElement();
            message.Action = MessageElement.MessageActions.SetProperty;
            message.AddArgument("Uuid", node.Uuid);
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
        public static Message MessageCallMethod(DomNode node, string name, params string[] args)
        {
            var message = new MessageElement();
            message.Action = MessageElement.MessageActions.CallMethod;
            message.AddArgument("Uuid", node.Uuid);
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
        public static MessageWithResponse MessageGetProperty(DomNode node, string name)
        {
            var message = new MessageElementWithResponse();
            message.Action = MessageElementWithResponse.MessageActions.GetProperty;
            message.AddArgument("MessageUuid", message.GetUuid());
            message.AddArgument("Uuid", node.Uuid);
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
        public static Message MessageMethodCall(DomNode node, string name, string[] arguments)
        {
            var message = new MessageElement();
            message.Action = MessageElement.MessageActions.CallMethod;
            message.AddArgument("MessageUuid", message.GetUuid());
            message.AddArgument("Uuid", node.Uuid);
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
        public static MessageWithResponse MessageMethodCallWaitResponse(DomNode node, string name, string[] arguments)
        {
            var message = new MessageElementWithResponse();
            message.Action = MessageElementWithResponse.MessageActions.CallMethodGetResponse;
            message.AddArgument("MessageUuid", message.GetUuid());
            message.AddArgument("Uuid", node.Uuid);
            message.AddArgument("Name", name);
            message.AddArgument("Arguments", arguments);

            return message;
        }

        /// <summary>
        ///     Return MessageElement
        /// </summary>
        /// <param name="name"></param>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public static Message MessageGlobalMethodCall(string name, string[] arguments)
        {
            var message = new MessageGlobal();
            message.Action = MessageGlobal.MessageActions.CallGlobalMethod;
            message.AddArgument("MessageUuid", message.GetUuid());
            message.AddArgument("Name", name);
            message.AddArgument("Arguments", arguments);

            return message;
        }


        /// <summary>
        ///     Return MessageElement
        /// </summary>
        /// <param name="name"></param>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public static MessageWithResponse MessageGlobalMethodCallWaitResponse(string name, string[] arguments)
        {
            var message = new MessageGlobalWithResponse();
            message.Action = MessageGlobalWithResponse.MessageActions.CallGlobalMethodGetResponse;
            message.AddArgument("MessageUuid", message.GetUuid());
            message.AddArgument("Name", name);
            message.AddArgument("Arguments", arguments);

            return message;
        }


        /// <summary>
        ///     Return MessageElement
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static MessageWithResponse MessageGlobalGetPropertyWaitResponse(string name)
        {
            var message = new MessageGlobalWithResponse();
            message.Action = MessageGlobalWithResponse.MessageActions.GetGlobalProperty;
            message.AddArgument("MessageUuid", message.GetUuid());
            message.AddArgument("Name", name);

            return message;
        }

        /// <summary>
        ///     Return MessageElement
        /// </summary>
        /// <param name="path"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Message MessageSetGlobalProperty(string path, string value)
        {
            var message = new MessageGlobal();
            message.Action = MessageGlobal.MessageActions.SetProperty;
            message.AddArgument("Name", path);
            message.AddArgument("Value", value);

            return message;
        }
    }
}