using System;
using System.Collections.Generic;

namespace FlowR.Library.Client
{
    /// <summary>
    /// Manage Application Timers
    /// </summary>
    public class ApplicationTimers
    {
        private readonly List<ApplicationTimer> _timers = new();

        /// <summary>
        /// Add Timer
        /// </summary>
        /// <param name="timer"></param>
        public void Add(ApplicationTimer timer)
        {
            timer.OnStop += (sender, args) => { _timers.Remove(sender as ApplicationTimer); };

            _timers.Add(timer);
            timer.Start();
        }

        /// <summary>
        /// Add Timer.
        /// </summary>
        /// <param name="delay"></param>
        /// <param name="callback"></param>
        /// <param name="infinite"></param>
        public void AddTimer(int delay, EventHandler callback, bool infinite = true)
        {
            var timer = new ApplicationTimer(delay, callback, infinite);
            Add(timer);
        }

        /// <summary>
        /// Remove Timer.
        /// </summary>
        /// <param name="timer"></param>
        public void Remove(ApplicationTimer timer)
        {
            timer.Stop();
        }
    }
}