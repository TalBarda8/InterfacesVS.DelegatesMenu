using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Delegate
{
    public class MainMenu
    {
        private readonly SubMenuItem m_RootItem;
        private SubMenuItem m_CurrentItem;

        public MainMenu(string i_MenuName)
        {
            m_RootItem = new SubMenuItem(i_MenuName);
            m_CurrentItem = m_RootItem;
        }

        public SubMenuItem CurrentItem
        {
            get { return m_CurrentItem; }
            set { m_CurrentItem = value; }
        }

        public SubMenuItem RootItem
        {
            get { return m_RootItem; }
        }

        public void Show()
        {
            bool v_State = true;
            int userInput = 0;
            CurrentItem = RootItem;

            while (v_State)
            {
                Console.Clear();
                CurrentItem.PrintMenuItem();
                userInput = readAndValidateUserInput();

                if (userInput == 0)
                {
                    actionForZeroInput(ref v_State);
                }
                else
                {
                    actionForNonZeroInput(userInput);
                }
            }
        }

        private int readAndValidateUserInput()
        {
            bool v_State = true;
            int chosenItemNumber = 0;

            while (v_State)
            {
                string userInput = Console.ReadLine();

                if (!int.TryParse(userInput, out chosenItemNumber))
                {
                    Console.WriteLine("Invalid input. Try again.");
                    continue;
                }

                if (chosenItemNumber >= 0 && chosenItemNumber <= CurrentItem.SubMenuItemsList.Count)
                {
                    v_State = false;
                }
                else
                {
                    Console.WriteLine("Invalid input. Try again.");
                    continue;
                }
            }

            return chosenItemNumber;
        }

        private void actionForZeroInput(ref bool o_State)
        {
            if (CurrentItem.ParentMenuItem == null)
            {
                o_State = false;
            }
            else
            {
                CurrentItem = CurrentItem.ParentMenuItem;
            }
        }

        private void actionForNonZeroInput(int i_UserInput)
        {
            if (CurrentItem.SubMenuItemsList[i_UserInput - 1] is LeafMenuItem)
            {
                Console.Clear();
                (CurrentItem.SubMenuItemsList[i_UserInput - 1] as LeafMenuItem).NotifyItemHasBeenChoosed();

                Console.WriteLine("\nOperation done. press any key to continue...");
                Console.ReadLine();
            }
            else
            {
                CurrentItem = CurrentItem.SubMenuItemsList[i_UserInput - 1] as SubMenuItem;
            }
        }

        public LeafMenuItem AddNewLeafMenuItem(string i_ItemName, SubMenuItem i_ParentItem)
        {
            LeafMenuItem newItem = new LeafMenuItem(i_ItemName);
            addNewItem(newItem, i_ParentItem);

            return newItem;
        }

        public SubMenuItem AddNewSubMenuItem(string i_ItemName, SubMenuItem i_ParentItem)
        {
            SubMenuItem newItem = new SubMenuItem(i_ItemName);
            addNewItem(newItem, i_ParentItem);

            return newItem;
        }

        private void addNewItem(MenuItem i_NewItem, SubMenuItem i_ParentItem)
        {
            if (checkIfItemExsists(i_ParentItem))
            {
                i_ParentItem.AddMenuItemToSubMenuList(i_NewItem);
            }
            else
            {
                throw new ArgumentException("Parent Item does not exsist.");
            }
        }

        public void RemoveItem(MenuItem i_Item)
        {
            if (checkIfItemExsists(i_Item))
            {
                i_Item.RemoveItemFromMenu();
            }
            else
            {
                throw new ArgumentException("Item does not exsist.");
            }
        }

        private bool checkIfItemExsists(MenuItem i_ItemToFind)
        {
            bool itemFound = false;

            while (i_ItemToFind != null)
            {
                if (i_ItemToFind == RootItem)
                {
                    itemFound = true;
                    break;
                }

                i_ItemToFind = i_ItemToFind.ParentMenuItem;
            }

            return itemFound;
        }
    }
}
