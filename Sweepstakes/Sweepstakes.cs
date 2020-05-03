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
        private string name;
        public string Name { get { return name; } }

        // constructor
        public Sweepstakes(string name)
        {
            this.name = name;
        }

        // Member methods
        public void RegisterContestant(Contestant contestant)
        {

        }

        public Contestant PickWinner()
        {

        }

        public void PrintContestantInfo(Contestant contestant)
        {

        }
    }
}
