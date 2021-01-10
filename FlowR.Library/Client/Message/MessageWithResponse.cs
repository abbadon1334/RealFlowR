using Newtonsoft.Json;

namespace FlowR.Library.Client.Message
{
    public class MessageWithResponse : MessageElement
    {
        private MessageWithResponseCallback _callback;

        private bool _complete;

        public string Response;

        public void SetCallback(MessageWithResponseCallback callback)
        {
            _callback = callback;
        }

        public void SetResponse(string response)
        {
            Response = response;
            _complete = true;
            _callback?.Invoke(response);
        }

        public string GetResponse()
        {
            return Response;
        }

        public static MessageWithResponse FromJson(string json)
        {
            var msg = JsonConvert.DeserializeObject<MessageWithResponse>(json);
            return msg;
        }

        public bool IsComplete()
        {
            return _complete;
        }
    }

    public delegate void MessageWithResponseCallback(string response);
}