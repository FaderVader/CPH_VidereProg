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
            if (item == null) return false;

            try
            {
                basketItems.Add(item);
                Console.WriteLine($"Added {item.Name} at {item.Price.ToKr()}kr");
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

            if (purgeItem == null)
            {
                Console.WriteLine($"{purgeItem} not found in basket");
                return false;
            }

            if (basketItems.Count < 1)
            {
                Console.WriteLine($"Cannot remove {purgeItem.Name} - basket is empty");
                return false;
            }

            if (basketItems.Contains(purgeItem))
            {
                foreach (var item in basketItems)
                {
                    if (item.Name == purgeItem.Name)
                    {
                        basketItems.Remove(item);
                        totalPrice -= purgeItem.Price;
                        return true;
                    }
                }
                return true;
            }
            else
            {
                Console.WriteLine($"{purgeItem.Name} not found in basket");
                return false;
            }
        }

        internal void ShowContents()
        {
            if (basketItems.Count < 1)
            {
                Console.WriteLine("Basket is empty ?");
                return;
            }

            var uniqueTypes = new Dictionary<StoreItem, int>();
            basketItems.ForEach(item =>
            {
                if (uniqueTypes.ContainsKey(item))
                {
                    uniqueTypes[item]++;
                }
                else
                {
                    uniqueTypes.Add(item, 1);
                }
            });

            Console.WriteLine();
            foreach (KeyValuePair<StoreItem, int> itemAndPrice in uniqueTypes)
            {
                string price = (itemAndPrice.Key.Price * itemAndPrice.Value).ToKr();
                Console.WriteLine($"Item: {itemAndPrice.Key.Name}\tCount: {itemAndPrice.Value}\tSub-total: {price}kr.");
            }
            Console.WriteLine($"Your total, incl {Shop.ShippingCost.ToKr()}kr shipping: {Totalprice.ToKr()}kr.");
        }

        public decimal Totalprice
        {
            get
            {
                return totalPrice + Shop.ShippingCost;
            }
        }
    }
}
