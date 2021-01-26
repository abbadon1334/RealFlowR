using System;
using System.Collections.Generic;
using FlowR.Core;

namespace FlowR.UI
{
    /// <summary>
    ///     Base Bootstrap component
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class FluentComponent<T> : NodeComponent where T : INode
    {
        /// <summary>
        ///     Fluent NodeComponent SetAttribute (single)
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public override FluentComponent<T> SetAttribute(string name, string value)
        {
            base.SetAttribute(name, value);

            return this;
        }

        /// <summary>
        ///     Fluent NodeComponent SetAttribute (multiple)
        /// </summary>
        /// <param name="attrs"></param>
        /// <returns></returns>
        public override FluentComponent<T> SetAttribute(Dictionary<string, string> attrs = null)
        {
            base.SetAttribute(attrs);

            return this;
        }

        /// <summary>
        ///     Fluent NodeComponent RemoveAttribute
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public override FluentComponent<T> RemoveAttribute(string name)
        {
            base.RemoveAttribute(name);

            return this;
        }

        /// <summary>
        ///     Fluent NodeComponent SetText 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public override FluentComponent<T> SetText(string text)
        {
            base.SetText(text);
            
            return this;
        }

        /// <summary>
        ///     Fluent NodeComponent On
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="handler"></param>
        /// <returns></returns>
        public override FluentComponent<T> On(string eventName, EventHandler handler)
        {
            base.On(eventName, handler);
            
            return this;
        }

        /// <summary>
        ///     Fluent NodeComponent Off
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="handler"></param>
        /// <returns></returns>
        public override FluentComponent<T> Off(string eventName, EventHandler handler)
        {
            base.Off(eventName, handler);
            
            return this;
        }

        /// <summary>
        ///     Fluent NodeComponent Off 
        /// </summary>
        /// <param name="eventName"></param>
        /// <returns></returns>
        public override FluentComponent<T> Off(string eventName)
        {
            base.Off(eventName);
            
            return this;
        }

        /// <summary>
        ///      Fluent NodeComponent RemoveCssClass
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        public override FluentComponent<T> RemoveCssClass(string className)
        {
            base.RemoveCssClass(className);
            
            return this;
        }

        /// <summary>
        ///      Fluent NodeComponent AddCssClass
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        public override FluentComponent<T> AddCssClass(string className)
        {
            base.AddCssClass(className);
            
            return this;
        }
    }
}