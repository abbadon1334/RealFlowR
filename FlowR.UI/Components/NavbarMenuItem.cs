using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using FlowR.Core;
using FlowR.Core.Components;

namespace FlowR.UI.Components
{
    /// <summary>
    ///     Tag div
    /// </summary>
    public class NavbarMenuItem : ComponentElement<NavbarMenuItem>
    {
        /// <inheritdoc cref="Node.TagName" />
        public override string TagName { get; protected set; } = "li";

        protected A Link;
        
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
        
        public NavbarMenuItem onClick(EventHandler callback)
        {
            Link.On("click", callback);
            
            return this;
        }

        public NavbarMenuItem SetActive()
        {
            AddCSSClass("active");
            
            return this;
        }

        public NavbarMenuItem SetInactive()
        {
            RemoveCSSClass("active");
            
            return this;
        }
    }
}