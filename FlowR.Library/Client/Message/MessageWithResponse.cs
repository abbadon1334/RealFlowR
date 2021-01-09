using System;
using System.Diagnostics;
using Microsoft.AspNetCore.SignalR;

namespace FlowR.Library.Client.Message
{
    public class MessageWithResponse : MessageElement
    {
        private MessageWithResponseCallback _callback;
        private string _uuid;

        public MessageWithResponse(MessageWithResponseCallback callback)
        {
            this._uuid = Guid.NewGuid().ToString();
            this.Method = MessageElementAction.MessageWithResponse.ToString();
            this._callback = callback;
        }

        public void processResponse()
        {
            
        }
    }

    public delegate void MessageWithResponseCallback(string response);
}