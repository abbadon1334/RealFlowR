using System;
using System.Timers;
using FlowR.Library.Client.Tags;
using Microsoft.AspNetCore.SignalR;

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

            var cardHeaderTime = container
                .Add(new Div())
                .SetAttribute("class", "card-header")
                .SetText("Server Time");
            
            AddTimer(1, (sender, args) =>
            {
                cardHeaderTime.SetText($"Server Time :{DateTime.Now.ToString("O")}");
            });
            
            var cardHeader = container
                .Add(new Div())
                .SetAttribute("class", "card-header")
                .SetText("Right");

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

            var buttonTestResponse = cardBody
                .Add(new Button())
                .SetAttribute("class", "btn btn-success")
                .SetText(
                    "client click -> server ask client innerHTML -> client return innerHtml -> server add a point to innerHTML");


            var testContainer = RootElement
                .Add(new Div())
                .SetAttribute("class", "card");

            buttonAdd1000.On("click", delegate
            {
                buttonAdd1000.SetProperty("value", "test");
                for (var x = 0; x < 1000; x++)
                {
                    var count = testContainer.GetChildrenCount();
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

            buttonRemove.On("click", delegate
            {
                while (testContainer.GetChildrenCount() != 0)
                {
                    testContainer.Remove(testContainer.GetLastChild());

                    var count = testContainer.GetChildrenCount();
                    cardHeader.SetText($"Children {count}");
                }
            });

            buttonTestResponse.On("click", async delegate
            {
                var label = await buttonTestResponse.GetProperty("innerHTML");
                buttonTestResponse.SetProperty("innerHTML", $"{label}."); // add a point as an example of the workflow on every call
            });
        }
    }
}