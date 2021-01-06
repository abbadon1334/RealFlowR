namespace FlowR.Library.Client.Message
{
    public enum MessageElementAction
    {
        Create,
        SetAttribute,
        RemoveAttribute,
        Remove,
        AddListener,
        RemoveListener
    }

    public class MessageElement : Message
    {}
}