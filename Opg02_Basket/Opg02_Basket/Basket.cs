using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opg02_Basket
{
    public class Basket
    {
        private List<StoreItem> basketItems;
        private decimal totalPrice;

        public Basket()
        {
            basketItems = new List<StoreItem>();
            Console.WriteLine("Basket ready for shopping");
        }

        public bool AddItem(StoreItem item)
        {
            try
            {
                basketItems.Add(item);
                Console.WriteLine($"Added {item.Name} at {item.Price}");
                totalPrice += item.Price;

                return true;
            }
            catch (Exception)
            {
                Console.WriteLine($"{item} not found in inventory");
                return false;
            }
        }

        public bool RemoveItem(StoreItem purgeItem)
        {
            List<StoreItem> tempBasket;

            if (basketItems.Count < 1) {
                Console.WriteLine($"Cannot remove {purgeItem.Name} - basket is empty");
                return false;
            }

            try
            {
                tempBasket = basketItems.Where(item => item.Name != purgeItem.Name).ToList();
                basketItems = tempBasket;
                totalPrice -= purgeItem.Price;
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine($"{purgeItem} not found in basket");
                return false;
            }

        }

        internal void ShowContents()
        {

            if (basketItems.Count > 0)
            {
                basketItems.ForEach(item =>
                {
                    Console.WriteLine($"{item.Name} - {item.Price}");
                });
            } else
            {
                Console.WriteLine("Basket is currently empty");
            }


        }
    }
}
