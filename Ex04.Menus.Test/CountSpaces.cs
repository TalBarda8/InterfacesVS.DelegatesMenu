using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Test
{
    public class CountSpaces : Interface.IChoosedItemObserver
    {
        void Interface.IChoosedItemObserver.ReportChoosed()
        {
            Console.WriteLine("Please enter your sentence:");
            string input = Console.ReadLine();
            int counter = 0;

            foreach (char letter in input)
            {
                if (letter == ' ')
                {
                    counter++;
                }
            }

            Console.WriteLine($"There are {counter} spaces in your sentence.");
        }
    }
}
