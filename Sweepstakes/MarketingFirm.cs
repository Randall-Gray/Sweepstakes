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
        public void CreateSweepstake()
        {
            Sweepstakes sweepstakes = new Sweepstakes(UserInterface.GetUserInputFor("Sweepstakes Name"));

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

            manager.InsertSweepstakes(sweepstakes);
        }

        public bool RunNextSweepstake()
        {
            if (manager.GetCount() == 0)
                return false;

            Sweepstakes sweepstake = manager.GetSweepstakes();

            sweepstake.PrintContestantsInfo();
            Contestant winner = sweepstake.PickWinner();
            sweepstake.PrintWinnerContestantInfo(winner);
            sweepstake.NotifyContestants(winner);

            return true;
        }
    }
}
