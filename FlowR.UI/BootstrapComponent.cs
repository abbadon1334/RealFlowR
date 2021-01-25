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
        /// <inheritdoc />
        public override BootstrapComponent<T> SetAttribute(string name, string value) {
            
            base.SetAttribute(name, value);
            
            return this;
        }
        
        /// <inheritdoc />
        public override BootstrapComponent<T> SetAttribute(Dictionary<string, string> attrs = null){
            
            base.SetAttribute(attrs);
            
            return this;
        }
        
        /// <inheritdoc />
        public override BootstrapComponent<T> RemoveAttribute(string name) {
            base.RemoveAttribute(name);

            return this;
        }

        /// <inheritdoc />
        public override BootstrapComponent<T> SetText(string text) {
            base.SetText(text);
            return this;
        }

        /// <inheritdoc />
        public override BootstrapComponent<T> On(string eventName, EventHandler handler) {
            base.On(eventName, handler);
            return this;
        }
        
        /// <inheritdoc />
        public override BootstrapComponent<T> Off(string eventName, EventHandler handler) {
            base.Off(eventName, handler);
            return this;
        }
        
        /// <inheritdoc />
        public override BootstrapComponent<T> Off(string eventName) {
            base.Off(eventName);
            return this;
        }
        
        /// <inheritdoc />
        public override BootstrapComponent<T> RemoveCssClass(string className) {
            base.RemoveCssClass(className);
            return this;
        }
        
        /// <inheritdoc />
        public override BootstrapComponent<T> AddCssClass(string className) {
            base.AddCssClass(className);
            return this;
        }
    }
}