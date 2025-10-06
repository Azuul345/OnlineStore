using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore
{
    internal class Meal : Product
    {
        public string MealType;

        public override string ProductInfo(CurrencyValue c)
        {
            double price = PriceInCurrency(c, Price);
            string sym = CurrencySymbol(c);
            return $"{Name}. Price: {price} {sym} Type: {Type}";  //Product ID: {ProductID}
        }
    }
}
