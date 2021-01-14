using System;
using Newtonsoft.Json;

namespace FlowR.Library.Client.Message
{
    /// <summary>
    /// Message for waiting response
    /// </summary>
    public class MessageWithResponse : Message
    {
        /// <summary>
        /// When completed store response here
        /// </summary>
        public string Response;

        /// <summary>
        /// Set the response
        /// </summary>
        /// <param name="response"></param>
        public void SetResponse(string response)
        {
            Response = response;
        }

        /// <summary>
        /// Get The Response
        /// </summary>
        /// <returns></returns>
        public string GetResponse()
        {
            return Response;
        }
        
        /// <summary>
        /// Convert from JSON
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static MessageWithResponse FromJson(string json)
        {
            return JsonConvert.DeserializeObject<MessageWithResponse>(json);
        }
        
        /// <summary>
        ///  
        /// </summary>
        /// <returns></returns>
        public override string GetRequestedAction()
        {
            throw new Exception("Event don't have an Action"); // @todo remove this no need
        }
    }
}