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

        }
    }
}
