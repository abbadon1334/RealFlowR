
using System;
using FlowR.Library.Client.Tags;
using FlowR.Library.Node.Collections;
using Microsoft.AspNetCore.SignalR;

namespace FlowR.Sample
{
    public class Application : Library.Client.Application
    {
        public Application(string connectionId, IClientProxy client) : base(connectionId, client)
        {
        }

        protected override void OnStart(Root rootElement)
        {
            var el = new Button();
                el.SetAttribute("class", "button");
                
                RootElement.Add(el);
                el.On("click", delegate(object sender, EventArgs args)
                {
                    el.SetAttribute("class", $"danger{(new Random()).Next(0,100).ToString()}");
                });
                
        }
    }
}