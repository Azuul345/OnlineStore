using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore
{
    abstract class Product
    { 
        public static int TotalCount = 0;
        public static int nextProductID = 1;


        public string Name { get; set; }
        public double Price { get;  set; }
        public int ProductID { get;  private set; }
        public string Type { get;  set; }

        

        public Product(string name, double price, string type)
        {
            Name = name;
            Price = price;
            Type = type;

            ProductID = nextProductID;
            nextProductID++;
            TotalCount++;
        }


        public abstract string ProductInfo(CurrencyHandler.CurrencyValue c);
        
        //public virtual string ProductInfo(CurrencyHandler.CurrencyValue c)
        //{
        //    double price = CurrencyHandler.PriceInCurrency(c, Price);
        //    string sym = CurrencyHandler.CurrencySymbol(c);
        //    return $"\n{Name}. \nPrice: {price}{sym} \nType: {Type} \nID: {ProductID}";
        //}

    }
}
