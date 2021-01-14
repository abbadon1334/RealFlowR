using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace FlowR.Library.Client.Message
{
    /// <summary>
    /// Message with response
    /// </summary>
    public class MessageResponse : Message, IMessageResponse
    {
        /// <summary>
        /// When completed store response here
        /// </summary>
        public string Response;
        
        /// <inheritdoc/>
        public MessageResponse() : base()
        {
            AddArgument("MessageUuid", GetUuid());
        }
        
        /// <inheritdoc/>
        public void SetResponse(string response)
        {
            Response = response;
        }
        
        /// <inheritdoc/>
        public string GetResponse()
        {
            return Response;
        }
        
        /// <summary>
        /// Convert from JSON
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static MessageResponse FromJson(string json)
        {
            return JsonConvert.DeserializeObject<MessageResponse>(json);
        }
        /// <inheritdoc />
        public override string GetRequestedAction()
        {
            throw new NotImplementedException();
        }
    }
}