using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace FlowR.Tests.Mock
{
    public class ClientProxyMock : IClientProxy
    {
        public List<ClientMessageSent> MessageSents = new();

        public Task SendCoreAsync(string method, object[] args, CancellationToken cancellationToken = new())
        {
            MessageSents.Add(new ClientMessageSent
            {
                Method = method,
                Arguments = args as string[]
            });

            return Task.FromResult(0);
        }

        public bool HasMessage()
        {
            return MessageSents.Count > 0;
        }

        public ClientMessageSent ConsumeMessage()
        {
            var message = MessageSents.First();

            MessageSents.Remove(message);

            return message;
        }
    }

    public struct ClientMessageSent
    {
        public string Method;
        public string[] Arguments;
    }
}