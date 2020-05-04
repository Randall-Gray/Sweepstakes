using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    public class Simulation
    {
        // Member variables
        private string[] sweepstakesManagerTypes = { "stack", "queue" };

        private MarketingFirm marketingFirm;

        // constructor
        public Simulation()
        {
        }

        // Member methods
        public void RunSimulation()
        {
            UserInterface.Welcome();

            CreateMarketingFirmWithManager(UserInterface.GetSweepstackesManagerType(sweepstakesManagerTypes));

            // Create sweepstakes with contestants
            while (UserInterface.AskUserYesOrNo("Create sweepstakes", true))
                marketingFirm.CreateSweepstake();

            // Declare winners for all sweepstakes
            UserInterface.PrintSweepstakesResultsHeader();
            while (marketingFirm.RunNextSweepstake());
        }

        // Marketing Firm factory
        public void CreateMarketingFirmWithManager(string sweepstakesManagerType)
        {
            switch (sweepstakesManagerType)
            {
                case "stack":
                    marketingFirm = new MarketingFirm(new SweepstakesStackManager());
                    break;
                case "queue":
                    marketingFirm = new MarketingFirm(new SweepstakesQueueManager());
                    break;
            }
        }
    }
}
