using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    public class SweepstakesManagerStore : IGetSweepstakesManager
    {
        // Member variables
        private string[] sweepstakesManagerTypes = { "stack", "queue" };
        public string[] SweepstakesManagerTypes { get { return sweepstakesManagerTypes; } }

        // constructor

        // Member methods
        public ISweepstakesManager GetSweepstakesManager(string type)
        {
            ISweepstakesManager sweepstakesManager;

            switch (type)
            {
                case "stack":
                    sweepstakesManager = new SweepstakesStackManager();
                    break;
                case "queue":
                    sweepstakesManager = new SweepstakesQueueManager();
                    break;
                default:
                    throw new ApplicationException(string.Format("Not a valid Sweepstakes Manager Type"));
            }

            return sweepstakesManager;
        }
    }
}
