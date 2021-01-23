using System;
using System.Collections.Generic;
using FlowR.Core;
using FlowR.Core.Components;

namespace FlowR.UI.Components
{
    /// <summary>
    ///     Tag div
    /// </summary>
    public class NavbarMenuItem : ComponentElement<NavbarMenuItem>
    {
        /// <summary>
        ///     The link of the item.
        /// </summary>
        protected A Link;
        
        /// <inheritdoc cref="Node.TagName" />
        public override string TagName { get; protected set; } = "li";

        /// <inheritdoc />
        protected override Dictionary<string, string> defaultAttributes { get; set; } = new()
        {
            { "class", "nav-item" }
        };

        /// <inheritdoc />
        public override void Init()
        {
            base.Init();
            Link = Add<A>().AddCSSClass("nav-link");
        }

        /// <inheritdoc />
        public override NavbarMenuItem SetText(string text)
        {
            Link.SetText(text);

            return this;
        }

        /// <summary>
        ///     Add event on click with callback
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        public NavbarMenuItem onClick(EventHandler callback)
        {
            Link.On("click", callback);

            return this;
        }

        /// <summary>
        ///     Set item Active
        /// </summary>
        /// <returns></returns>
        public NavbarMenuItem SetActive()
        {
            AddCSSClass("active");

            return this;
        }

        /// <summary>
        ///     Set item Inactive
        /// </summary>
        /// <returns></returns>
        public NavbarMenuItem SetInactive()
        {
            RemoveCSSClass("active");

            return this;
        }
    }
}