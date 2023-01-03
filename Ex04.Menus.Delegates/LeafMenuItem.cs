using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Delegate
{
    public class LeafMenuItem : MenuItem
    {
        public event Action ItemChoose;

        public LeafMenuItem(string i_ItemName) : base(i_ItemName)
        {
        }

        public void NotifyItemHasBeenChoosed()
        {
            OnItemChoose();
        }

        protected virtual void OnItemChoose()
        {
            if (ItemChoose != null)
            {
                ItemChoose.Invoke();
            }
        }
    }
}