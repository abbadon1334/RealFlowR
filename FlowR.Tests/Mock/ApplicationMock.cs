using FlowR.Core;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace FlowR.Tests.Mock
{
    public class ApplicationMock : Application
    {
        public ApplicationMock(string connectionId, IClientProxy client, ILogger<Application> logger) : base(connectionId, client, logger)
        {
        }

        public NodeElementRoot GetComponentRoot()
        {
            return RootElement;
        }
    }
}