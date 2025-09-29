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
                Console.WriteLine(product.ProductInfo());
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

        public static double  ShowcaseCart(List<Product> cart)
        {   int totalItems = 0;
            double totalSum = 0;
            foreach(Product product in cart)
            {
                Console.WriteLine(product.ProductInfo());
                totalSum += product.Price;
                totalItems++;
            }
            Console.WriteLine($"Total sum: {totalSum} kr. Total items: {totalItems}");
            return totalSum;
         
        }

        //public static void ResetCart(List<Product> cart)
        //{
        //    foreach (Product p in cart)
        //    {
        //        cart.Clear();
        //    }

        //}



        //public static void CheckOut(Customer c, List<Product> cart)
        //{

        //    double discountValue = Member.GetMemberDiscount(c.MemberType);
        //    List<string> seen = [];
        //    Console.WriteLine("=== Check out ===");
        //    for (int i = 0; i < cart.Count; i++)
        //    {
        //        string currentItem = cart[i].Name; //not sure
        //        if (seen.Contains(currentItem))
        //        {
        //            continue;
        //        }
        //        int count = 1;

        //        for(int j = (i + 1);j < cart.Count; j++)
        //        {
        //            if(cart[j].Name == currentItem)
        //            {
        //                count++;
        //            }
        //        }
        //        Console.WriteLine($"{count}x - {currentItem} ");
        //        seen.Add(currentItem);
        //    }


        //Console.WriteLine($"Discount applied {discountValue}");
        //}

        //CYC4D53MM7Y34Y



        //public static void EnterShop(Customer c)
        //{
        //bool inStore = true;

        //while (inStore)
        //{
        //    Console.Clear();

        //    int storeChoice = StoreMechanics.ValueCheckInt("What would you like to do? " +
        //        "\n(1): Shop item " +
        //        "\n(2): Show Shopping Cart Item Details " +
        //        "\n(3): Check Out " +
        //        "\n(4)Admin: see all cusomer info");

        //    switch (storeChoice)
        //    {
        //        case 1:

        //            StoreMechanics.ShowCaseInventory();
        //            StoreMechanics.SelectToCart(c.Cart);

        //            break;
        //        case 2:

        //            StoreMechanics.ShowcaseCart(c.Cart);
        //            break;

        //        case 3:
        //            Member m = Member.ConvertToMember(c, c.Cart);
        //            if (c.MemberType != "Regular")
        //            {
        //                double finalPrice = Member.GetFinalPrice(m.Cart);
        //                CheckOut(finalPrice);
        //            }
        //            else
        //            {
        //                double finalPrice = StoreMechanics.ShowcaseCart(c.Cart);
        //                CheckOut(finalPrice);                            
        //            }              
        //            break;
        //        case 4:
        //            Customer.ListAllCustumers();
        //            break;


        //    }
        //    Console.ReadKey();



        //}
        //}

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
