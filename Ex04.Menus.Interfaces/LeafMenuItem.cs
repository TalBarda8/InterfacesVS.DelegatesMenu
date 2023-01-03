using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interface
{
    public class LeafMenuItem : MenuItem
    {
        private readonly List<IChoosedItemObserver> m_ChoosedItemObservers = new List<IChoosedItemObserver>();

        public LeafMenuItem(string i_ItemName) : base(i_ItemName)
        {
        }

        public void AttachObserver(IChoosedItemObserver i_ChoosedItemObserver)
        {
            m_ChoosedItemObservers.Add(i_ChoosedItemObserver);
        }

        public void DetachObserver(IChoosedItemObserver i_ChoosedItemObserver)
        {
            m_ChoosedItemObservers.Remove(i_ChoosedItemObserver);
        }

        public void NotifyItemHasBeenChoosed()
        {
            OnItemChoose();
        }

        protected virtual void OnItemChoose()
        {
            foreach (IChoosedItemObserver observer in m_ChoosedItemObservers)
            {
                observer.ReportChoosed();
            }
        }
    }
}