using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using FlowR.Library.Client.Message;

namespace FlowR.Library.Client
{
    public class ApplicationResponses
    {
        private readonly ConcurrentDictionary<string, string> _completed = new();
        private readonly ConcurrentDictionary<string, MessageWithResponse> _pending = new();

        public async Task<string> WaitResponse(Application app, MessageWithResponse message, int timeoutSeconds = 2)
        {
            _pending.TryAdd(message.GetUuid(), message);
            await app.SendMessage(message);
            var answerCancel = new CancellationTokenSource();
            answerCancel.CancelAfter(TimeSpan.FromSeconds(timeoutSeconds));

            return await Task.Run(() =>
            {
                var response = "";

                while (!_completed.TryGetValue(message.GetUuid(), out response)) Task.Delay(150, answerCancel.Token);

                return response;
            }, answerCancel.Token);
        }

        public void SetResponse(MessageWithResponse message)
        {
            if (!_pending.TryGetValue(message.GetUuid(), out var storedMessage)) return;

            storedMessage.SetResponse(message.GetResponse());
            _pending.TryRemove(message.GetUuid(), out _);

            _completed.TryAdd(message.GetUuid(), storedMessage.GetResponse());
        }
    }
}