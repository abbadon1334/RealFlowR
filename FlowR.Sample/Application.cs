
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
                .SetAttribute("class", "card-header")
                .SetText("Test Events"); // @todo align fluid methods

            var cardBody = container
                .Add(new Div())
                .SetAttribute("class", "card-body");

            var cardText = cardBody
                .Add(new Div());

            cardText.SetText("card-text");

            var buttonAdd1000 = cardBody
                .Add(new Button())
                .SetAttribute("class", "btn btn-primary")
                .SetText("Button Add 1000");

            var buttonRemove = cardBody
                .Add(new Button())
                .SetAttribute("class", "btn btn-danger")
                .SetText("Button Remove All");

            var testContainer = RootElement
                .Add(new Div())
                .SetAttribute("class", "card");

            buttonAdd1000.On("click", delegate (object sender, EventArgs args)
            {
                for(int x = 0; x < 1000; x++)
                {
                    int count = testContainer.GetChildrenCount();
                    testContainer.Add(new Div())
                        .SetAttribute("class", "display-5 pb-3 mb-3 border-bottom")
                        .SetText($"Number {count}");
                    cardHeader.SetText($"Children {count}");
                }
                /*
                el.SetAttribute("class", $"danger{(new Random()).Next(0, 100).ToString()}");
                cardText.SetText($"random {(new Random()).Next(0, 100).ToString()}");
                */
            });

            buttonRemove.On("click", delegate (object sender, EventArgs args)
            {
                while (testContainer.GetChildrenCount() != 0) {

                    testContainer.Remove(testContainer.GetLastChild());

                    int count = testContainer.GetChildrenCount();
                    cardHeader.SetText($"Children {count}");
                }
            });

        }
    }
}