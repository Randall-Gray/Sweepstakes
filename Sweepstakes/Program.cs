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
            Simulation simulation = new Simulation();

            do
            {
                simulation.RunSimulation();
            }
            while (UserInterface.AskUserYesOrNo("Would you like to run the simulation again"));
        }
    }
}
