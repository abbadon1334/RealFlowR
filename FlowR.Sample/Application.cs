using System;
using System.Collections.Generic;
using System.Linq;
using FlowR.Core.Tags;
using FlowR.UI.Components;
using FlowR.UI.Forms;
using FlowR.UI.Forms.Controls;
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

            var columnForm = formRow.AddCol();
            var columnResult = formRow.AddCol();

            var form = columnForm.Add<Form>().SetAttribute("onsubmit", "return false;"); // @todo include inside Form

            // dry input
            var fldDry = form.Add<Input>("fldDry");

            // input control
            var fldInput = form.Add<Control>("fieldInput")
                .SetLabel("Field Input")
                .SetControl<Input>();

            // checkbox control
            var fldCheckbox = form.Add<Control>("fieldCheckbox")
                .SetLabel("Field Checkbox")
                .SetControl<Checkbox>();

            // Select control
            var fldSelect = form.Add<Control>("fieldSelect")
                .SetLabel("Field Select")
                .SetControl<Select>()
                .AddOption(new Dictionary<string, string>
                {
                    { "option1", "value1" },
                    { "option2", "value2" },
                    { "option3", "value3" },
                });

            // Submit button
            form.Add<Button>().SetText("Submit");

            form.On("submit", async (sender, args) =>
            {
                columnResult.RemoveAllChildren();

                var row1 = columnResult.Add<Row>();
                    row1.AddCol().SetText("fldDry");
                    row1.AddCol().SetText(await fldDry.CollectValueAsync());

                var row2 = columnResult.Add<Row>();
                    row2.AddCol().SetText("fieldInput");
                    row2.AddCol().SetText(await fldInput.CollectValueAsync());

                var row3 = columnResult.Add<Row>();
                    row3.AddCol().SetText("fieldCheckbox");
                    row3.AddCol().SetText(await fldCheckbox.CollectValueAsync());

                var row4 = columnResult.Add<Row>();
                    row4.AddCol().SetText("fldSelect");
                    row4.AddCol().SetText(await fldSelect.CollectValueAsync());
            });
        }
    }
}