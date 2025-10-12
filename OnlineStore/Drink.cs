using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore
{
    internal class Drink : Product
    {
        public string Size { get; private set; }

        public Drink(string name, double price, string type, string size) : base(name, price, type)
        {
            Size = size;
        }

        public override string ProductInfo(CurrencyHandler.CurrencyValue c)
        {
            double price = CurrencyHandler.PriceInCurrency(c, Price);
            string sym = CurrencyHandler.CurrencySymbol(c);
            return $"{Name}. {Size} Price: {price} {sym} Type: {Type} "; 
        }
    }
}
