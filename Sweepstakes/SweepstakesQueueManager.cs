using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    public class SweepstakesQueueManager : ISweepstakesManager
    {
        // Member variables
        private Queue<Sweepstakes> queue;

        // constructor
        public SweepstakesQueueManager()
        {
            queue = new Queue<Sweepstakes>();
        }

        // Member methods
        // Add Sweepstakes to the queue.
        public void InsertSweepstakes(Sweepstakes sweepstakes)
        {
            queue.Enqueue(sweepstakes);
        }

        // Remove Sweepstakes from the queue.
        public Sweepstakes GetSweepstakes()
        {
            if (queue.Count != 0)
                return queue.Dequeue();

            return null;
        }
    }
}
