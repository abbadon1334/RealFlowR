using System.Threading.Tasks;

namespace FlowR.Core.Messages
{
    /// <summary>
    ///     Interface for message communications
    /// </summary>
    public interface IMessage
    {
        /// <summary>
        ///     Get the Uuid of the message.
        /// </summary>
        /// <returns></returns>
        public string GetUuid();

        /// <summary>
        ///     Get Action as string
        /// </summary>
        /// <returns></returns>
        public string GetRequestedAction();

        /// <summary>
        ///     Get Arguments as array
        /// </summary>
        /// <returns></returns>
        public object[] GetArgumentValues();

        /// <summary>
        ///     Send a message to SignalR Client, don't wait for response
        /// </summary>
        /// <param name="comm"></param>
        public Task SendMessageAsync(ApplicationCommunication comm);
    }
}