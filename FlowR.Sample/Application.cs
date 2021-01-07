
using FlowR.Library.Client.Tags;
using Microsoft.AspNetCore.SignalR;
using System;

namespace FlowR.Sample
{
    public class Application : Library.Client.Application
    {
        protected int counter = 0;

        public Application(string connectionId, IClientProxy client) : base(connectionId, client)
        {
        }

        protected override void OnStart(Root rootElement)
        {

            var container = RootElement
                .Add(new Div())
                .SetAttribute("class", "card");

            var cardHeader = container
                .Add(new Div())
                .SetAttribute("class", "card-header");
            cardHeader.SetText("Test Events"); // @todo align fluid methods

            var cardBody = container
                .Add(new Div())
                .SetAttribute("class", "card-body");

            var cardText = cardBody
                .Add(new Div());

            cardText.SetText("card-text");

            var el = cardBody
                .Add(new Button())
                .SetAttribute("class", "btn btn-primary");
            el.SetText("Button");

            el.On("click", delegate (object sender, EventArgs args)
            {
                counter++;

                el.SetAttribute("class", $"danger{(new Random()).Next(0, 100).ToString()}");
                cardHeader.SetText($"Test Events {counter}");
                cardText.SetText($"random {(new Random()).Next(0, 100).ToString()}");
            });

        }
    }
}