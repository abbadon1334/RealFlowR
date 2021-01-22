using System;

namespace FlowR.Core.Exceptions
{
    /// <summary>
    ///     Used whenever an element is not found during search
    /// </summary>
    public class ElementNotFoundException : Exception
    {
        public ElementNotFoundException(string message)
            : base(message)
        {
        }

        public ElementNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}