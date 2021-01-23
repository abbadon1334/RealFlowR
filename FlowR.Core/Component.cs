using System;
using System.Collections.Generic;
using System.Linq;
using FlowR.Core.Exceptions;

namespace FlowR.Core
{
    /// <summary>
    /// </summary>
    public abstract class Component<T> : Node where T : Node
    {
        /// <summary>
        /// </summary>
        protected T DerivedClass;

        /// <summary>
        /// </summary>
        protected Component()
        {
            DerivedClass = this as T;

            foreach (var kvp in defaultAttributes) SetAttribute(kvp.Key, kvp.Value);
        }

        /// <summary>
        ///     Setup default Component attributes
        /// </summary>
        protected virtual Dictionary<string, string> defaultAttributes { get; set; } = new();

        /// <inheritdoc cref="Node._SetAttribute" />
        public T SetAttribute(string name, string value)
        {
            _SetAttribute(name, value);

            return DerivedClass;
        }

        /// <inheritdoc cref="Node._SetAttribute" />
        public T SetAttributes(params KeyValuePair<string, string>[] attributes)
        {
            foreach (var kvp in attributes) _SetAttribute(kvp.Key, kvp.Value);

            return DerivedClass;
        }

        /// <inheritdoc cref="Node._RemoveAttribute" />
        public T RemoveAttribute(string name)
        {
            _RemoveAttribute(name);

            return DerivedClass;
        }

        /// <inheritdoc cref="Node._SetText" />
        public virtual T SetText(string text)
        {
            _SetText(text);

            return DerivedClass;
        }

        /// <inheritdoc cref="Node._On" />
        public T On(string eventName, EventHandler handler)
        {
            _On(eventName, handler);
            return DerivedClass;
        }

        /// <inheritdoc cref="Node._Off" />
        public T Off(string eventName, EventHandler handler)
        {
            _Off(eventName, handler);

            return DerivedClass;
        }

        /// <inheritdoc cref="Node._SetProperty" />
        public T SetProperty(string name, string value)
        {
            _SetProperty(name, value);

            return DerivedClass;
        }

        private List<string> GetAttributeClassAsList()
        {
            GetAttributeDictionary().TryGetValue("class", out var actualCss);
                
            return actualCss == null
                    ? new List<string>()
                    : actualCss.Split(" ").Distinct().ToList()
                ;
        }
        
        /// <summary>
        ///     Add a classname to class attribute
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public T AddCSSClass(string name)
        {
            SetAttribute("class", string.Join(" ", GetAttributeClassAsList().Append(name).Distinct()).Trim());

            return DerivedClass;
        }

        /// <summary>
        ///     Remove a classname from class attribute
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public T RemoveCSSClass(string name)
        {
            var css = GetAttributeClassAsList();
                css.Remove(name);
            

            SetAttribute("class", string.Join(" ", css.Distinct()).Trim());

            return DerivedClass;
        }

        /// <summary>
        ///     Search upward for first owner of a specific type.
        /// </summary>
        /// <typeparam name="TNode"></typeparam>
        /// <returns><![CDATA[ 
        ///    Component<T> or null if not found
        /// ]]></returns>
        public TNode TryFindFirstOwnerByType<TNode>() where TNode : Component<TNode>
        {
            try
            {
                return FindFirstOwnerByType<TNode>();
            }
            catch (Exception e)
            {
                // intentionally silent
            }

            return null;
        }

        /// <summary>
        ///     Search upward for first owner of a specific type.
        /// </summary>
        /// <typeparam name="TNode"></typeparam>
        /// <returns><![CDATA[
        ///     Component<TNode>
        /// ]]></returns>
        /// <exception cref="ElementNotFoundException"></exception>
        public TNode FindFirstOwnerByType<TNode>() where TNode : Component<TNode>
        {
            Node scopedOwner = this;

            // cycle until root of the tree
            while (scopedOwner.Owner.GetType() != typeof(TNode))
                if (scopedOwner.GetType() == typeof(ComponentRoot))
                    throw new ElementNotFoundException(
                        $"Owner of Type {typeof(TNode)} not found.");

            return scopedOwner.Owner as TNode;
        }
    }
}