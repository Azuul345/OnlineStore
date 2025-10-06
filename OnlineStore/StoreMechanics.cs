using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OnlineStore
{
    internal class StoreMechanics
    {
        public static Product.CurrencyValue chosenCurrency = Product.CurrencyValue.SEK;

        private static List<Product> Inventory = new List<Product>()
        {
         new FruitAndVegetable(){ Name = "Apple", Price = 8, Type = "Fruit", Country = "Sweden", },
         new Drink(){Name = "Coca Cola", Size="M", Price = 20, Type = "Drink", },
         new Meal(){Name = "Hot Dog", Price = 15, MealType = "Snack" ,Type = "Food",}
        };
            
        public static void ShowCaseInventory()
        {
            Console.WriteLine("=== MENU ====");
            foreach(Product product in Inventory)
            {
                Console.WriteLine(product.ProductInfo(product.Currency)); //doublecheck
            }
        } 

        public static void SelectToCart(List<Product> cart)
        {
            int product = StoreMechanics.ValueCheckInt("" +
                "\nWhat would you like? " +
                "\n(1): Apple " +
                "\n(2): Coca Cola" +
                "\n(3): HotDog");

            switch(product)
            {
                case 1:
                    cart.Add(Inventory[0]);
                    break;
                case 2:
                    cart.Add(Inventory[1]);
                    break;
                case 3:
                    cart.Add(Inventory[2]);
                    break;
            }
        }


        public static void Changecurrency()
        {
            int choice = ValueCheckInt("Would you like to change Currency to: \n(1): US \n(2): EUR \n(3): SEK");
            switch (choice)
            {
                case 1:
                    chosenCurrency = Product.CurrencyValue.USD;
                    break;
                case 2:
                    chosenCurrency = Product.CurrencyValue.EUR;
                    break;
                case 3:
                    chosenCurrency = Product.CurrencyValue.SEK;
                    break;

            }
            Console.WriteLine($"Currency value is now {chosenCurrency}");
        }

        public static double  ShowcaseCart(List<Product> cart)
        {   int totalItems = 0;
            double totalSum = 0;
            foreach(Product product in cart)
            {
                Console.WriteLine(product.ProductInfo(product.Currency));//doublecheck
                totalSum += Product.PriceInCurrency(chosenCurrency, product.Price);
                totalItems++;
            }
            Console.WriteLine($"Total cost: {totalSum} {Product.CurrencySymbol(chosenCurrency)}. Total items: {totalItems}");
            return totalSum;
         
        }

        public static void ResetCart(List<Product> cart)
        {
            cart.Clear();

        }


        public static bool CheckedOut(double finalPrice)
        {
            
                Console.WriteLine($"Final price is: {finalPrice}");
                int choice = StoreMechanics.ValueCheckInt("(1): To check out and pay" +
                                                        "\n(2) to continue shopping");
                if (choice == 1)
                {
                    Console.WriteLine($"Final price is: {finalPrice}");
                    Console.WriteLine("Thank you for shopping");
                    return true;                    
                }                            
                return false;

        }

        public static void PressEnterToContinue()
        {
            Console.WriteLine("Press enter to continue");
            Console.ReadKey();
        }

        public static double CheckForCorrectValue(string enterValue)
        {
            double result = 0;

            while (true)
            {
                Console.WriteLine(enterValue);
                string value = Console.ReadLine();

                try
                {
                    result = int.Parse(value);
                    break;
                }
                catch 
                {

                    Console.WriteLine("Wrong input, enter a numeric value"); ;
                }

            }
            return result;

        }

        public static int ValueCheckInt(string enterValue)
        {
            return (int)CheckForCorrectValue(enterValue);
        }

    }
}
