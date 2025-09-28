using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore
{
    internal class Member : Customer
    {
        public  string MemberType;


        public Member(string name, string password, string membertype) : base(name, password, membertype)
        {
            MemberType = membertype;

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
