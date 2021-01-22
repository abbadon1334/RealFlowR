using System.Linq;
using FlowR.Core.Components;
using FlowR.Core.Components.Controls;
using FlowR.UI.Components;
using Microsoft.AspNetCore.SignalR;

namespace FlowR
{
    public class Application : UI.Application
    {
        protected readonly Div RightColumn;
        protected int Counter = 0;

        public Application(string connectionId, IClientProxy client) : base(connectionId, client)
        {
            
            RootElement.SetAttribute("css", "d-flex h-100 text-center text-white bg-dark");

            var Navbar = RootElement.Add<Navbar>();
            Navbar.AddBrand().SetText("FlowR");
            Navbar.AddToggler();
            Navbar.AddCSSClass("navbar-dark bg-dark");

            var main = RootElement.Add<Div>();

            var menu = Navbar.AddMenu();
            menu.AddMenuItem().SetText("Add Dark").onClick((sender, args) =>
            {
                Navbar.AddCSSClass("navbar-dark bg-dark");
            });
            menu.AddMenuItem().SetText("Remove Dark").onClick((sender, args) =>
            {
                Navbar.RemoveCSSClass("navbar-dark").RemoveCSSClass("bg-dark");
            });
            menu.AddMenuItem().SetText("Link C").onClick((sender, args) =>
            {
                
            });
        }
    }
}