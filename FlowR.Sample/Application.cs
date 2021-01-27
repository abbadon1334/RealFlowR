using System;
using System.Linq;
using FlowR.Core.Tags;
using FlowR.Core.Tags.Controls;
using FlowR.UI.Components;
using FlowR.UI.Layout.Containers;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace FlowR
{
    public class Application : UI.Application
    {
        protected int Counter = 0;

        public Application(string connectionId, IClientProxy client, ILogger<Application> logger) : base(connectionId, client, logger)
        {
            RootElement.SetAttribute("css", "d-flex h-100 text-center text-white bg-dark");

            var navbar = RootElement.Add<Navbar>();
            navbar.AddCssClass("navbar-dark bg-dark");
            navbar.AddBrand().SetText("FlowR");
            navbar.AddToggler();

            var main = RootElement.Add<Div>();
            var container = main.Add<Container>();
            var masterRow = container.AddRow();

            var menu = navbar.AddMenu();
            var menuItem = menu.AddMenuItem();
            menuItem.SetText("Add Dark");
            menuItem.OnClick((sender, args) =>
            {
                navbar.AddCssClass("navbar-dark bg-dark");
            });

            var menuItem2 = menu.AddMenuItem();
            menuItem2.SetText("Remove Dark");
            menuItem2.OnClick((sender, args) =>
            {
                navbar.RemoveCssClass("navbar-dark");
                navbar.RemoveCssClass("bg-dark");
            });

            var menuItem4 = menu.AddMenuItem();
            menuItem4.SetText("Add Col");
            menuItem4.OnClick((sender, args) =>
            {
                masterRow
                    .Add<Column>()
                    .SetText(masterRow.GetChildren().Count().ToString());
            });

            var menuItem5 = menu.AddMenuItem();
            menuItem5.SetText("Remove Last Col");
            menuItem5.OnClick((sender, args) =>
            {
                masterRow.Remove(masterRow.GetChildren().Last().Value);
            });


            var menuItem6 = menu.AddMenuItem();
            menuItem6.SetText("Remove Last Col");

            masterRow.GetChildren().CollectionChanged += delegate
            {
                menuItem6.SetText(masterRow.GetChildren().Count().ToString());
            };


            var menuItem7 = menu.AddMenuItem();
            AddTimer(1, (sender, args) =>
            {
                menuItem7.SetText(DateTime.Now.Millisecond.ToString());
            });

            var formRow = container.AddRow();

            var form = formRow.Add<Form>();
            form.SetAttribute("onsubmit", "return false;");

            var fldInput = form.Add<Input>("fldTest");
            form.Add<Button>().SetText("Submit").SetAttribute("type", "submit");
            form.On("submit", async (sender, args) =>
            {
                var value = await fldInput.CollectValueAsync();
                form.GetApplication().CallGlobalMethod("alert", value);
            });
        }
    }
}