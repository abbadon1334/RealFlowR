using System;
using System.Timers;

namespace FlowR.Library.Client
{

    /// <summary>
    /// Application timer class.
    /// </summary>
    public class ApplicationTimer
    {
        private readonly EventHandler _callback;
        private readonly int _delay;
        private readonly bool _infinite;
        private Timer _timer;

        /// <summary>
        /// ApplicationTimer
        /// </summary>
        /// <param name="delay">timeout to trigger Callback</param>
        /// <param name="callback">Callback to be triggered</param>
        /// <param name="infinite">Timeout = false, Interval = true</param>
        public ApplicationTimer(int delay, EventHandler callback, bool infinite = false)
        {
            _delay = delay;
            _callback = callback;
            _infinite = infinite;
        }

        /// <summary>
        /// Start the Timer.
        /// </summary>
        public void Start()
        {
            _timer = new Timer(_delay);
            _timer.Elapsed += (o, args) =>
            {
                _callback((Timer)o, args);

                if (!_infinite) ((Timer)o).Stop();
            };
            _timer.AutoReset = _infinite;
            _timer.Enabled = true;
        }
        
        /// <summary>
        /// Stop the Timer
        /// </summary>
        public void Stop()
        {
            _timer.Stop();
            OnStop?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Event handler for stop event.
        /// </summary>
        public event EventHandler OnStop;
    }
}