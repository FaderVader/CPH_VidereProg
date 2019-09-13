using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opg02_Basket
{
    public static class CreateItems
    {
        private static List<StoreItem> storeItems = new List<StoreItem>()
        {
            new StoreItem("T-shirt", 12.34M),
            new StoreItem("Sunglasses", 20.34M),
            new StoreItem("Boots", 34.50M),
            new StoreItem("Tent", 112.34M),
            new StoreItem("Poncho", 45.45M),
            new StoreItem("Compass", 31.25M),
            new StoreItem("Crackers", 5.40M)
        };


        static CreateItems()
        {
            Console.WriteLine("Inventory stocked up");
        }

        public static List<StoreItem> GetItems()
        {
            return storeItems;
        }
    }
}
