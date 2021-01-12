using Newtonsoft.Json;

namespace FlowR.Library.Client.Message
{
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'MessageWithResponse' visibile pubblicamente
    public class MessageWithResponse : Message
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'MessageWithResponse' visibile pubblicamente
    {
        private MessageWithResponseCallback _callback;

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'MessageWithResponse.Response' visibile pubblicamente
        public string Response;
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'MessageWithResponse.Response' visibile pubblicamente

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'MessageWithResponse.SetCallback(MessageWithResponseCallback)' visibile pubblicamente
        public void SetCallback(MessageWithResponseCallback callback)
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'MessageWithResponse.SetCallback(MessageWithResponseCallback)' visibile pubblicamente
        {
            _callback = callback;
        }

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'MessageWithResponse.SetResponse(string)' visibile pubblicamente
        public void SetResponse(string response)
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'MessageWithResponse.SetResponse(string)' visibile pubblicamente
        {
            Response = response;
            _callback?.Invoke(response);
        }

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'MessageWithResponse.GetResponse()' visibile pubblicamente
        public string GetResponse()
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'MessageWithResponse.GetResponse()' visibile pubblicamente
        {
            return Response;
        }

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'MessageWithResponse.FromJson(string)' visibile pubblicamente
        public static MessageWithResponse FromJson(string json)
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'MessageWithResponse.FromJson(string)' visibile pubblicamente
        {
            var msg = JsonConvert.DeserializeObject<MessageWithResponse>(json);
            return msg;
        }
    }

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'MessageWithResponseCallback' visibile pubblicamente
    public delegate void MessageWithResponseCallback(string response);
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'MessageWithResponseCallback' visibile pubblicamente
}