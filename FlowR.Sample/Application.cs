using FlowR.Core.Tags;
using FlowR.UI;
using FlowR.UI.Components;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace FlowR
{
    public class Application : UI.Application
    {
        protected readonly Div RightColumn;
        protected int Counter = 0;

        public Application(string connectionId, IClientProxy client, ILogger<Core.Application> logger) : base(connectionId, client, logger)
        {
            RootElement.SetAttribute("css", "d-flex h-100 text-center text-white bg-dark");

            var navbar = RootElement.Add<Navbar>();
                navbar.AddCssClass("navbar-dark bg-dark");
                navbar.AddBrand().SetText("FlowR");
                navbar.AddToggler();

            var main = RootElement.Add<Div>();

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
                
            var menuItem3 = menu.AddMenuItem();
                menuItem3.SetText("Link C");
                menuItem3.OnClick((sender, args) =>
                {
                });
        }
    }
}