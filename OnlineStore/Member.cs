using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore
{
    internal class Member : Customer
    {
        
        public string MemberType { get; private set; }
        //public int procentDiscount;


        public Member(string name, string password, string membertype) : base(name, password, membertype)
        {
            MemberType = membertype;

        }



        public static Member ConvertToMember(Customer c, List<Product> p)
        {
            if (c.MemberType != "Regular")
            {
                Member m = new Member(c.Name, c.Password, c.MemberType);
                m.Cart = p;
                return m;
            }
                    
            return null;
        }

        public static double GetFinalPrice(List<Product> cart, string memberType)
        {
            string currencySymbol = CurrencyHandler.CurrencySymbol(StoreMechanics.chosenCurrency);
            double sum = 0;
            int totalItems = 0;

            foreach (Product product in cart)
            {
                Console.WriteLine($"{product.Name} - Price: {CurrencyHandler.PriceInCurrency(StoreMechanics.chosenCurrency, product.Price)} ");  
                sum += CurrencyHandler.PriceInCurrency(StoreMechanics.chosenCurrency, product.Price); 
                totalItems++;
            }
            Console.WriteLine($"The total purchase cost of {totalItems} items: {Math.Round(sum,2)} {currencySymbol}"); 
            
            double newPrice = sum * (1 - GetMemberDiscount(memberType));

            Console.WriteLine($"With your {memberType} Membership you get a discount of {ConvertDecimaltoString(memberType)} % to {Math.Round(newPrice,2)}" +
                $" {currencySymbol}"); 


            return newPrice;

        }

        private static string ConvertDecimaltoString(string memberLevel)
        {
            string amount;
            switch (memberLevel)
            {
                case "GOLD":
                    return "15";
                    break;
                case "SILVER":
                    return "10";
                    break;
                case "BRONZ":
                    return "5";
                    break;
            }

            return "";
        }



        private static double GetMemberDiscount(string memberType)
        {
            double procentInDiscount = 0;
            switch (memberType)
            {
                case "GOLD":
                    procentInDiscount = 0.15;
                    break;
                case "SILVER":
                    procentInDiscount = 0.1;
                    break;
                case "BRONZ":
                    procentInDiscount = 0.05;
                    break;
                //default:
                //    procentInDiscount = 0;
                //    break;
                    //probably not needed
            }          
            return procentInDiscount;
        }

        

    }
}
