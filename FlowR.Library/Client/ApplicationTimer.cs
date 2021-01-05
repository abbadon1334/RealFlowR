
using System;
using System.ComponentModel;
using System.Timers;

namespace FlowR.Library.Client
{
    public class ApplicationTimer
    {
        private string _name;
        private int _delay;
        private Timer _timer;
        private readonly bool _infinite;

        public ApplicationTimer(int delay, bool infinite = true)
        {
            _delay = delay;
            _name = Guid.NewGuid().ToString();
            _infinite = infinite;
        }

        public void Start() {
            _timer = new System.Timers.Timer(2000);
            _timer.Elapsed += OnTimer;
            _timer.AutoReset = _infinite ? true : false;
            _timer.Enabled = true;
        }

        private void OnTimer(object sender, ElapsedEventArgs e)
        {
            
        }

        public void Stop()
        {
            _timer.Stop();
            _timer.Dispose();
        }
    }
}