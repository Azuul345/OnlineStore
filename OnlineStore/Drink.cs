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

        

        public override string ProductInfo()
        {
            return $"{Name} -  Price: {Price} Size: {Size} Type: {Type}  "; //Product ID: {ProductID}
        }
    }
}
