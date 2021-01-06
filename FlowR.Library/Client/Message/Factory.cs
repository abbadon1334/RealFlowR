using System.Text.Json;
using FlowR.Library.Node;

namespace FlowR.Library.Client.Message
{
    public static class Factory
    {
        public static MessageElement MessageCreate(DomNode node)
        {
            var message = new MessageElement();
            message.SetProperty("Action", MessageElementAction.Create);
            message.SetProperty("OwnerUuid", node.GetOwner().GetUuid());
            message.SetProperty("TagName", node.GetTagName());
            message.SetProperty("Attributes", node.GetAttributeDictionary());
            message.SetProperty("Text", node.GetText());

            return message;
        }

        public static MessageElement MessageSetAttribute(DomNode node, string name, string value)
        {
            var message = new MessageElement();
            message.SetProperty("Action", MessageElementAction.SetAttribute);
            message.SetProperty("Uuid", node.GetUuid());
            message.SetProperty("Name", name);
            message.SetProperty("Value", value);

            return message;
        }

        public static MessageElement MessageRemoveAttribute(DomNode node, string name)
        {
            var message = new MessageElement();
            message.SetProperty("Action", MessageElementAction.RemoveAttribute);
            message.SetProperty("Uuid", node.GetUuid());
            message.SetProperty("Name", name);

            return message;
        }

        public static MessageElement MessageRemove(DomNode node)
        {
            var message = new MessageElement();
            message.SetProperty("Action", MessageElementAction.Remove);
            message.SetProperty("Uuid", node.GetUuid());

            return message;
        }

        public static MessageElement MessageAddListener(DomNode node, string eventName)
        {
            var message = new MessageElement();
            message.SetProperty("Action", MessageElementAction.AddListener);
            message.SetProperty("Uuid", node.GetUuid());
            message.SetProperty("Name", eventName);

            return message;
        }

        public static MessageElement MessageRemoveListener(DomNode node, string eventName)
        {
            var message = new MessageElement();
            message.SetProperty("Action", MessageElementAction.RemoveListener);
            message.SetProperty("Uuid", node.GetUuid());
            message.SetProperty("Name", eventName);

            return message;
        }
    }
}