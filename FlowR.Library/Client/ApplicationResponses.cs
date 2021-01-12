using FlowR.Library.Client.Message;
using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace FlowR.Library.Client
{
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'ApplicationResponses' visibile pubblicamente
    public class ApplicationResponses
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'ApplicationResponses' visibile pubblicamente
    {
        private readonly ConcurrentDictionary<string, string> _completed = new();
        private readonly ConcurrentDictionary<string, MessageWithResponse> _pending = new();

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'ApplicationResponses.WaitResponse(Application, MessageWithResponse, int)' visibile pubblicamente
        public async Task<string> WaitResponse(Application app, MessageWithResponse message, int timeoutSeconds = 2)
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'ApplicationResponses.WaitResponse(Application, MessageWithResponse, int)' visibile pubblicamente
        {
            _pending.TryAdd(message.GetUuid(), message);
            await app.SendMessage(message);
            var answerCancel = new CancellationTokenSource();
            answerCancel.CancelAfter(TimeSpan.FromSeconds(timeoutSeconds));

            return await Task.Run(() =>
            {
                var response = "";

                while (!_completed.TryGetValue(message.GetUuid(), out response))
                {
                    Task.Delay(10, answerCancel.Token);
                }

                return response;
            }, answerCancel.Token);
        }

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'ApplicationResponses.SetResponse(MessageWithResponse)' visibile pubblicamente
        public void SetResponse(MessageWithResponse message)
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'ApplicationResponses.SetResponse(MessageWithResponse)' visibile pubblicamente
        {
            if (!_pending.TryGetValue(message.GetUuid(), out var storedMessage)) return;

            storedMessage.SetResponse(message.GetResponse());
            _pending.TryRemove(message.GetUuid(), out _);

            _completed.TryAdd(message.GetUuid(), storedMessage.GetResponse());
        }
    }
}