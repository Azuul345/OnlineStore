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


        public static List<Customer> LoadCustomerFromTextFile(string path)
        {
            const char sep = '|';
            List<Customer> result = new();
            if (!File.Exists(path)) return null;
            using StreamReader sr = new StreamReader(path);


            string line;
            while ((line = sr.ReadLine()) != null)
            {
                if (line.Length == 0 || line[0] == '#') continue;

                string[] part = line.Split(sep);
                if(part.Length < 4) continue;

                string type = part[0];
                if(type == "Customer")
                {
                    string name = part[1];
                    string password = part[2];
                    string memberType = part[3];
                    result.Add(new Customer(name,password,memberType)); 
                }
                if(type == "Member")
                {
                    string name = part[1];
                    string password = part[2];
                    string memberType = part[3];
                    result.Add(new Member(name,password,memberType));
                }
            }
            return result;
        }

        public static void SaveCustomerToTextFile(List<Customer> customer, string path)
        {
            const char sep = '|';
            using var sw = new StreamWriter(path, append: false);

            for (int i = 0;  i < customer.Count; i++)
            {
                var cClass = customer[i];

                if (cClass is Customer c)
                {
                    sw.WriteLine($"Customer{sep}{c.Name}{sep}{c.Password}{sep}{c.MemberType}");
                }
                if(cClass is Member m)
                {
                    sw.WriteLine($"Member{sep}{m.Name}{sep}{m.Password}{sep}{m.MemberType}");
                }


            }
        }
        

        public static void ShowCaseInventory()
        {
            Console.WriteLine("=== MENU ====");
            foreach(Product product in Inventory)
            {
                Console.WriteLine(product.ProductInfo(chosenCurrency)); //doublecheck
            }
        } 

        //can do better, use a loop with index to scal products
        public static void SelectToCart(List<Product> cart)
        {
            int product = StoreMechanics.ValueCheckInt("" +
                "\nWhat would you like? " +
                "\n(1): Apple " +
                "\n(2): Coca Cola" +
                "\n(3): HotDog" +
                "\n(4): exit");

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
                case 4:
                    break;
            }
        }


        public static void ChangeCurrency()
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
                Console.WriteLine(product.ProductInfo(chosenCurrency));//doublecheck || product.Currency
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
            string currencySymbol = Product.CurrencySymbol(StoreMechanics.chosenCurrency);


            Console.WriteLine($"Final price is: {finalPrice} {currencySymbol}");
                int choice = StoreMechanics.ValueCheckInt("(1): To check out and pay" +
                                                        "\n(2) to continue shopping");
                if (choice == 1)
                {
                    Console.WriteLine($"Final price is: {finalPrice} {currencySymbol}");
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
