using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    public interface IGetSweepstakesManager
    {
        // Member properties
        string[] SweepstakesManagerTypes { get; }

        // Member methods
        ISweepstakesManager GetSweepstakesManager(string type);
    }
}
