using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore
{
    internal class FruitAndVegetable : Product
    {

        public string Country {  get; private set; }

        public FruitAndVegetable(string name, double price, string type, string country) : base(name, price, type)
        {
            Country = country;
        }


        public override string ProductInfo(CurrencyHandler.CurrencyValue c)
        {
            double price = CurrencyHandler.PriceInCurrency(c, Price);
            string sym = CurrencyHandler.CurrencySymbol(c);
            return $"{Name}. Price: {price} {sym}. Origin: {Country} Type: {Type}";  //ProductID: {ProductID}
        }
    }
}
