using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore
{
    public abstract class Product
    {
        //public static double GlobalDiscount = 0.0;
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

        public Product()
        {
            ProductID = nextProductID;
            nextProductID++;
            TotalCount++;
        }

        public virtual string ProductInfo()
        {
            return $"{Name}. \nPrice: {Price} \nType: {Type} ID: {ProductID}";
        }


        

        //public virtual double FinalPrice()
        //{
        //    double discountFactor = 1 - GlobalDiscount;
        //    return Price * discountFactor;
        //}

        



    }
}
