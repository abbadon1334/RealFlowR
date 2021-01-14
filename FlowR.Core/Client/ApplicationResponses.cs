using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using FlowR.Library.Client.Message;

namespace FlowR.Library.Client
{
    /// <summary>
    ///     Logicv class for Message Responses
    /// </summary>
    public class ApplicationResponses
    {
        private readonly ConcurrentDictionary<string, string> _completed = new();
        private readonly ConcurrentDictionary<string, MessageWithResponse> _pending = new();

        /// <summary>
        ///     [internal use] Send and wait for a response
        /// </summary>
        /// <param name="app"></param>
        /// <param name="message"></param>
        /// <param name="timeoutSeconds"></param>
        /// <returns></returns>
        public async Task<string> WaitResponse(Application app, MessageWithResponse message, int timeoutSeconds = 2)
        {
            _pending.TryAdd(message.GetUuid(), message);
            await app.Communication.SendMessage(message);
            var answerCancel = new CancellationTokenSource();
            answerCancel.CancelAfter(TimeSpan.FromSeconds(timeoutSeconds));

            return await Task.Run(() =>
            {
                var response = "";

                while (!_completed.TryGetValue(message.GetUuid(), out response))
                {
                    // remove completed
                    //_completed.TryRemove(message.GetUuid(), out _);
                    // @todo if hit the timeout _completed remain an extra item, how to remove it
                    // bad solution but give the idea, a pruning routine which remove completed, but who knows if they are already used? a flag ?

                    Task.Delay(2, answerCancel.Token);
                }

                return response;
            }, answerCancel.Token);
        }

        /// <summary>
        ///     [internal use] Process response from client
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