using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    public class Sweepstakes
    {
        // Member variables
        private Dictionary<int, Contestant> contestants;
        private bool locked;    // Once a winner is picked, the sweepstake is locked to new entries
        private string name;
        public string Name { get { return name; } }

        static private Random winnerPicker;

        // constructor
        public Sweepstakes(string name)
        {
            this.name = name;
            locked = false;

            contestants = new Dictionary<int, Contestant>();

            winnerPicker = new Random();
        }

        // Member methods
        public void RegisterContestant(Contestant contestant)
        {
            if (!locked)
            {
                contestant.registrationNumber = contestants.Count + 1;
                contestants.Add(contestant.registrationNumber, contestant);
            }
        }

        public Contestant PickWinner()
        {
            locked = true;

            Contestant contestant;

            contestants.TryGetValue(winnerPicker.Next(1, contestants.Count), out contestant);

            if (contestant != null)         // Dictionary not empty
                contestant = MakeWinnerContestant(contestant);     

            return contestant;
        }

        private Winner MakeWinnerContestant(Contestant contestant)
        {
            Winner winner = new Winner();

            winner.firstName = contestant.firstName;
            winner.lastName = contestant.lastName;
            winner.emailAddress = contestant.emailAddress;
            winner.registrationNumber = contestant.registrationNumber;

            contestants.Remove(contestant.registrationNumber);
            contestants.Add(winner.registrationNumber, winner);

            return winner;
        }

        public void PrintContestantsInfo()
        {
            UserInterface.PrintSweepstakesContestantsHeader(name);

            foreach (Contestant contestant in contestants.Values)
                contestant.PrintContestantInfoLine();
        }

        public void PrintWinnerContestantInfo(Contestant contestant)
        {
            UserInterface.PrintSweepstakesWinnerHeader(name);

            contestant.PrintContestantInfoLine();
        }

        public void NotifyContestants(Contestant winner)
        {
            UserInterface.PrintNotifyContestantsHeader(name);
            foreach (Contestant contestant in contestants.Values)
                contestant.Notify(name, winner);
        }
    }
}
