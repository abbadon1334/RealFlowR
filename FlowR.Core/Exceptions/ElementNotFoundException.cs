using System;

namespace FlowR.Core.Exceptions
{
    /// <summary>
    ///     Used whenever an element is not found during search
    /// </summary>
    public class ElementNotFoundException : Exception
    {
        /// <summary>
        ///     Rise when a element is not found in a collection
        /// </summary>
        /// <param name="message"></param>
        public ElementNotFoundException(string message)
            : base(message)
        {
        }

        /// <inheritdoc />
        public ElementNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}