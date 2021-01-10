namespace FlowR.Library.Client.Message
{
    public class MessageElement : Message
    {
        public enum MethodName
        {
            CreateElement,
            RemoveElement,
            SetAttribute,
            RemoveAttribute,
            StartListenEvent,
            StopListenEvent,
            SetText,
            SetProperty,
            CallMethod
        }
    }

    public class MessageElementWithResponse : MessageWithResponse
    {
        public enum MethodName
        {
            GetProperty,
            CallMethodGetResponse
        }
    }
}