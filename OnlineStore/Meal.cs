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

        public override string ProductInfo()
        {
            return $"{Name} - Price: {Price} Meal type: {MealType} Type: {Type} "; //Product ID: {ProductID}
        }
    }
}
