using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace OnlineStore
{
    internal class Customer
    {
        private static List<Customer> Customers = new List<Customer>()
        {
            new Customer("Knatte", "123", "GOLD" ),
            new Customer("Fnatte", "321", "SILVER"),
            new Customer("Tjatte", "213", "BRONZ")
        };


        private string _name;
        private string _password;
        private string _memberType;
        private List<Product> _cart;

        public string Name { get; private set; }
        public string Password { get; private set; }
        public string MemberType { get; private set; }

        public List<Product> Cart { get; set; }

        public Customer(string name = "nn" ,string password = "", string membertype = "") //
        {
            Name = name;
            Password = password;
            MemberType = membertype;
            Cart = new List<Product>();
        }


        public static Customer LogIn()
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.Write("Enter password: ");
            string passWord = Console.ReadLine();

            foreach (Customer c in Customers)
            {
                if (c.Name == name && c.Password == passWord)
                {
                    return c;
                }
            }
            Console.WriteLine("Unable to log in");
            return null;
        }

        public static Customer RegisterCustumer()
        {
            string memberType;

            Console.Write("What is your name?: ");
            string name = Console.ReadLine();
            Console.Write("Enter a Password: ");
            string password = Console.ReadLine();
            Console.WriteLine("Would you like to join our membership program?");
            Console.WriteLine("(1): Gold - 10 000 kr a year \n(2): Silver - 5 000 kr a year" +
                              "\n(3): Bronze - 1 000 kr a year \n(4): Skip");
            int choice = StoreMechanics.ValueCheckInt("Make Your choice");
            
            switch (choice)
            {
                case 1:
                    memberType = "GOLD";
                    break;
                case 2:
                    memberType = "SILVER";
                    break;
                case 3:
                    memberType = "BRONZ";
                    break;
                default:
                    memberType = "Regular";
                    break;

            }
            Customer c = new Customer(name,password,memberType);
            Customers.Add(c);
            return c;

        }



        public static void ListAllCustumers()
        {
            foreach (Customer c in Customers)
            {
                Console.WriteLine($"{c.Name} Member type: {c.MemberType} " ); //Member type: {c.MemberType}
                foreach (Product p in c.Cart)
                {
                    Console.WriteLine(p.ProductInfo());
                }
            }
        }


    }
}
