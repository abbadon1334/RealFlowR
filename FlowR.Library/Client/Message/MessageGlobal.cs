namespace FlowR.Library.Client.Message
{
    public class MessageGlobal : Message
    {
        public enum MethodName
        {
            CallGlobalMethod
        }
    }

    public class MessageGlobalWithResponse : MessageWithResponse
    {
        public enum MethodName
        {
            CallGlobalMethodGetResponse
        }
    }
}