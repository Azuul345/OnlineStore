using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore
{
    public class Drink : Product
    {
        public string Size;

        

        public override string ProductInfo(CurrencyValue c)
        {
            double price = PriceInCurrency(c, Price);
            string sym = CurrencySymbol(c);
            return $"{Name}. Price: {price} {sym} Type: {Type} "; //Product ID: {ProductID}
        }
    }
}
