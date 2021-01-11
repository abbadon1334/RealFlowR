using FlowR.Library.Node;

namespace FlowR.Library.Client.Message
{
    public static class Factory
    {
        public static MessageElement MessageCreate(DomNode node)
        {
            var message = new MessageElement();
            message.Method = MessageElement.MethodName.CreateElement.ToString();
            message.AddArgument("OwnerUuid", node.GetOwner().GetUuid());
            message.AddArgument("TagName", node.GetTagName());
            message.AddArgument("Attributes", node.GetAttributeDictionary());
            message.AddArgument("Text", node.GetText());

            return message;
        }

        public static MessageElement MessageSetAttribute(DomNode node, string name, string value)
        {
            var message = new MessageElement();
            message.Method = MessageElement.MethodName.SetAttribute.ToString();
            message.AddArgument("Uuid", node.GetUuid());
            message.AddArgument("Name", name);
            message.AddArgument("Value", value);

            return message;
        }

        public static MessageElement MessageRemoveAttribute(DomNode node, string name)
        {
            var message = new MessageElement();
            message.Method = MessageElement.MethodName.RemoveAttribute.ToString();
            message.AddArgument("Uuid", node.GetUuid());
            message.AddArgument("Name", name);

            return message;
        }

        public static MessageElement MessageRemove(DomNode node)
        {
            var message = new MessageElement();
            message.Method = MessageElement.MethodName.RemoveElement.ToString();
            message.AddArgument("Uuid", node.GetUuid());

            return message;
        }

        public static MessageElement MessageStartListenEvent(DomNode node, string eventName)
        {
            var message = new MessageElement();
            message.Method = MessageElement.MethodName.StartListenEvent.ToString();
            message.AddArgument("Uuid", node.GetUuid());
            message.AddArgument("Name", eventName);

            return message;
        }

        public static MessageElement MessageStopListenEvent(DomNode node, string eventName)
        {
            var message = new MessageElement();
            message.Method = MessageElement.MethodName.StopListenEvent.ToString();
            message.AddArgument("Uuid", node.GetUuid());
            message.AddArgument("Name", eventName);

            return message;
        }

        public static MessageElement MessageSetText(DomNode node, string text)
        {
            var message = new MessageElement();
            message.Method = MessageElement.MethodName.SetText.ToString();
            message.AddArgument("Uuid", node.GetUuid());
            message.AddArgument("Value", text);

            return message;
        }

        public static Message MessageSetProperty(DomNode node, string name, string value)
        {
            var message = new MessageElement();
            message.Method = MessageElement.MethodName.SetProperty.ToString();
            message.AddArgument("Uuid", node.GetUuid());
            message.AddArgument("Name", name);
            message.AddArgument("Value", value);

            return message;
        }

        public static Message MessageCallMethod(DomNode node, string name, params string[] args)
        {
            var message = new MessageElement();
            message.Method = MessageElement.MethodName.CallMethod.ToString();
            message.AddArgument("Uuid", node.GetUuid());
            message.AddArgument("Name", name);
            message.AddArgument("Arguments", args);

            return message;
        }

        public static MessageWithResponse MessageGetProperty(DomNode node, string name,
            MessageWithResponseCallback callback = null)
        {
            var message = new MessageWithResponse();
            message.Method = MessageElementWithResponse.MethodName.GetProperty.ToString();
            message.AddArgument("MessageUuid", message.GetUuid());
            message.AddArgument("Uuid", node.GetUuid());
            message.AddArgument("Name", name);

            if (null != callback) message.SetCallback(callback);

            return message;
        }

        public static Message MessageMethodCall(DomNode node, string name, string[] arguments)
        {
            var message = new MessageElement();
            message.Method = MessageElement.MethodName.CallMethod.ToString();
            message.AddArgument("MessageUuid", message.GetUuid());
            message.AddArgument("Uuid", node.GetUuid());
            message.AddArgument("Name", name);
            message.AddArgument("Arguments", arguments);

            return message;
        }

        public static MessageWithResponse MessageMethodCallWaitResponse(DomNode node, string name, string[] arguments)
        {
            var message = new MessageElementWithResponse();
            message.Method = MessageElementWithResponse.MethodName.CallMethodGetResponse.ToString();
            message.AddArgument("MessageUuid", message.GetUuid());
            message.AddArgument("Uuid", node.GetUuid());
            message.AddArgument("Name", name);
            message.AddArgument("Arguments", arguments);

            return message;
        }

        public static Message MessageGlobalMethodCall(string name, string[] arguments)
        {
            var message = new MessageGlobal();
            message.Method = MessageGlobal.MethodName.CallGlobalMethod.ToString();
            message.AddArgument("MessageUuid", message.GetUuid());
            message.AddArgument("Name", name);
            message.AddArgument("Arguments", arguments);

            return message;
        }

        public static MessageWithResponse MessageGlobalMethodCallWaitResponse(string name, string[] arguments)
        {
            var message = new MessageGlobalWithResponse();
            message.Method = MessageGlobalWithResponse.MethodName.CallGlobalMethodGetResponse.ToString();
            message.AddArgument("MessageUuid", message.GetUuid());
            message.AddArgument("Name", name);
            message.AddArgument("Arguments", arguments);

            return message;
        }
    }
}