using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore
{
    internal class FruitAndVegetable : Product
    {

        public string Country;

        public override string ProductInfo(CurrencyValue c)
        {
            double price = PriceInCurrency(c, Price);
            string sym = CurrencySymbol(c);
            return $"{Name}. Price: {price} {sym} Type: {Type}";  //ProductID: {ProductID}
        }
    }
}
