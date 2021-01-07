using FlowR.Library.Node;

namespace FlowR.Library.Client.Message
{
    public static class Factory
    {
        public static MessageElement MessageCreate(DomNode node)
        {
            var message = new MessageElement();
            message.Method = MessageElementAction.CreateElement.ToString();
            message.AddArgument("OwnerUuid", node.GetOwner().GetUuid());
            message.AddArgument("TagName", node.GetTagName());
            message.AddArgument("Attributes", node.GetAttributeDictionary());
            message.AddArgument("Text", node.GetText());

            return message;
        }

        public static MessageElement MessageSetAttribute(DomNode node, string name, string value)
        {
            var message = new MessageElement();
            message.Method = MessageElementAction.SetAttribute.ToString();
            message.AddArgument("Uuid", node.GetUuid());
            message.AddArgument("Name", name);
            message.AddArgument("Value", value);

            return message;
        }

        public static MessageElement MessageRemoveAttribute(DomNode node, string name)
        {
            var message = new MessageElement();
            message.Method = MessageElementAction.RemoveAttribute.ToString();
            message.AddArgument("Uuid", node.GetUuid());
            message.AddArgument("Name", name);

            return message;
        }

        public static MessageElement MessageRemove(DomNode node)
        {
            var message = new MessageElement();
            message.Method = MessageElementAction.Remove.ToString();
            message.AddArgument("Uuid", node.GetUuid());

            return message;
        }

        public static MessageElement MessageStartListenEvent(DomNode node, string eventName)
        {
            var message = new MessageElement();
            message.Method = MessageElementAction.StartListenEvent.ToString();
            message.AddArgument("Uuid", node.GetUuid());
            message.AddArgument("Name", eventName);

            return message;
        }

        public static MessageElement MessageStopListenEvent(DomNode node, string eventName)
        {
            var message = new MessageElement();
            message.Method = MessageElementAction.StopListenEvent.ToString();
            message.AddArgument("Uuid", node.GetUuid());
            message.AddArgument("Name", eventName);

            return message;
        }

        public static MessageElement MessageSetText(DomNode node, string text)
        {
            var message = new MessageElement();
            message.Method = MessageElementAction.SetText.ToString();
            message.AddArgument("Uuid", node.GetUuid());
            message.AddArgument("Value", text);

            return message;
        }
    }
}