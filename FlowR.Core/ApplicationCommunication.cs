using System;
using System.Threading.Tasks;
using FlowR.Core.Message;
using Microsoft.AspNetCore.SignalR;

namespace FlowR.Core
{
    /// <summary>
    ///     Manage Communication
    /// </summary>
    public class ApplicationCommunication
    {
        private readonly Application _application;
        private readonly ApplicationResponses _responses = new();

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="application"></param>
        /// <param name="client"></param>
        public ApplicationCommunication(Application application, IClientProxy client)
        {
            Client = client;
            _application = application;
        }

        /// <summary>
        ///     SignalR Client reference
        /// </summary>
        private IClientProxy Client { get; }

        /// <summary>
        ///     Send a message to SignalR Client, don't wait for response
        /// </summary>
        /// <param name="message"></param>
        public Task SendMessage(IMessage message)
        {
            var method = message.GetRequestedAction();
            var args = message.GetArgumentValues();

            return args.Length switch
            {
                0 => Client.SendAsync(method),
                1 => Client.SendAsync(method, args[0]),
                2 => Client.SendAsync(method, args[0], args[1]),
                3 => Client.SendAsync(method, args[0], args[1], args[2]),
                4 => Client.SendAsync(method, args[0], args[1], args[2], args[3]),
                5 => Client.SendAsync(method, args[0], args[1], args[2], args[3], args[4]),
                6 => Client.SendAsync(method, args[0], args[1], args[2], args[3], args[4], args[5]),
                _ => throw new Exception("Message Arguments Array to long")
            };
        }

        /// <summary>
        ///     Send a message to SignalR Client and wait for response
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task<string> SendMessageWaitResponse(IMessageResponse message)
        {
            // @todo add parameter here to define timeout of waiting for response, in place of MessageResponse
            return await _responses.WaitResponse(_application, message);
        }

        /// <summary>
        ///     [internal use] Called from SignalR Client when a new response arrive.
        /// </summary>
        /// <param name="message"></param>
        public void OnWaitingMessageResponse(IMessageResponse message)
        {
            _responses.SetResponse(message);
        }
    }
}