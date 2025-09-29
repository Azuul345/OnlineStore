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
        public static string MemberType;
        public int procentDiscount;


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

        public static double GetFinalPrice(List<Product> cart)
        {
            double sum = 0;
            int totalItems = 0;

            foreach (Product product in cart)
            {
                Console.WriteLine($"{product.Name} Price:{product.Price} ");
                sum += product.Price;
                totalItems++;
            }
            Console.WriteLine($"The total purchase sum of {totalItems} items: {sum} kr");
            
            double newPrice = sum * (1 - GetMemberDiscount(MemberType));
                       
            Console.WriteLine($"With your {MemberType} Membership you get a discount of {GetMemberDiscount(MemberType)} price to {newPrice}");
            
            return newPrice;

        }




        public static double GetMemberDiscount(string memberType)
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
                    procentInDiscount = 0.5;
                    break;
                default:
                    procentInDiscount = 0;
                    break;

            }          
            return procentInDiscount;
        }

    }
}
