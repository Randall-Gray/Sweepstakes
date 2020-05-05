using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    public class Winner : Contestant
    {
        // Member variables

        // constructor

        // Member methods
        public override void PrintContestantInfoLine()
        {
            UserInterface.PrintWinnerContestantInfoLine(this);
        }

        public override void Notify(string sweepstakesName, Contestant winner)
        {
            UserInterface.NotifyWinner(sweepstakesName, winner);
        }
    }
}
