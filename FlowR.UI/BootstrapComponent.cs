using System;
using System.Collections.Generic;
using FlowR.Core;
using FlowR.Core.Tags;

namespace FlowR.UI
{
    /// <summary>
    ///     Base Bootstrap component
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BootstrapComponent<T> : NodeComponent where T : NodeComponent
    {
        /// <summary>
        ///     Generic class for Fluent
        /// </summary>
        private readonly BootstrapComponent<T> _generic;
        
        private readonly INode _internalCalls; // @todo find a different way to avoid looping during calls to upward inheritance
        
        private delegate void DelegateReturner(INode fluentObj);

        /// <inheritdoc />
        public BootstrapComponent()
        {
            _generic = this;
            _internalCalls = this;
        }

        private BootstrapComponent<T> ExecAndReturnGeneric(DelegateReturner callback)
        {
            callback(_internalCalls);
            
            return _generic;
        }

        /// <inheritdoc cref="Node.SetAttribute(string,string)"/>
        public new BootstrapComponent<T> SetAttribute(string name, string value) => ExecAndReturnGeneric((obj) => {
            obj.SetAttribute(name, value);
        });
        
        /// <inheritdoc cref="Node.SetAttribute(string,string)"/>
        public new BootstrapComponent<T> SetAttribute(Dictionary<string, string> attrs) => ExecAndReturnGeneric((obj) => {
            obj.SetAttribute(attrs);
        });
        
        /// <inheritdoc cref="Node.RemoveAttribute"/>
        public new BootstrapComponent<T> RemoveAttribute(string name) => ExecAndReturnGeneric((obj) => {
            obj.RemoveAttribute(name);
        });

        /// <inheritdoc cref="Node.SetText"/>
        public new BootstrapComponent<T> SetText(string text) => ExecAndReturnGeneric((obj) => {
            obj.SetText(text);
        });

        /// <inheritdoc cref="Node.On"/>
        public new BootstrapComponent<T> On(string eventName, EventHandler handler) => ExecAndReturnGeneric((obj) =>
        {
            obj.On(eventName, handler);
        });
        
        /// <inheritdoc cref="Node.Off(string,System.EventHandler)"/>
        public new BootstrapComponent<T> Off(string eventName, EventHandler handler) => ExecAndReturnGeneric((obj) =>
        {
            obj.Off(eventName, handler);
        });
        
        /// <inheritdoc cref="Node.Off(string)"/>
        public new BootstrapComponent<T> Off(string eventName) => ExecAndReturnGeneric((obj) =>
        {
            obj.Off(eventName);
        });
    }
}