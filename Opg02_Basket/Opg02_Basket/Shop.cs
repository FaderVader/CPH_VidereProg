using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opg02_Basket
{
    public class Shop
    {
        private Basket basket;

        private static decimal shippingCost = 50.0M;

        public static decimal ShippingCost
        {
            get { return shippingCost; }
            set { shippingCost = value; }
        }

        public Shop()
        {
            basket = new Basket();

            StockUp();
            WelComeShopper();
            TakeOrder();
        }

        private List<StoreItem> storeItems;

        private void StockUp()
        {
            storeItems = CreateItems.GetItems();
        }

        public void WelComeShopper()
        {
            Console.WriteLine("\nWELCOME SHOPPER, YOU CAN CHOOSE FROM:");
            storeItems.ForEach(item =>
            {
                Console.WriteLine($"{item.Name} for {item.Price}");
            });

            Console.WriteLine("\nYour options:");

        }

        public void TakeOrder()
        {
            string userInput;
            bool done = false;

            while (!done)
            {
                Console.WriteLine("\n1: show basket\n2: remove item from basket.\n3: show items\nexit: stop shopping.\n\nPlease type your choice:");
                userInput = Console.ReadLine();
                ProcessInput(userInput);
            }
        }

        private void ProcessInput(string userInput)
        {
            switch (userInput)
            {
                case "1":
                    ShowBasket(userInput);
                    break;

                case "2":
                    RemoveItemFromBasket();
                    break;

                case "3":
                    WelComeShopper();
                    break;

                case "exit":
                    GoodBye();
                    break;

                default:
                    AddItemToBasket(userInput);
                    break;
            }
        }

        private void GoodBye()
        {
            Console.WriteLine("Thanx for shopping");
            Environment.Exit(0);
        }

        private void AddItemToBasket(string userInput)
        {
            StoreItem item = storeItems.Where(x => x.Name.ToLower() == userInput.Trim().ToLower()).FirstOrDefault();
            if (item!=null && basket.AddItem(item))
            {
                Console.WriteLine($"Adding item to basket: {item.Name} for {item.Price}kr.");
            };
        }

        private void RemoveItemFromBasket()
        {
            Console.WriteLine($"Which item to remove?");
            string removeItem = Console.ReadLine();

            StoreItem item = storeItems.Where(x => x.Name.ToLower() == removeItem.Trim().ToLower()).FirstOrDefault();
            if (item != null && basket.RemoveItem(item))
            {
                Console.WriteLine($"Removed {item.Name} from basket");
            };
        }

        private void ShowBasket(string userInput)
        {            
            basket.ShowContents();
        }
    }
}
