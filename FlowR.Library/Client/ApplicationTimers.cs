using System;
using System.Collections.Generic;

namespace FlowR.Library.Client
{
    public class ApplicationTimers
    {
        private readonly List<ApplicationTimer> _timers = new();

        public void Add(ApplicationTimer timer)
        {
            timer.OnStop += (sender, args) =>
            {
                _timers.Remove(sender as ApplicationTimer);
            };
            
            _timers.Add(timer);
            timer.Start();
        }

        public void AddTimer(int delay, EventHandler callback, bool infinite = true)
        {
            var timer = new ApplicationTimer(delay, callback, infinite);
            Add(timer);
        }

        public void Remove(ApplicationTimer timer)
        {
            timer.Stop();
        }
    }
}