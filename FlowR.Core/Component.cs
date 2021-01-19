using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

namespace FlowR.Core
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class Component<T> : Node where T : Node
    {
        /// <summary>
        /// 
        /// </summary>
        protected T DerivedClass;

        /// <summary>
        /// 
        /// </summary>
        protected Component()
        {
            DerivedClass = this as T;
        }

        /// <inheritdoc cref="Node._SetAttribute"/>
        public T SetAttribute(string name, string value)
        {
            _SetAttribute(name, value);
            
            return DerivedClass;
        }
        
        /// <inheritdoc cref="Node._SetAttribute"/>
        public T SetAttributes(KeyValuePair<string,string>[] attributes)
        {
            foreach (var kvp in attributes)
            {
                _SetAttribute(kvp.Key, kvp.Value);
            }
            
            return DerivedClass;
        }
        
        /// <inheritdoc cref="Node._RemoveAttribute"/>
        public T RemoveAttribute(string name)
        {
            _RemoveAttribute(name);
            
            return DerivedClass;
        }
        
        /// <inheritdoc cref="Node._SetText"/>
        public T SetText(string text)
        {
            _SetText(text);
            
            return DerivedClass;
        }
        
        /// <inheritdoc cref="Node._On"/>
        public T On(string eventName, EventHandler handler)
        {
            _On(eventName, handler);
            return DerivedClass;
        }
        
        /// <inheritdoc cref="Node._Off"/>
        public T Off(string eventName, EventHandler handler)
        {
            _Off(eventName, handler);
            
            return DerivedClass;
        }
        
        /// <inheritdoc cref="Node._SetProperty"/>
        public T SetProperty(string name, string value)
        {
            _SetProperty(name, value);
            
            return DerivedClass;
        }
    }
}