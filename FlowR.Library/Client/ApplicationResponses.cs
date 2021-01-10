using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using FlowR.Library.Client.Message;

namespace FlowR.Library.Client
{
    public class ApplicationResponses
    {
        private readonly ConcurrentDictionary<string, MessageWithResponse> _pending = new();
        private readonly ConcurrentDictionary<string, string> _completed = new();
        
        public async Task<string> WaitResponse(Application app, MessageWithResponse message, int timeoutSeconds = 10)
        {
            _pending.TryAdd(message.GetUuid(), message);
            await app.SendMessage(message);
            var answerCancel = new CancellationTokenSource();
            answerCancel.CancelAfter(2 * 1000);

            return await Task.Run(() =>
            {
                string response = "";
                
                while (!_completed.TryGetValue(message.GetUuid(), out response)) {
                    Task.Delay(150, answerCancel.Token);
                }

                return response;
            }, answerCancel.Token);
        }

        public void SetResponse(MessageWithResponse message)
        {
            if (_pending.TryGetValue(message.GetUuid(), out MessageWithResponse storedMessage))
            {
                storedMessage.SetResponse(message.GetResponse());
                _pending.TryRemove(message.GetUuid(), out _);

                _completed.TryAdd(message.GetUuid(), storedMessage.GetResponse());
            }
        }
    }
}