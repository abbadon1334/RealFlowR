using System;
using System.Threading.Tasks;
using FlowR.Library.Client.Message;
using Microsoft.AspNetCore.SignalR;

namespace FlowR.Library.Client
{
    /// <summary>
    /// Manage Communication
    /// </summary>
    public class ApplicationCommunication
    {
        private Application _application;
        private readonly ApplicationResponses _responses = new();
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="application"></param>
        /// <param name="client"></param>
        public ApplicationCommunication(Application application, IClientProxy client)
        {
            Client = client;
            _application = application;
        }
        /// <summary>
        /// SignalR Client reference
        /// </summary>
        private IClientProxy Client { get; }
        /// <summary>
        ///     Send a message to SignalR Client, don't wait for response
        /// </summary>
        /// <param name="message"></param>
        public Task SendMessage(IMessage message)
        {
            string method = message.GetRequestedAction();
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
        /// <summary>
        ///     Call a global JS method, don't wait for response.
        /// </summary>
        /// <example>from a DomNode : GetApplication().CallGlobalMethod('alert',['this is an alert']);</example>
        /// <param name="methodName"></param>
        /// <param name="arguments"></param>
        public void CallGlobalMethod(string methodName, params string[] arguments)
        {
            SendMessage(Factory.MessageGlobalMethodCall(methodName, arguments));
        }
        /// <summary>
        ///     Call a global JS method and wait for response
        /// </summary>
        /// <param name="methodName">window method or complete traversed path like document.location.reload </param>
        /// <param name="arguments"></param>
        public async Task<string> CallGlobalMethodWaitResponse(string methodName, params string[] arguments)
        {
            var message = Factory.MessageGlobalMethodCallWaitResponse(methodName, arguments);
            return await _responses.WaitResponse(_application, message);
        }
        /// <summary>
        ///     Get a global JS property and wait for response
        /// </summary>
        /// <param name="path">window method or complete traversed path like document.location.reload </param>
        public async Task<string> GetGlobalProperty(string path)
        {
            var message = Factory.MessageGlobalGetPropertyWaitResponse(path);
            return await _responses.WaitResponse(_application, message);
        }
        /// <summary>
        ///     Set a global JS property and wait for response
        /// </summary>
        /// <param name="path">window property or complete traversed path like document.body.scrollHeight </param>
        /// <param name="value"></param>
        public void SetGlobalProperty(string path, string value)
        {
            SendMessage(Factory.MessageSetGlobalProperty(path, value));
        }
    }
}