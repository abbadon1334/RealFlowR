using System.Linq;
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
    }
}