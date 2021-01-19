namespace FlowR.Core.Message
{
    /// <summary>
    ///     Global Messages
    /// </summary>
    public class MessageGlobal : Message
    {

        /// <summary>
        ///     Possible Actions
        /// </summary>
        public enum MessageActions
        {
            /// <summary>
            ///     Call Global Method
            /// </summary>
            CallGlobalMethod,

            /// <summary>
            ///     Set Property
            /// </summary>
            SetProperty
        }

        /// <inheritdoc />
        public MessageGlobal(string name, string[] arguments = null)
        {
            AddArgument(name);
            if (arguments != null) AddArgument(arguments);
        }
        /// <summary>
        ///     Requested Action
        /// </summary>
        public MessageActions Action { get; set; }

        /// <inheritdoc />
        public override string GetRequestedAction()
        {
            return Action.ToString();
        }
    }
}