using System;
using System.Timers;

namespace FlowR.Library.Client
{
    public class ApplicationTimer
    {
        private readonly EventHandler _callback;
        private readonly int _delay;
        private readonly bool _infinite;
        private Timer _timer;

        public ApplicationTimer(int delay, EventHandler callback, bool infinite = false)
        {
            _delay = delay;
            _callback = callback;
            _infinite = infinite;
        }

        public void Start()
        {
            _timer = new Timer(_delay);
            _timer.Elapsed += (o, args) =>
            {
                _callback((Timer) o, args);

                if (!_infinite) ((Timer) o).Stop();
            };
            _timer.AutoReset = _infinite;
            _timer.Enabled = true;
        }

        public void Stop()
        {
            _timer.Stop();
            OnStop?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler OnStop;
    }
}