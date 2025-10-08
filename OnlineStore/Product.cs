using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore
{
    public abstract class Product
    {
        
        public static int TotalCount = 0;
        public static int nextProductID = 1;


        private string _name;
        private int _price;
        private int _productID;
        private string _type;

        public string Name { get; set; }
        public double Price { get;  set; }
        public int ProductID { get;  private set; }
        public string Type { get;  set; }

        public enum CurrencyValue {SEK, USD, EUR }
        public CurrencyValue Currency { get; private set; }

        public Product()
        {
            ProductID = nextProductID;
            nextProductID++;
            TotalCount++;
        }

        public static double ConvertFromSek(CurrencyValue c)
        {
            if (c == CurrencyValue.USD)
            {
                return 0.09;
            }
            if(c == CurrencyValue.EUR)
            {
                return 0.085;
            }
            return 1;
        }

        public static string CurrencySymbol(CurrencyValue c)
        {
            if(c == CurrencyValue.USD)
            {
                return "$";
            }
            if (c == CurrencyValue.EUR)
            {
                return "€";
            }
            return "kr";
        }

        public static double PriceInCurrency(CurrencyValue c, double price)
        {
            double rate = ConvertFromSek(c);
            return Math.Round(price * rate, 2);
        }


        
        public virtual string ProductInfo(CurrencyValue c)
        {
            double price = PriceInCurrency(c, Price);
            string sym = CurrencySymbol(c);
            return $"\n{Name}. \nPrice: {price}{sym} \nType: {Type} \nID: {ProductID}";
        }


        

        

        



    }
}
