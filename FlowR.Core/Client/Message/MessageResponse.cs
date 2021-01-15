using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FlowR.Library.Client.Message
{
    /// <summary>
    ///     Message with response
    /// </summary>
    public class MessageResponse : Message, IMessageResponse
    {
        /// <summary>
        ///     When completed store response here
        /// </summary>
        [JsonInclude]
        public string Response;

        /// <inheritdoc />
        public MessageResponse()
        {
            AddArgument("MessageUuid", GetUuid());
        }

        /// <inheritdoc />
        public void SetResponse(string response)
        {
            Response = response;
        }

        /// <inheritdoc />
        public string GetResponse()
        {
            return Response;
        }
        /// <inheritdoc />
        public override string GetRequestedAction()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Convert from JSON
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static MessageResponse FromJson(string json)
        {
            return JsonSerializer.Deserialize<MessageResponse>(json);
        }
    }
}