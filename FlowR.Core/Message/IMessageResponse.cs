using System.Threading.Tasks;

namespace FlowR.Core.Message
{
    /// <summary>
    ///     Message Response
    /// </summary>
    public interface IMessageResponse : IMessage
    {
        /// <summary>
        ///     Set incoming response to message
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public void SetResponse(string response);

        /// <summary>
        ///     Get Response from message
        /// </summary>
        /// <returns></returns>
        public string GetResponse();

        /// <summary>
        ///     Send a message to SignalR Client, wait for response
        /// </summary>
        /// <param name="comm"></param>
        public new Task<string> SendMessageAsync(ApplicationCommunication comm);
    }
}