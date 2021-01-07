namespace FlowR.Library.Client.Message
{
    public enum MessageElementAction
    {
        CreateElement,
        SetAttribute,
        RemoveAttribute,
        Remove,
        StartListenEvent,
        StopListenEvent,
        SetText
    }

    public class MessageElement : Message
    {}
}