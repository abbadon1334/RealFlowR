using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowR.Services
{
    public class ApplicationService
    {
        private int counter = 0;
        private Dictionary applications = new Dictionary<string, ClientApplication>();

        /**
        ClientApplication
         - rootelement
          - form
            - input
            - input
            - input
            - input
            - input
            - button
        **/
        /** Db context using in EF fa coda automaticamente */

        public void Increment()
        {
            counter++;
        }

        public int getCounter()
        {
            return counter;
        }
    }
}
