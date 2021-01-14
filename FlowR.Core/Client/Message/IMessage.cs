namespace FlowR.Library.Client.Message
{
    /// <summary>
    /// Interface for message communications
    /// </summary>
    public interface IMessage
    {
        /// <summary>
        /// Get the Uuid of the message.
        /// </summary>
        /// <returns></returns>
        string GetUuid();
        
        /// <summary>
        /// Get Action as string
        /// </summary>
        /// <returns></returns>
        string GetRequestedAction();
        
        /// <summary>
        ///     Get Arguments as array
        /// </summary>
        /// <returns></returns>
        object[] GetArgumentValues();
    }
}