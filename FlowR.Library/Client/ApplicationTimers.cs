using System;
using System.Collections.Generic;

namespace FlowR.Library.Client
{
#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'ApplicationTimers' visibile pubblicamente
    public class ApplicationTimers
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'ApplicationTimers' visibile pubblicamente
    {
        private readonly List<ApplicationTimer> _timers = new();

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'ApplicationTimers.Add(ApplicationTimer)' visibile pubblicamente
        public void Add(ApplicationTimer timer)
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'ApplicationTimers.Add(ApplicationTimer)' visibile pubblicamente
        {
            timer.OnStop += (sender, args) => { _timers.Remove(sender as ApplicationTimer); };

            _timers.Add(timer);
            timer.Start();
        }

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'ApplicationTimers.AddTimer(int, EventHandler, bool)' visibile pubblicamente
        public void AddTimer(int delay, EventHandler callback, bool infinite = true)
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'ApplicationTimers.AddTimer(int, EventHandler, bool)' visibile pubblicamente
        {
            var timer = new ApplicationTimer(delay, callback, infinite);
            Add(timer);
        }

#pragma warning disable CS1591 // Manca il commento XML per il tipo o il membro 'ApplicationTimers.Remove(ApplicationTimer)' visibile pubblicamente
        public void Remove(ApplicationTimer timer)
#pragma warning restore CS1591 // Manca il commento XML per il tipo o il membro 'ApplicationTimers.Remove(ApplicationTimer)' visibile pubblicamente
        {
            timer.Stop();
        }
    }
}