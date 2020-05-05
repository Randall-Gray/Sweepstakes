using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    public class SweepstakesStackManager : ISweepstakesManager
    {
        // Member variables
        private Stack<Sweepstakes> stack;

        // constructor
        public SweepstakesStackManager()
        {
            stack = new Stack<Sweepstakes>();
        }

        // Member methods
        // Add Sweepstakes to the stack.
        public void InsertSweepstakes(Sweepstakes sweepstakes)
        {
            stack.Push(sweepstakes);
        }

        // Remove Sweepstakes from the stack.
        public Sweepstakes GetSweepstakes()
        {
            if (stack.Count != 0)
                return stack.Pop();

            return null;
        }
    }
}
