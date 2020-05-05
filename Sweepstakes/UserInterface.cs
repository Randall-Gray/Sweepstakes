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
        static public void Welcome()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Marketing Firm Sweepstakes Simulator");
        }

        // Get type of sweepstakes manager to use.
        static public string GetSweepstackesManagerType(string[] sweepstakesManagerTypes)
        {
            bool validInput;
            int type;

            do
            {
                Console.WriteLine("\nSelect type of sweepstakes manager: ");
                DisplaySweepstakesManagerTypes(sweepstakesManagerTypes);

                validInput = int.TryParse(Console.ReadLine(), out type);
            }
            while (!validInput || type <= 0 || type > sweepstakesManagerTypes.Length);

            return sweepstakesManagerTypes[type - 1];
        }

        // Display numbered list of Sweepstakes Manager types for user integer input.
        static private void DisplaySweepstakesManagerTypes(string[] sweepstakesManagerTypes)
        {
            for (int i = 0; i < sweepstakesManagerTypes.Length; i++)
            {
                 Console.WriteLine((i + 1) + ") " + sweepstakesManagerTypes[i]);
            }
        }

        // Input sweepstakes name or contestant first name, last name, email address
        static public string GetUserInputFor(string prompt)
        {
            Console.WriteLine("Enter " + prompt + ":");
            return Console.ReadLine();
        }

        // Displays sweepstakes contestant information and registration number.
        static public void ConfirmRegistration(string sweepstakesName, Contestant contestant)
        {
            Console.WriteLine("\n\"{0}\" Sweepstakes Entry", sweepstakesName);
            PrintContestantInfoLine(contestant);
        }

        // Displays all of a contestant's information on a single line.
        static public void PrintContestantInfoLine(Contestant contestant)
        {
            Console.Write("Contestant #{0}  ", contestant.registrationNumber);
            Console.Write("\tName: {0} {1}  ", contestant.firstName, contestant.lastName);
            Console.WriteLine("\tEmail: {0}", contestant.emailAddress);
        }

        // Displays all of a winning contestant's information on a single line with indication of being a winner.
        static public void PrintWinnerContestantInfoLine(Contestant contestant)
        {
            Console.Write("WINNER - Contestant #{0}  ", contestant.registrationNumber);
            Console.Write("\tName: {0} {1}  ", contestant.firstName, contestant.lastName);
            Console.WriteLine("\tEmail: {0}", contestant.emailAddress);
        }

        // Display header before listing all sweepstakes results.
        static public void PrintSweepstakesResultsHeader()
        {
            Console.Clear();
            Console.WriteLine("Sweepstakes Results");
        }

        // Display header before listing all contestants of a sweepstakes.
        static public void PrintSweepstakesContestantsHeader(string sweepstakeName)
        {
            Console.WriteLine("\n\"{0}\" Sweepstakes Entrants: ", sweepstakeName);
        }

        // Display header before listing winner of a sweepstakes.
        static public void PrintSweepstakesWinnerHeader(string sweepstakeName)
        {
            Console.WriteLine("\n\"{0}\" Sweepstakes Winner: ", sweepstakeName);
        }

        // Display header before listing contestant notifications.
        static public void PrintNotifyContestantsHeader(string sweepstakeName)
        {
            Console.WriteLine("\n\"{0}\" Sweepstakes Sending Contestant Notifications: ", sweepstakeName);
        }

        // No contestants, no winner, no notifications.
        static public void PrintNone()
        {
            Console.WriteLine("(None)");
        }

        // Notification sent for a non-winning contestant.
        static public void NotifyNonWinner(string sweepstakesName, Contestant contestant, Contestant winner)
        {
            Console.WriteLine("To: {0} {1} (Email: {2})", contestant.firstName, contestant.lastName, contestant.emailAddress);
            Console.WriteLine("\"{0}\" Sweepstakes: Sorry!! You are not a winner!! (Winner: {1} {2})", sweepstakesName, winner.firstName, winner.lastName);
        }

        // Notification sent for a winning contestant.
        static public void NotifyWinner(string sweepstakesName, Contestant contestant)
        {
            Console.WriteLine("To: {0} {1} (Email: {2})", contestant.firstName, contestant.lastName, contestant.emailAddress);
            Console.WriteLine("\"{0}\" Sweepstakes: Congratulations!! You are a winner!!", sweepstakesName);
        }

        // Ask user a Yes or No question e.g. "Everything okay", "Go again"
        // Clear console screen first if clearScreen = true;
        static public bool AskUserYesOrNo(string question, bool clearScreen = false)
        {
            if (clearScreen)
                Console.Clear();
            Console.WriteLine("\n" + question + "? (Y/N)");
            return Console.ReadLine().ToUpper() == "Y";
        }
    }
}
