using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    static public class UserInterface
    {
        // Member methods
        static public string GetUserInputFor(string prompt)
        { 
        }

        // Ask user a Yes or No question e.g. "Everything okay", "Go again"
        static public bool AskUserYesOrNo(string question)
        {
            bool rtnAns;

            Console.WriteLine("\n" + question + "? (Y/N)");
            rtnAns = Console.ReadLine().ToUpper() == "Y";
            if (rtnAns)
                Console.Clear();
            return rtnAns;
        }
    }
}
