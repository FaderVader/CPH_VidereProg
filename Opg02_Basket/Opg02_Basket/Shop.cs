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

            Console.WriteLine("\nOther actions:");
            Console.WriteLine("1: show basket");
            Console.WriteLine("2: remove item from basket.");
            Console.WriteLine("exit: stop shopping.");

            Console.WriteLine("\nPlease type your choice:");
        }

        public void TakeOrder()
        {
            string userInput;
            bool done = false;

            while (!done)
            {
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
            if (basket.AddItem(item))
            {
                Console.WriteLine($"Adding item to basket: {item.Name} for {item.Price}");
            };


        }

        private void RemoveItemFromBasket()
        {
            Console.WriteLine($"Which item to remove?");
            string removeItem = Console.ReadLine();

            StoreItem item = storeItems.Where(x => x.Name.ToLower() == removeItem.Trim().ToLower()).FirstOrDefault();
            if (basket.RemoveItem(item))
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
