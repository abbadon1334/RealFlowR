using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace FlowR.UI
{
    /// <inheritdoc />
    public class Application : Core.Application
    {
        /// <inheritdoc />
        protected Application(string connectionId, IClientProxy client, ILogger<Application> logger) : base(connectionId, client, logger)
        {
            AddStylesheetResource("https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta1/dist/css/bootstrap.min.css");
            AddJavascriptResource("https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta1/dist/js/bootstrap.min.js");
            AddJavascriptResource("https://cdn.jsdelivr.net/npm/@popperjs/core@2.5.4/dist/umd/popper.min.js");
        }
    }
}