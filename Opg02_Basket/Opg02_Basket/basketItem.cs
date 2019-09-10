using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opg02_Basket
{
    public class BasketItem
    {
        public StoreItem item;
        private int countOfItems;

        public BasketItem(StoreItem item)
        {
            this.item = item;
            this.countOfItems++;
        }

        public int Count { get { return countOfItems; } }        
    }
}
