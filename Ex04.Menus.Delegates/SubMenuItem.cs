using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Delegate
{
    public class SubMenuItem : MenuItem
    {
        private readonly List<MenuItem> m_SubMenuItemsList;

        public SubMenuItem(string i_ItemName) : base(i_ItemName)
        {
            m_SubMenuItemsList = new List<MenuItem>();
        }

        public List<MenuItem> SubMenuItemsList
        {
            get { return m_SubMenuItemsList; }
        }

        public void AddMenuItemToSubMenuList(MenuItem i_NewMenuItem)
        {
            SubMenuItemsList.Add(i_NewMenuItem);
            i_NewMenuItem.ParentMenuItem = this;
        }

        public void PrintMenuItem()
        {
            string backOrExit = string.Empty;

            Console.WriteLine($"**{ItemName}**");
            Console.WriteLine("==============");

            for (int i = 1; i <= SubMenuItemsList.Count; i++)
            {
                Console.WriteLine($"{i}. {SubMenuItemsList[i - 1].ItemName}");
            }

            if (ParentMenuItem != null)
            {
                Console.WriteLine("0. Back");
                backOrExit = "Back";
            }
            else
            {
                Console.WriteLine("0. Exit");
                backOrExit = "Exit";
            }

            Console.WriteLine("==============");
            Console.WriteLine($"Please enter your choise (1-{SubMenuItemsList.Count} or 0 to {backOrExit}).");
        }
    }
}
