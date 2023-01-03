using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Test
{
    public class InterfaceTest
    {
        private Interface.MainMenu m_MainMenu;
        private readonly Dictionary<string, Interface.MenuItem> m_MenuItemsList;

        public InterfaceTest()
        {
            m_MainMenu = null;
            m_MenuItemsList = new Dictionary<string, Interface.MenuItem>();
        }

        public Interface.MainMenu MainMenu
        {
            get { return m_MainMenu; }
        }

        public Dictionary<string, Interface.MenuItem> MenuItemList
        {
            get { return m_MenuItemsList; }
        }

        public void InitializeMainManu()
        {
            m_MainMenu = new Interface.MainMenu("Test - Interface Menu");

            m_MenuItemsList["Show Date/Time"] = m_MainMenu.AddNewSubMenuItem("Show Date/Time", m_MainMenu.RootItem);
            m_MenuItemsList["Version and Spaces"] = m_MainMenu.AddNewSubMenuItem("Version and Spaces", m_MainMenu.RootItem);

            m_MenuItemsList["Show Time"] = m_MainMenu.AddNewLeafMenuItem("Show Time", m_MenuItemsList["Show Date/Time"] as Interface.SubMenuItem);
            (m_MenuItemsList["Show Time"] as Interface.LeafMenuItem).AttachObserver(new ShowTime() as Interface.IChoosedItemObserver);

            m_MenuItemsList["Show Date"] = m_MainMenu.AddNewLeafMenuItem("Show Date", m_MenuItemsList["Show Date/Time"] as Interface.SubMenuItem);
            (m_MenuItemsList["Show Date"] as Interface.LeafMenuItem).AttachObserver(new ShowDate() as Interface.IChoosedItemObserver);

            m_MenuItemsList["Count Spaces"] = m_MainMenu.AddNewLeafMenuItem("Count Spaces", m_MenuItemsList["Version and Spaces"] as Interface.SubMenuItem);
            (m_MenuItemsList["Count Spaces"] as Interface.LeafMenuItem).AttachObserver(new CountSpaces() as Interface.IChoosedItemObserver);

            m_MenuItemsList["Show Version"] = m_MainMenu.AddNewLeafMenuItem("Show Version", m_MenuItemsList["Version and Spaces"] as Interface.SubMenuItem);
            (m_MenuItemsList["Show Version"] as Interface.LeafMenuItem).AttachObserver(new ShowVersion() as Interface.IChoosedItemObserver);
        }
    }
}
