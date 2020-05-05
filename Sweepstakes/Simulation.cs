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
        private MarketingFirm marketingFirm;

        // constructor
    
        // Member methods
        public void RunSimulation()
        {
            UserInterface.Welcome();

            CreateMarketingFirmWithManager();

            // Create sweepstakes with contestants
            while (UserInterface.AskUserYesOrNo("Create sweepstakes", true))
                marketingFirm.CreateSweepstake();

            // Declare winners for all sweepstakes
            UserInterface.PrintSweepstakesResultsHeader();
            while (marketingFirm.RunNextSweepstake());
        }

        public void CreateMarketingFirmWithManager()
        {
            SweepstakesManagerStore sweepstakesManagerStore = new SweepstakesManagerStore();

            string sweepstakesManagerType = UserInterface.GetSweepstackesManagerType(sweepstakesManagerStore.SweepstakesManagerTypes);

            ISweepstakesManager sweepstakesManager = sweepstakesManagerStore.GetSweepstakesManager(sweepstakesManagerType);

            marketingFirm = new MarketingFirm(sweepstakesManager);
        }
    }
}
