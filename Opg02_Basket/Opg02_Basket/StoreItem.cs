using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opg02_Basket
{
    public class StoreItem
    {

        public StoreItem(string name, decimal price)
        {
            this.name = name;
            this.price = price;
        }

        private decimal price;
        public decimal Price
        {
            get { return price; }            
        }

        private string name;

        public string Name
        {
            get { return name; }
        }


    }
}
