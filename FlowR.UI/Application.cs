using System.Collections.Generic;
using FlowR.Core.Components;
using FlowR.UI.Components;
using Microsoft.AspNetCore.SignalR;

namespace FlowR.UI
{
    /// <inheritdoc />
    public class Application : Core.Application
    {

        /// <inheritdoc />
        protected Application(string connectionId, IClientProxy client) : base(connectionId, client)
        {
            Communication.AddCss("https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta1/dist/css/bootstrap.min.css");
            Communication.AddScript("https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta1/dist/js/bootstrap.min.js");
            Communication.AddScript("https://cdn.jsdelivr.net/npm/@popperjs/core@2.5.4/dist/umd/popper.min.js");
        }
    }
}