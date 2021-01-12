using FlowR.Library.Node;

namespace FlowR.Library.Client.Message
{
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'Factory' visibile pubblicamente
    public static class Factory
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'Factory' visibile pubblicamente
    {
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'Factory.MessageCreate(DomNode)' visibile pubblicamente
        public static MessageElement MessageCreate(DomNode node)
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'Factory.MessageCreate(DomNode)' visibile pubblicamente
        {
            var message = new MessageElement();
            message.Method = MessageElement.MethodName.CreateElement.ToString();
            message.AddArgument("OwnerUuid", node.GetOwner().GetUuid());
            message.AddArgument("TagName", node.GetTagName());
            message.AddArgument("Attributes", node.GetAttributeDictionary());
            message.AddArgument("Text", node.GetText());

            return message;
        }

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'Factory.MessageSetAttribute(DomNode, string, string)' visibile pubblicamente
        public static MessageElement MessageSetAttribute(DomNode node, string name, string value)
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'Factory.MessageSetAttribute(DomNode, string, string)' visibile pubblicamente
        {
            var message = new MessageElement();
            message.Method = MessageElement.MethodName.SetAttribute.ToString();
            message.AddArgument("Uuid", node.GetUuid());
            message.AddArgument("Name", name);
            message.AddArgument("Value", value);

            return message;
        }

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'Factory.MessageRemoveAttribute(DomNode, string)' visibile pubblicamente
        public static MessageElement MessageRemoveAttribute(DomNode node, string name)
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'Factory.MessageRemoveAttribute(DomNode, string)' visibile pubblicamente
        {
            var message = new MessageElement();
            message.Method = MessageElement.MethodName.RemoveAttribute.ToString();
            message.AddArgument("Uuid", node.GetUuid());
            message.AddArgument("Name", name);

            return message;
        }

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'Factory.MessageRemove(DomNode)' visibile pubblicamente
        public static MessageElement MessageRemove(DomNode node)
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'Factory.MessageRemove(DomNode)' visibile pubblicamente
        {
            var message = new MessageElement();
            message.Method = MessageElement.MethodName.RemoveElement.ToString();
            message.AddArgument("Uuid", node.GetUuid());

            return message;
        }

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'Factory.MessageStartListenEvent(DomNode, string)' visibile pubblicamente
        public static MessageElement MessageStartListenEvent(DomNode node, string eventName)
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'Factory.MessageStartListenEvent(DomNode, string)' visibile pubblicamente
        {
            var message = new MessageElement();
            message.Method = MessageElement.MethodName.StartListenEvent.ToString();
            message.AddArgument("Uuid", node.GetUuid());
            message.AddArgument("Name", eventName);

            return message;
        }

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'Factory.MessageStopListenEvent(DomNode, string)' visibile pubblicamente
        public static MessageElement MessageStopListenEvent(DomNode node, string eventName)
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'Factory.MessageStopListenEvent(DomNode, string)' visibile pubblicamente
        {
            var message = new MessageElement();
            message.Method = MessageElement.MethodName.StopListenEvent.ToString();
            message.AddArgument("Uuid", node.GetUuid());
            message.AddArgument("Name", eventName);

            return message;
        }

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'Factory.MessageSetText(DomNode, string)' visibile pubblicamente
        public static MessageElement MessageSetText(DomNode node, string text)
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'Factory.MessageSetText(DomNode, string)' visibile pubblicamente
        {
            var message = new MessageElement();
            message.Method = MessageElement.MethodName.SetText.ToString();
            message.AddArgument("Uuid", node.GetUuid());
            message.AddArgument("Value", text);

            return message;
        }

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'Factory.MessageSetProperty(DomNode, string, string)' visibile pubblicamente
        public static Message MessageSetProperty(DomNode node, string name, string value)
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'Factory.MessageSetProperty(DomNode, string, string)' visibile pubblicamente
        {
            var message = new MessageElement();
            message.Method = MessageElement.MethodName.SetProperty.ToString();
            message.AddArgument("Uuid", node.GetUuid());
            message.AddArgument("Name", name);
            message.AddArgument("Value", value);

            return message;
        }

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'Factory.MessageCallMethod(DomNode, string, params string[])' visibile pubblicamente
        public static Message MessageCallMethod(DomNode node, string name, params string[] args)
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'Factory.MessageCallMethod(DomNode, string, params string[])' visibile pubblicamente
        {
            var message = new MessageElement();
            message.Method = MessageElement.MethodName.CallMethod.ToString();
            message.AddArgument("Uuid", node.GetUuid());
            message.AddArgument("Name", name);
            message.AddArgument("Arguments", args);

            return message;
        }

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'Factory.MessageGetProperty(DomNode, string, MessageWithResponseCallback)' visibile pubblicamente
        public static MessageWithResponse MessageGetProperty(DomNode node, string name,
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'Factory.MessageGetProperty(DomNode, string, MessageWithResponseCallback)' visibile pubblicamente
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

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'Factory.MessageMethodCall(DomNode, string, string[])' visibile pubblicamente
        public static Message MessageMethodCall(DomNode node, string name, string[] arguments)
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'Factory.MessageMethodCall(DomNode, string, string[])' visibile pubblicamente
        {
            var message = new MessageElement();
            message.Method = MessageElement.MethodName.CallMethod.ToString();
            message.AddArgument("MessageUuid", message.GetUuid());
            message.AddArgument("Uuid", node.GetUuid());
            message.AddArgument("Name", name);
            message.AddArgument("Arguments", arguments);

            return message;
        }

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'Factory.MessageMethodCallWaitResponse(DomNode, string, string[])' visibile pubblicamente
        public static MessageWithResponse MessageMethodCallWaitResponse(DomNode node, string name, string[] arguments)
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'Factory.MessageMethodCallWaitResponse(DomNode, string, string[])' visibile pubblicamente
        {
            var message = new MessageElementWithResponse();
            message.Method = MessageElementWithResponse.MethodName.CallMethodGetResponse.ToString();
            message.AddArgument("MessageUuid", message.GetUuid());
            message.AddArgument("Uuid", node.GetUuid());
            message.AddArgument("Name", name);
            message.AddArgument("Arguments", arguments);

            return message;
        }

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'Factory.MessageGlobalMethodCall(string, string[])' visibile pubblicamente
        public static Message MessageGlobalMethodCall(string name, string[] arguments)
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'Factory.MessageGlobalMethodCall(string, string[])' visibile pubblicamente
        {
            var message = new MessageGlobal();
            message.Method = MessageGlobal.MethodName.CallGlobalMethod.ToString();
            message.AddArgument("MessageUuid", message.GetUuid());
            message.AddArgument("Name", name);
            message.AddArgument("Arguments", arguments);

            return message;
        }

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'Factory.MessageGlobalMethodCallWaitResponse(string, string[])' visibile pubblicamente
        public static MessageWithResponse MessageGlobalMethodCallWaitResponse(string name, string[] arguments)
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'Factory.MessageGlobalMethodCallWaitResponse(string, string[])' visibile pubblicamente
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