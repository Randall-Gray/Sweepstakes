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
        // Set contestant registration number and add to the Dictionary of contestants
        public void RegisterContestant(Contestant contestant)
        {
            if (!locked)
            {
                contestant.registrationNumber = contestants.Count + 1;
                contestants.Add(contestant.registrationNumber, contestant);
            }
        }

        // Use random number generator to pick a winner from the Dictionary of contestants.
        public Contestant PickWinner()
        {
            locked = true;      // No more contestants can register for this sweepstakes.

            Contestant contestant = null;

            if (contestants.Count > 0)
                contestants.TryGetValue(winnerPicker.Next(1, contestants.Count), out contestant);

            if (contestant != null)         // Dictionary not empty
                contestant = MakeWinnerContestant(contestant);     

            return contestant;
        }

        // Change the contestant to a winner object and replace it in the Dictionary of contestants.
        private Winner MakeWinnerContestant(Contestant contestant)
        {
            Winner winner = new Winner();

            winner.firstName = contestant.firstName;
            winner.lastName = contestant.lastName;
            winner.emailAddress = contestant.emailAddress;
            winner.registrationNumber = contestant.registrationNumber;

            contestants.Remove(contestant.registrationNumber);      // Remove the contestant
            contestants.Add(winner.registrationNumber, winner);     // Replace with a winner.

            return winner;
        }

        // Display all the contestants registered for the sweepstakes.
        public void PrintContestantsInfo()
        {
            UserInterface.PrintSweepstakesContestantsHeader(name);

            if (contestants.Count > 0)
            {
                foreach (Contestant contestant in contestants.Values)
                    contestant.PrintContestantInfoLine();           // winners will print different information.
            }
            else
                UserInterface.PrintNone();
        }

        // Display the winner of the sweepstakes information.
        public void PrintWinnerContestantInfo(Contestant contestant)
        {
            UserInterface.PrintSweepstakesWinnerHeader(name);

            if (contestant != null)
                contestant.PrintContestantInfoLine();               // winners will print different information.
            else
                UserInterface.PrintNone();
        }

        // Notify all the contestants in the sweepstakes whether they won or not.
        public void NotifyContestants(Contestant winner)
        {
            UserInterface.PrintNotifyContestantsHeader(name);
            if (contestants.Count > 0)
            {
                foreach (Contestant contestant in contestants.Values)
                    contestant.Notify(name, winner);                // winners will send different notification.
            }
            else
                UserInterface.PrintNone();
        }
    }
}
