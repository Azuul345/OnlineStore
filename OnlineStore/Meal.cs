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
        public string MealType { get; private set; }

        public Meal(string name, double price, string type, string mealType) : base(name, price, type)
        {
            MealType = mealType;
        }

        public override string ProductInfo(CurrencyHandler.CurrencyValue c)
        {
            double price = CurrencyHandler.PriceInCurrency(c, Price);
            string sym = CurrencyHandler.CurrencySymbol(c);
            return $"{Name}. Price: {price} {sym}. Meal-type: {MealType} Type: {Type}";  //Product ID: {ProductID}
        }

    }
}
