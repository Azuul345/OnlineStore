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

        public override string ProductInfo()
        {
            return $"{Name} - Price: {Price} Orgin: {Country} Type: {Type} "; //ProductID: {ProductID}
        }
    }
}
