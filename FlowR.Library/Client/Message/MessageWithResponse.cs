using Newtonsoft.Json;

namespace FlowR.Library.Client.Message
{
    public class MessageWithResponse : Message
    {
        private MessageWithResponseCallback _callback;

        /// <summary>
        ///     When completed store response here
        /// </summary>
        public string Response;

        /// <summary>
        ///     Set the Callback that will be triggered when response arrive
        /// </summary>
        /// <param name="callback"></param>
        public void SetCallback(MessageWithResponseCallback callback)
        {
            _callback = callback;
        }

        /// <summary>
        ///     Set the response
        /// </summary>
        /// <param name="response"></param>
        public void SetResponse(string response)
        {
            Response = response;
            _callback?.Invoke(response);
        }

        /// <summary>
        ///     Get The Response
        /// </summary>
        /// <returns></returns>
        public string GetResponse()
        {
            return Response;
        }

        /// <summary>
        ///     Convert from JSON
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static MessageWithResponse FromJson(string json)
        {
            var msg = JsonConvert.DeserializeObject<MessageWithResponse>(json);
            return msg;
        }
    }

    public delegate void MessageWithResponseCallback(string response);
}