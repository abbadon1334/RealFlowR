using System.Collections.Generic;
using System.Linq;

namespace FlowR.Core.Message
{
    // @todo 4 type of message one single factory, is better to move it directly in classes as static factory with different initialization 
    
    /// <summary>
    ///     Message factory class
    /// </summary>
    public static class Factory
    {
        /// <summary>
        /// Return MessageElement
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static IMessage MessageCreate(Node node)
        {
            var message = GetMessageElement(null, MessageElement.MessageActions.CreateElement);
            message.AddArgument(node.Owner.Uuid);
            message.AddArgument(node.TagName);
            message.AddArgument(node.GetAttributeDictionary());
            message.AddArgument(node.Text);

            return message;
        }


        /// <summary>
        /// Return MessageElement
        /// </summary>
        /// <param name="node"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static IMessage MessageSetAttribute(Node node, string name, string value)
        {
            var message = GetMessageElement(node, MessageElement.MessageActions.SetAttribute);
            message.AddArgument(name);
            message.AddArgument(value);

            return message;
        }

        /// <summary>
        /// Return MessageElement
        /// </summary>
        /// <param name="node"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IMessage MessageRemoveAttribute(Node node, string name)
        {
            var message = GetMessageElement(node, MessageElement.MessageActions.RemoveAttribute);
            message.AddArgument(name);

            return message;
        }

        /// <summary>
        /// Return MessageElement
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static IMessage MessageRemove(Node node)
        {
            var message = GetMessageElement(node, MessageElement.MessageActions.RemoveElement);

            return message;
        }

        /// <summary>
        /// Return MessageElement
        /// </summary>
        /// <param name="node"></param>
        /// <param name="eventName"></param>
        /// <returns></returns>
        public static IMessage MessageStartListenEvent(Node node, string eventName)
        {
            var message = GetMessageElement(node, MessageElement.MessageActions.StartListenEvent);
            message.AddArgument(eventName);

            return message;
        }

        /// <summary>
        /// Return MessageElement
        /// </summary>
        /// <param name="node"></param>
        /// <param name="eventName"></param>
        /// <returns></returns>
        public static IMessage MessageStopListenEvent(Node node, string eventName)
        {
            var message = GetMessageElement(node, MessageElement.MessageActions.StopListenEvent);
            message.AddArgument(eventName);

            return message;
        }

        /// <summary>
        /// Return MessageElement
        /// </summary>
        /// <param name="node"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static IMessage MessageSetText(Node node, string text)
        {
            var message = GetMessageElement(node, MessageElement.MessageActions.SetText);
            message.AddArgument(text);

            return message;
        }

        /// <summary>
        /// Return MessageElement
        /// </summary>
        /// <param name="node"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static IMessage MessageSetProperty(Node node, string name, string value)
        {
            var message = GetMessageElement(node, MessageElement.MessageActions.SetProperty);
            message.AddArgument(name);
            message.AddArgument(value);

            return message;
        }

        /// <summary>
        /// Return MessageElement
        /// </summary>
        /// <param name="node"></param>
        /// <param name="name"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IMessage MessageCallMethod(Node node, string name, params string[] args)
        {
            var message = GetMessageElement(node, MessageElement.MessageActions.CallMethod);
            message.AddArgument(name);
            message.AddArgument(args);

            return message;
        }

        /// <summary>
        /// Return MessageElement
        /// </summary>
        /// <param name="node"></param>
        /// <param name="name"></param>
        /// <param name="jsStatement"></param>
        /// <returns></returns>
        public static IMessage MessageAddMethod(Node node, string name, string jsStatement)
        {
            var message = GetMessageElement(node, MessageElement.MessageActions.AddMethod);
            message.AddArgument(name);
            message.AddArgument(jsStatement);

            return message;
        }

        /// <summary>
        /// Return MessageElementWithResponse
        /// </summary>
        /// <param name="node"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IMessageResponse MessageGetProperty(Node node, string name)
        {
            var message = GetMessageElementWithResponse(node, MessageElementWithResponse.MessageActions.GetProperty);
            message.AddArgument(name);

            return message;
        }

        /// <summary>
        /// Return MessageElement
        /// </summary>
        /// <param name="node"></param>
        /// <param name="name"></param>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public static IMessage MessageMethodCall(Node node, string name, string[] arguments)
        {
            var message = GetMessageElement(node, MessageElement.MessageActions.CallMethod);
            message.AddArgument(name);
            message.AddArgument(arguments);

            return message;
        }

        /// <summary>
        /// Return MessageElement
        /// </summary>
        /// <param name="node"></param>
        /// <param name="name"></param>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public static IMessageResponse MessageMethodCallWaitResponse(Node node, string name, string[] arguments)
        {
            var message = GetMessageElementWithResponse(node, MessageElementWithResponse.MessageActions.CallMethodGetResponse);
            message.AddArgument(name);
            message.AddArgument(arguments);

            return message;
        }
        private static MessageElementWithResponse GetMessageElementWithResponse(Node node, MessageElementWithResponse.MessageActions action)
        {
            var message = new MessageElementWithResponse(node)
            {
                Action = action
            };
            return message;
        }

        private static MessageElement GetMessageElement(Node node, MessageElement.MessageActions action)
        {
            var message = new MessageElement(node)
            {
                Action = action
            };
            return message;
        }

        private static MessageGlobal GetMessageGlobal(MessageGlobal.MessageActions action, string name, string[] arguments = null)
        {
            var message = new MessageGlobal(name, arguments)
            {
                Action = action
            };

            return message;
        }

        private static MessageGlobalWithResponse GetMessageGlobalWithResponse(MessageGlobalWithResponse.MessageActions action, string name, string[] arguments = null)
        {
            var message = new MessageGlobalWithResponse(name, arguments)
            {
                Action = action
            };

            return message;
        }

        /// <summary>
        /// Return MessageElement
        /// </summary>
        /// <param name="name"></param>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public static IMessage MessageGlobalMethodCall(string name, string[] arguments)
        {
            return GetMessageGlobal(MessageGlobal.MessageActions.CallGlobalMethod, name, arguments);
        }


        /// <summary>
        /// Return MessageElement
        /// </summary>
        /// <param name="name"></param>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public static IMessageResponse MessageGlobalMethodCallWaitResponse(string name, string[] arguments)
        {
            return GetMessageGlobalWithResponse(MessageGlobalWithResponse.MessageActions.CallGlobalMethodGetResponse, name, arguments);
        }

        /// <summary>
        /// Return MessageElement
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IMessageResponse MessageGlobalGetPropertyWaitResponse(string name)
        {
            return GetMessageGlobalWithResponse(MessageGlobalWithResponse.MessageActions.GetGlobalProperty, name);
        }

        /// <summary>
        /// Return MessageElement
        /// </summary>
        /// <param name="path"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static IMessage MessageSetGlobalProperty(string path, string value)
        {
            var message = GetMessageGlobal(MessageGlobal.MessageActions.SetProperty, path);
            message.AddArgument(value);

            return message;
        }
    }
}