using FlowR.Core;
using Microsoft.AspNetCore.SignalR;

namespace FlowR.Tests.Mock
{
    public class ApplicationMock : Application
    {
        public ApplicationMock(string connectionId, IClientProxy client) : base(connectionId, client)
        {
        }

        public ComponentRoot GetComponentRoot()
        {
            return RootElement;
        }
    }
}