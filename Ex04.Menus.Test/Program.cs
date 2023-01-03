using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            runInterfaceTest();
            runDelegateTest();
        }

        private static void runInterfaceTest()
        {
            InterfaceTest interfaceTest = new InterfaceTest();
            interfaceTest.InitializeMainManu();
            interfaceTest.MainMenu.Show();
        }

        private static void runDelegateTest()
        {
            DelegateTest delegateTest = new DelegateTest();
            delegateTest.InitializeMainManu();
            delegateTest.MainMenu.Show();
        }
    }
}
