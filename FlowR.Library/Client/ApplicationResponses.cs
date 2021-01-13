using FlowR.Library.Client.Message;
using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace FlowR.Library.Client
{
    /// <summary>
    /// Logicv class for Message Responses
    /// </summary>
    public class ApplicationResponses
    {
        private readonly ConcurrentDictionary<string, string> _completed = new();
        private readonly ConcurrentDictionary<string, MessageWithResponse> _pending = new();

        /// <summary>
        /// [internal use] Send and wait for a response
        /// </summary>
        /// <param name="app"></param>
        /// <param name="message"></param>
        /// <param name="timeoutSeconds"></param>
        /// <returns></returns>
        public async Task<string> WaitResponse(Application app, MessageWithResponse message, int timeoutSeconds = 2)
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
                    // remove completed
                    _completed.TryRemove(message.GetUuid(), out _);
                    // @todo if hit the timeout _completed remain an extra item, can be moved after the while or... ?
                    
                    Task.Delay(2, answerCancel.Token);
                }

                return response;
            }, answerCancel.Token);
        }

        /// <summary>
        /// [internal use] Process response from client
        /// </summary>
        /// <param name="message"></param>
        public void SetResponse(MessageWithResponse message)
        {
            if (!_pending.TryGetValue(message.GetUuid(), out var storedMessage)) return;

            storedMessage.SetResponse(message.GetResponse());
            _pending.TryRemove(message.GetUuid(), out _);

            _completed.TryAdd(message.GetUuid(), storedMessage.GetResponse());
        }
    }
}