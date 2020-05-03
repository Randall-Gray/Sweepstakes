using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    class Program
    {
        static void Main(string[] args)
        {
            Simulation marketingFirm = new Simulation();

            do
            {
                marketingFirm.CreateMarketingFirmWithManager();

                if (UserInterface.AskUserYesOrNo("Would you like to go again") != true)
                    break;
            }
            while (true);
        }
    }
}
