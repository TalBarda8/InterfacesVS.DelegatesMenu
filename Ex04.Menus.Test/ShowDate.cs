using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Test
{
    public class ShowDate : Interface.IChoosedItemObserver
    {
        void Interface.IChoosedItemObserver.ReportChoosed()
        {
            string date = DateTime.Now.ToString("d");
            Console.WriteLine($"Current date is: {date}");
        }
    }
}