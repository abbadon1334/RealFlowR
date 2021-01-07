namespace FlowR.Library.Client.Message
{
    public enum MessageElementAction
    {
        CreateElement,
        RemoveElement,
        SetAttribute,
        RemoveAttribute,
        StartListenEvent,
        StopListenEvent,
        SetText
    }

    public class MessageElement : Message
    { }
}