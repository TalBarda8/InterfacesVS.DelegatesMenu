using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Test
{
    public class DelegateTest
    {
        private Delegate.MainMenu m_MainMenu;
        private readonly Dictionary<string, Delegate.MenuItem> m_MenuItemsList;

        public DelegateTest()
        {
            m_MainMenu = null;
            m_MenuItemsList = new Dictionary<string, Delegate.MenuItem>();
        }

        public Delegate.MainMenu MainMenu
        {
            get { return m_MainMenu; }
        }

        public Dictionary<string, Delegate.MenuItem> MenuItemList
        {
            get { return m_MenuItemsList; }
        }

        public void InitializeMainManu()
        {
            m_MainMenu = new Delegate.MainMenu("Test - Delegate Menu");

            m_MenuItemsList["Show Date/Time"] = m_MainMenu.AddNewSubMenuItem("Show Date/Time", m_MainMenu.RootItem);
            m_MenuItemsList["Version and Spaces"] = m_MainMenu.AddNewSubMenuItem("Version and Spaces", m_MainMenu.RootItem);

            m_MenuItemsList["Show Time"] = m_MainMenu.AddNewLeafMenuItem("Show Time", m_MenuItemsList["Show Date/Time"] as Delegate.SubMenuItem);
            (m_MenuItemsList["Show Time"] as Delegate.LeafMenuItem).ItemChoose += showTimeItem_ItemChoose;

            m_MenuItemsList["Show Date"] = m_MainMenu.AddNewLeafMenuItem("Show Date", m_MenuItemsList["Show Date/Time"] as Delegate.SubMenuItem);
            (m_MenuItemsList["Show Date"] as Delegate.LeafMenuItem).ItemChoose += showDateItem_ItemChoose;

            m_MenuItemsList["Count Spaces"] = m_MainMenu.AddNewLeafMenuItem("Count Spaces", m_MenuItemsList["Version and Spaces"] as Delegate.SubMenuItem);
            (m_MenuItemsList["Count Spaces"] as Delegate.LeafMenuItem).ItemChoose += countSpacesItem_ItemChoose;

            m_MenuItemsList["Show Version"] = m_MainMenu.AddNewLeafMenuItem("Show Version", m_MenuItemsList["Version and Spaces"] as Delegate.SubMenuItem);
            (m_MenuItemsList["Show Version"] as Delegate.LeafMenuItem).ItemChoose += showVersionItem_ItemChoose;
        }

        private void showVersionItem_ItemChoose()
        {
            Console.WriteLine("Version: 22.2.4.8950");
        }

        private void showTimeItem_ItemChoose()
        {
            string time = DateTime.Now.ToString("T");
            Console.WriteLine($"Current time is: {time}");
        }

        private void showDateItem_ItemChoose()
        {
            string date = DateTime.Now.ToString("d");
            Console.WriteLine($"Current date is: {date}");
        }

        private void countSpacesItem_ItemChoose()
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
