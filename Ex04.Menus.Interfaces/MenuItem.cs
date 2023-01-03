using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interface
{
    public abstract class MenuItem
    {
        private readonly string m_ItemName;
        private SubMenuItem m_ParentMenuItem = null;

        public MenuItem(string i_ItemName)
        {
            m_ItemName = i_ItemName;
        }

        public string ItemName
        {
            get { return m_ItemName; }
        }

        public SubMenuItem ParentMenuItem
        {
            get { return m_ParentMenuItem; }
            set { m_ParentMenuItem = value; }
        }

        public void RemoveItemFromMenu()
        {
            this.ParentMenuItem.SubMenuItemsList.Remove(this);
            this.ParentMenuItem = null;
        }
    }
}
