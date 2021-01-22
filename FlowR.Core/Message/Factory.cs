namespace FlowR.Core.Message
{
    // @todo 4 type of message one single factory, is better to move it directly in classes as static factory with different initialization 

    /// <summary>
    ///     Message factory class
    /// </summary>
    public static class Factory
    {
        /// <summary>
        ///     Return MessageElement
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static IMessage MessageCreate(Node node)
        {
            var message = GetMessageElement(
                null,
                MessageElement.MessageActions.CreateElement,
                node.Owner.Uuid,
                node.TagName,
                node.GetAttributeDictionary() as object,
                node.Text
            );

            return message;
        }


        /// <summary>
        ///     Return MessageElement
        /// </summary>
        /// <param name="node"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static IMessage MessageSetAttribute(Node node, string name, string value)
        {
            return GetMessageElement(node, MessageElement.MessageActions.SetAttribute, name, value);
        }

        /// <summary>
        ///     Return MessageElement
        /// </summary>
        /// <param name="node"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IMessage MessageRemoveAttribute(Node node, string name)
        {
            return GetMessageElement(node, MessageElement.MessageActions.RemoveAttribute, name);
        }

        /// <summary>
        ///     Return MessageElement
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static IMessage MessageRemove(Node node)
        {
            return GetMessageElement(node, MessageElement.MessageActions.RemoveElement);
        }

        /// <summary>
        ///     Return MessageElement
        /// </summary>
        /// <param name="node"></param>
        /// <param name="eventName"></param>
        /// <returns></returns>
        public static IMessage MessageStartListenEvent(Node node, string eventName)
        {
            return GetMessageElement(node, MessageElement.MessageActions.StartListenEvent, eventName);
        }

        /// <summary>
        ///     Return MessageElement
        /// </summary>
        /// <param name="node"></param>
        /// <param name="eventName"></param>
        /// <returns></returns>
        public static IMessage MessageStopListenEvent(Node node, string eventName)
        {
            return GetMessageElement(node, MessageElement.MessageActions.StopListenEvent, eventName);
        }

        /// <summary>
        ///     Return MessageElement
        /// </summary>
        /// <param name="node"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static IMessage MessageSetText(Node node, string text)
        {
            return GetMessageElement(node, MessageElement.MessageActions.SetText, text);
        }

        /// <summary>
        ///     Return MessageElement
        /// </summary>
        /// <param name="node"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static IMessage MessageSetProperty(Node node, string name, string value)
        {
            return GetMessageElement(node, MessageElement.MessageActions.SetProperty, name, value);
        }

        /// <summary>
        ///     Return MessageElement
        /// </summary>
        /// <param name="node"></param>
        /// <param name="name"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IMessage MessageCallMethod(Node node, string name, params string[] args)
        {
            return GetMessageElement(node, MessageElement.MessageActions.CallMethod, name, args);
        }

        /// <summary>
        ///     Return MessageElement
        /// </summary>
        /// <param name="node"></param>
        /// <param name="name"></param>
        /// <param name="jsStatement"></param>
        /// <returns></returns>
        public static IMessage MessageAddMethod(Node node, string name, string jsStatement)
        {
            return GetMessageElement(node, MessageElement.MessageActions.AddMethod, name, jsStatement);
        }

        /// <summary>
        ///     Return MessageElementWithResponse
        /// </summary>
        /// <param name="node"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IMessageResponse MessageGetProperty(Node node, string name)
        {
            return GetMessageElementWithResponse(node, MessageElementWithResponse.MessageActions.GetProperty, name);
        }

        /// <summary>
        ///     Return MessageElement
        /// </summary>
        /// <param name="node"></param>
        /// <param name="name"></param>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public static IMessage MessageMethodCall(Node node, string name, string[] arguments)
        {
            return GetMessageElement(node, MessageElement.MessageActions.CallMethod, name, arguments);
        }

        /// <summary>
        ///     Return MessageElement
        /// </summary>
        /// <param name="node"></param>
        /// <param name="name"></param>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public static IMessageResponse MessageMethodCallWaitResponse(Node node, string name, string[] arguments)
        {
            return GetMessageElementWithResponse(node, MessageElementWithResponse.MessageActions.CallMethodGetResponse, name, arguments);
        }
        private static MessageElementWithResponse GetMessageElementWithResponse(Node node, MessageElementWithResponse.MessageActions action, params object[] values)
        {
            var message = new MessageElementWithResponse(node)
            {
                Action = action
            };

            message.AddArgument(values);

            return message;
        }

        private static MessageElement GetMessageElement(Node node, MessageElement.MessageActions action, params object[] values)
        {
            var message = new MessageElement(node)
            {
                Action = action
            };

            message.AddArgument(values);

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
        ///     Return MessageElement
        /// </summary>
        /// <param name="name"></param>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public static IMessage MessageGlobalMethodCall(string name, string[] arguments)
        {
            return GetMessageGlobal(MessageGlobal.MessageActions.CallGlobalMethod, name, arguments);
        }


        /// <summary>
        ///     Return MessageElement
        /// </summary>
        /// <param name="name"></param>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public static IMessageResponse MessageGlobalMethodCallWaitResponse(string name, string[] arguments)
        {
            return GetMessageGlobalWithResponse(MessageGlobalWithResponse.MessageActions.CallGlobalMethodGetResponse, name, arguments);
        }

        /// <summary>
        ///     Return MessageElement
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IMessageResponse MessageGlobalGetPropertyWaitResponse(string name)
        {
            return GetMessageGlobalWithResponse(MessageGlobalWithResponse.MessageActions.GetGlobalProperty, name);
        }

        /// <summary>
        ///     Return MessageElement
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IMessageResponse MessageGlobalAddScriptWaitLoad(string url)
        {
            return GetMessageGlobalWithResponse(MessageGlobalWithResponse.MessageActions.AddScriptWaitLoad, url);
        }

        /// <summary>
        ///     Return MessageElement
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IMessageResponse MessageGlobalAddStylesheetWaitLoad(string url)
        {
            return GetMessageGlobalWithResponse(MessageGlobalWithResponse.MessageActions.AddStylesheetWaitLoad, url);
        }

        /// <summary>
        ///     Return MessageElement
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