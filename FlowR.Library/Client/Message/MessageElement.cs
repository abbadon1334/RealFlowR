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
        SetText,
        SetProperty,
        CallMethod,
        GetProperty,
        MessageWithResponse
    }

    public class MessageElement : Message
    {
    }
}