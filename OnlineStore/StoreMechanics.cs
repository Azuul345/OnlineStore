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
    internal static class StoreMechanics
    {
        public static CurrencyHandler.CurrencyValue chosenCurrency = CurrencyHandler.CurrencyValue.SEK;

        private static List<Product> Inventory = new List<Product>()
        {
         new FruitAndVegetable("Apple", 8,"Fruit","Sweden"),
         new FruitAndVegetable("Orange",9,"Fruit", "Spain"),
         new Drink("Coca Cola",20,"Drink","33 cl"),
         new Drink("Fanta", 20, "Drink","33 cl"),
         new Meal("Hot Dog", 15, "Food", "Snack"),
         new Meal("Frozen Pizza", 45,"Food", "Meal")
        };


        public static List<Customer> LoadCustomerFromTextFile(string path)
        {
            const char sep = '|';
            List<Customer> result = new();
            if (!File.Exists(path)) return result; //change made from null to result
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
            using var sw = new StreamWriter(path, append: false) ;

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
        

        private static void ShowCaseInventory()
        {
            
            Console.WriteLine("=== MENU ====");
            foreach(Product product in Inventory)
            {
                Console.WriteLine(product.ProductInfo(chosenCurrency)); 
            }
            Console.WriteLine("");
        }

        //can do better by dividing into category and chose item depending on food, drinks, or fruits
        public static void SelectToCart(List<Product> cart)
        {
            bool selectingItem = true;
            while ( selectingItem)
            {
                Console.Clear();
                ShowCaseInventory();

                for (int i = 0; i < Inventory.Count; i++)
                {
                    Console.WriteLine($"({i + 1}): {Inventory[i].Name}");
                }
                Console.WriteLine($"");

                int product = ValueCheckInt("Select item or Press (0): to exit");
                if (product == 0)
                {
                    Console.WriteLine("Exiting");
                    selectingItem = false;
                }
                else
                {
                    int choice = product - 1;
                    if (choice >= Inventory.Count)
                    {
                        Console.WriteLine("Unavailable item ");
                        PressEnterToContinue();
                    }
                    else
                    {
                        cart.Add(Inventory[choice]);
                        Console.WriteLine($"Added {Inventory[choice].Name} to cart");
                        PressEnterToContinue();
                    }
                }
            }
            
        }


        public static void ChangeCurrency()
        {
            int choice = ValueCheckInt("Would you like to change Currency to: \n(1): US \n(2): EUR \n(3): SEK");
            switch (choice)
            {
                case 1:
                    chosenCurrency = CurrencyHandler.CurrencyValue.USD;
                    break;
                case 2:
                    chosenCurrency = CurrencyHandler.CurrencyValue.EUR;
                    break;
                case 3:
                    chosenCurrency = CurrencyHandler.CurrencyValue.SEK;
                    break;

            }
            Console.WriteLine($"Currency value is now {chosenCurrency}");
        }

        public static double  ShowcaseCart(List<Product> cart)
        {   int totalItems = 0;
            double totalSum = 0;
            if (cart.Count == 0)
            {
                Console.WriteLine("No items in shopping cart yet");
            }
            else
            {
                foreach (Product product in cart)
                {
               
                    Console.WriteLine(product.ProductInfo(chosenCurrency));
                    totalSum += CurrencyHandler.PriceInCurrency(chosenCurrency, product.Price);
                    totalItems++;
                }
            }
            Console.WriteLine($"Total cost: {Math.Round(totalSum,2)} {CurrencyHandler.CurrencySymbol(chosenCurrency)}. Total items: {totalItems}");
            return totalSum;
         
        }

        public static void ResetCart(List<Product> cart)
        {
            cart.Clear();

        }


        public static bool CheckedOut(double finalPrice)
        {
            string currencySymbol = CurrencyHandler.CurrencySymbol(StoreMechanics.chosenCurrency);


            Console.WriteLine($"Final price is: {Math.Round(finalPrice, 2)} {currencySymbol}");
                int choice = StoreMechanics.ValueCheckInt("(1): To check out and pay" +
                                                        "\n(2) to continue shopping");
                if (choice == 1)
                {
                    Console.WriteLine($"Paid {Math.Round(finalPrice, 2)} {currencySymbol}");
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

        public static int ValueCheckInt(string enterValue)
        {
            int result = 0;

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

    }
}
