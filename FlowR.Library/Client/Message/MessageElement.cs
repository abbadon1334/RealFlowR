using System.Net.WebSockets;

namespace FlowR.Library.Client.Message
{
    public enum MessageElementAction
    {
        Create,
        SetAttribute,
        RemoveAttribute,
        Remove,
    }
    
    public class MessageElement : Message {}
}