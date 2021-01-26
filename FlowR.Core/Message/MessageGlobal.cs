using System;
using System.Collections.Generic;

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
            SetProperty,
        }

        /// <inheritdoc />
        public MessageGlobal(MessageActions action, string name, string[] arguments = null)
        {
            Action = action;

            var argList = new List<string>(arguments ?? Array.Empty<string>())
            {
                name,
            };

            foreach (var argument in argList)
            {
                AddArgument(argument);
            }
        }
        /// <summary>
        ///     Requested Action
        /// </summary>
        public MessageActions Action { get; init; }

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
            ///     Message Call Global Method
            /// </summary>
            /// <param name="name"></param>
            /// <param name="arguments"></param>
            /// <returns></returns>
            public static IMessage MessageGlobalMethodCall(string name, string[] arguments)
            {
                return new MessageGlobal(
                    MessageActions.CallGlobalMethod,
                    name,
                    arguments
                );
            }

            /// <summary>
            ///     Message Set Global Property
            /// </summary>
            /// <param name="path"></param>
            /// <param name="value"></param>
            /// <returns></returns>
            public static IMessage MessageSetGlobalProperty(string path, string value)
            {
                return new MessageGlobal(
                    MessageActions.SetProperty,
                    path
                );
            }
        }
    }
}