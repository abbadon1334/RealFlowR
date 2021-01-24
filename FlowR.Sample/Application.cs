using FlowR.Core.Tags;
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

            var Navbar = RootElement.Add<Navbar>();
            Navbar.AddBrand().SetText("FlowR");
            Navbar.AddToggler();
            Navbar.AddCSSClass("navbar-dark bg-dark");

            var main = RootElement.Add<Div>();

            var menu = Navbar.AddMenu();
            var menuItem = menu.AddMenuItem();
            menuItem.SetText("Add Dark");
            menuItem.OnClick((sender, args) =>
            {
                Navbar.AddCSSClass("navbar-dark bg-dark");
            });
            var menuItem2 = menu.AddMenuItem();
            menuItem2.SetText("Remove Dark");
            menuItem2.OnClick((sender, args) =>
            {
                Navbar.RemoveCSSClass("navbar-dark");
                Navbar.RemoveCSSClass("bg-dark");
            });
            var menuItem3 = menu.AddMenuItem();
            menuItem3.SetText("Link C");
            menuItem3.OnClick((sender, args) =>
            {
            });
        }
    }
}