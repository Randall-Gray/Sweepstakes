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
        public void InsertSweepstakes(Sweepstakes sweepstakes)
        {
            stack.Push(sweepstakes);
        }

        public Sweepstakes GetSweepstakes()
        {
            return stack.Pop();
        }

        public int GetCount()
        {
            return stack.Count;
        }
    }
}
