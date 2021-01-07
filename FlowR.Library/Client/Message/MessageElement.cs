namespace FlowR.Library.Client.Message
{
    public enum MessageElementAction
    {
        CreateElement,
        SetAttribute,
        RemoveAttribute,
        Remove,
        StartListenEvent,
        StopListenEvent
    }

    public class MessageElement : Message
    {}
}