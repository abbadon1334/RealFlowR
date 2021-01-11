using Newtonsoft.Json;

namespace FlowR.Library.Client.Message
{
    public class MessageWithResponse : Message
    {
        private MessageWithResponseCallback _callback;

        private string _response;

        public void SetCallback(MessageWithResponseCallback callback)
        {
            _callback = callback;
        }

        public void SetResponse(string response)
        {
            _response = response;
            _callback?.Invoke(response);
        }

        public string GetResponse()
        {
            return _response;
        }

        public static MessageWithResponse FromJson(string json)
        {
            var msg = JsonConvert.DeserializeObject<MessageWithResponse>(json);
            return msg;
        }
    }

    public delegate void MessageWithResponseCallback(string response);
}