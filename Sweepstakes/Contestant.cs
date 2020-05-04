using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    public class Contestant
    {
        // Member variables
        public string firstName;
        public string lastName;
        public string emailAddress;
        public int registrationNumber;

        // constructor

        // Member methods
        public virtual void PrintContestantInfoLine()
        {
            UserInterface.PrintContestantInfoLine(this);
        }

        public virtual void Notify(string sweepstakesName, Contestant winner)
        {
            UserInterface.NotifyNonWinner(sweepstakesName, this, winner);
        }
    }
}
