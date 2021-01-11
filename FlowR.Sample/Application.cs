using System;
using FlowR.Library.Client.Tags;
using Microsoft.AspNetCore.SignalR;

namespace FlowR.Sample
{
    public class Application : Library.Client.Application
    {
        protected int Counter = 0;
        protected Div RightColumn;

        public Application(string connectionId, IClientProxy client) : base(connectionId, client)
        {
        }

        protected override void OnStart(Root rootElement)
        {
            var masterContainer = rootElement.Add(new Div()).SetAttribute("class", "container-fluid");
            var containerRow = masterContainer.Add(new Div()).SetAttribute("class", "row");

            var leftColumn = containerRow.Add(new Div()).SetAttribute("class", "col");
            RightColumn = containerRow.Add(new Div()).SetAttribute("class", "col") as Div;

            var container = leftColumn
                .Add(new Div())
                .SetAttribute("class", "card");

            var cardHeaderTime = container
                .Add(new Div())
                .SetAttribute("class", "card-header")
                .SetText("Server Time");

            AddTimer(1 /* 1 millisec to see maximum speed */,(sender, args) =>{
                cardHeaderTime.SetText($"ApplicationTimer which update Text every (1ms) with server Time : {DateTime.Now:O}");
            });

            var cardHeader = container
                .Add(new Div())
                .SetAttribute("class", "card-header")
                .SetText("Children 0");

            var cardBody = container
                .Add(new Div())
                .SetAttribute("class", "card-body");

            var cardText = cardBody
                .Add(new Div());

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
                    "2 way communication Test");

            var testContainer = RootElement
                .Add(new Div())
                .SetAttribute("class", "card");

            buttonAdd1000.On("click", delegate
            {
                ClearLogActions();
                AddLogAction("button Add1000 clicked on client");
                AddLogAction("JS Client : notify server that a click event happen on DomNode with UID : " +
                             buttonAdd1000.GetUuid());
                AddLogAction("SRV : search DomNode registry for UID : " + buttonAdd1000.GetUuid());
                AddLogAction("SRV : trigger defined callback on click");
                AddLogAction(
                    "SRV : which will fire 1000 create event on client side and for every call update the children count");
                //buttonAdd1000.SetProperty("value", "test");
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
                ClearLogActions();
                AddLogAction("button Remove clicked on client");
                AddLogAction("JS Client : notify server that a click event happen on DomNode with UID : " +
                             buttonRemove.GetUuid());
                AddLogAction("SRV : search DomNode registry for UID : " + buttonRemove.GetUuid());
                AddLogAction("SRV : trigger defined callback on click");
                AddLogAction(
                    "SRV : which will fire 1000 remove child event on client side and for every call update the children count");

                while (testContainer.GetChildrenCount() != 0)
                {
                    testContainer.Remove(testContainer.GetLastChild());

                    var count = testContainer.GetChildrenCount();
                    cardHeader.SetText($"Children {count}");
                }
            });

            buttonTestResponse.On("click", async delegate
            {
                ClearLogActions();
                AddLogAction("button Add1000 clicked on client");
                AddLogAction("JS Client : notify server that a click event happen on DomNode with UID : " +
                             buttonTestResponse.GetUuid());
                AddLogAction("SRV : search DomNode registry for UID : " + buttonTestResponse.GetUuid());
                AddLogAction("SRV : trigger defined callback on click");
                AddLogAction("SRV : Ask client for JS property `innerHTML`");
                AddLogAction("JS : Response with `innerHTML` value");
                AddLogAction("SRV : Set client " + buttonTestResponse.GetUuid() +
                             " JS property `innerHTML` with the same label adding a point at the end");

                var label = await buttonTestResponse.GetProperty("innerHTML");
                buttonTestResponse.SetProperty("innerHTML",
                    $"{label}."); // add a point as an example of the workflow on every call
            });
        }

        private void ClearLogActions()
        {
            RightColumn.SetText("");
        }

        private void AddLogAction(string log)
        {
            RightColumn.SetText(RightColumn.GetText() + log + "<br/>");
        }
    }
}