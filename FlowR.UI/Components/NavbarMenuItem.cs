using System;
using System.Collections.Generic;
using FlowR.Core;
using FlowR.Core.Tags;

namespace FlowR.UI.Components
{
    /// <summary>
    ///     Tag div
    /// </summary>
    public class NavbarMenuItem : NodeComponent
    {
        /// <summary>
        ///     The link of the item.
        /// </summary>
        private A _link;

        /// <inheritdoc cref="Node.TagName" />
        protected override string TagName => "li";

        /// <inheritdoc />
        protected override Dictionary<string, string> DefaultAttributes { get; set; } = new()
        {
            { "class", "nav-item" }
        };

        /// <inheritdoc />
        public override void Init()
        {
            base.Init();
            _link = Add<A>();
            _link.AddCssClass("nav-link");
        }

        /// <inheritdoc />
        public override INode SetText(string text)
        {
            _link?.SetText(text);
            
            return this;
        }

        /// <inheritdoc />
        public override string GetText()
        {
            return _link?.GetText();
        }

        /// <summary>
        ///     Add event on click with callback
        /// </summary>
        /// <param name="callback"></param>
        /// <returns></returns>
        public NavbarMenuItem OnClick(EventHandler callback)
        {
            _link.On("click", callback);

            return this;
        }

        /// <summary>
        ///     Set item Active
        /// </summary>
        /// <returns></returns>
        public NavbarMenuItem SetActive()
        {
            AddCssClass("active");

            return this;
        }

        /// <summary>
        ///     Set item Inactive
        /// </summary>
        /// <returns></returns>
        public NavbarMenuItem SetInactive()
        {
            RemoveCssClass("active");

            return this;
        }
    }
}