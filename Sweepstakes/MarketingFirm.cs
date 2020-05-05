using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    public class MarketingFirm
    {
        // Member variables
        private ISweepstakesManager manager;

        // constructor
        public MarketingFirm(ISweepstakesManager manager)
        {
            this.manager = manager;
        }

        // Member methods
        // Create a Sweepstakes with contestants.
        public void CreateSweepstake()
        {
            Sweepstakes sweepstakes = new Sweepstakes(UserInterface.GetUserInputFor("Sweepstakes Name"));

            AddContestantsToSweepstakes(sweepstakes);

            manager.InsertSweepstakes(sweepstakes);
        }

        // Add contestants to the sweepstakes.
        private void AddContestantsToSweepstakes(Sweepstakes sweepstakes)
        {
            Contestant contestant;

            // Add contestants to sweepstakes
            while (UserInterface.AskUserYesOrNo("Enter contestant into \"" + sweepstakes.Name + "\" sweepstakes"))
            {
                contestant = new Contestant();

                contestant.firstName = UserInterface.GetUserInputFor("contestant first name");
                contestant.lastName = UserInterface.GetUserInputFor("contestant last name");
                contestant.emailAddress = UserInterface.GetUserInputFor("contestant email address");

                sweepstakes.RegisterContestant(contestant);
                UserInterface.ConfirmRegistration(sweepstakes.Name, contestant);
            }
        }

        // Get the next sweepstakes from the manager, pick a winner, notify all contestants.
        public bool RunNextSweepstake()
        {
            Sweepstakes sweepstake = manager.GetSweepstakes();

            if (sweepstake != null)
            {
                sweepstake.PrintContestantsInfo();
                Contestant winner = sweepstake.PickWinner();
                sweepstake.PrintWinnerContestantInfo(winner);
                sweepstake.NotifyContestants(winner);

                return true;
            }

            return false;
        }
    }
}
