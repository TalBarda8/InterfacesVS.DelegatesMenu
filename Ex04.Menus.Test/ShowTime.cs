using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Test
{
    public class ShowTime : Interface.IChoosedItemObserver
    {
        void Interface.IChoosedItemObserver.ReportChoosed()
        {
            string time = DateTime.Now.ToString("T");
            Console.WriteLine($"Current time is: {time}");
        }
    }
}
