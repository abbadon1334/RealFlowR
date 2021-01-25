namespace FlowR.Core.Message
{
    /// <inheritdoc />
    public class MessageGlobalWithResponse : MessageResponse
    {

        /// <summary>
        ///     Possible Actions
        /// </summary>
        public enum MessageActions
        {
            /// <summary>
            ///     Call a Global method and wait for response
            /// </summary>
            CallGlobalMethodGetResponse,

            /// <summary>
            ///     Call a Global method and wait for response
            /// </summary>
            GetGlobalProperty,

            /// <summary>
            ///     Add tag script and wait until fully loaded
            /// </summary>
            AddScriptWaitLoad,

            /// <summary>
            ///     Add link script and wait until fully loaded
            /// </summary>
            AddStylesheetWaitLoad

        }

        /// <inheritdoc />
        public MessageGlobalWithResponse(MessageActions action, string name, string[] arguments = null)
        {
            Action = action;
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

        /// <summary>
        ///     Message factory
        /// </summary>
        public static class Factory
        {

            /// <summary>
            ///     Message Global CallMethod Wait Response
            /// </summary>
            /// <param name="name"></param>
            /// <param name="arguments"></param>
            /// <returns></returns>
            public static IMessageResponse MessageGlobalCallMethodWaitResponse(string name, string[] arguments)
            {
                return new MessageGlobalWithResponse(
                    MessageActions.CallGlobalMethodGetResponse,
                    name,
                    arguments
                );
            }

            /// <summary>
            ///     Message Global GetPropertyWaitResponse
            /// </summary>
            /// <param name="name"></param>
            /// <returns></returns>
            public static IMessageResponse MessageGlobalGetPropertyWaitResponse(string name)
            {
                return new MessageGlobalWithResponse(
                    MessageActions.GetGlobalProperty,
                    name
                );
            }
            /// <summary>
            ///     Message Global AddScriptWaitLoad
            /// </summary>
            /// <param name="url"></param>
            /// <returns></returns>
            public static IMessageResponse MessageGlobalAddScriptWaitLoad(string url)
            {
                return new MessageGlobalWithResponse(
                    MessageActions.AddScriptWaitLoad,
                    url
                );
            }
            /// <summary>
            ///     Message Global AddStylesheetWaitLoad
            /// </summary>
            /// <param name="url"></param>
            /// <returns></returns>
            public static IMessageResponse MessageGlobalAddStylesheetWaitLoad(string url)
            {
                return new MessageGlobalWithResponse(
                    MessageActions.AddStylesheetWaitLoad,
                    url
                );
            }
        }
    }
}