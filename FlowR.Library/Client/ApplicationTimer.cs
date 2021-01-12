using System;
using System.Timers;

namespace FlowR.Library.Client
{
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'ApplicationTimer' visibile pubblicamente
    public class ApplicationTimer
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'ApplicationTimer' visibile pubblicamente
    {
        private readonly EventHandler _callback;
        private readonly int _delay;
        private readonly bool _infinite;
        private Timer _timer;

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'ApplicationTimer.ApplicationTimer(int, EventHandler, bool)' visibile pubblicamente
        public ApplicationTimer(int delay, EventHandler callback, bool infinite = false)
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'ApplicationTimer.ApplicationTimer(int, EventHandler, bool)' visibile pubblicamente
        {
            _delay = delay;
            _callback = callback;
            _infinite = infinite;
        }

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'ApplicationTimer.Start()' visibile pubblicamente
        public void Start()
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'ApplicationTimer.Start()' visibile pubblicamente
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

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'ApplicationTimer.Stop()' visibile pubblicamente
        public void Stop()
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'ApplicationTimer.Stop()' visibile pubblicamente
        {
            _timer.Stop();
            OnStop?.Invoke(this, EventArgs.Empty);
        }

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'ApplicationTimer.OnStop' visibile pubblicamente
        public event EventHandler OnStop;
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'ApplicationTimer.OnStop' visibile pubblicamente
    }
}