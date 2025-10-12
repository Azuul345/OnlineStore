using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore
{
    internal class CurrencyHandler
    {

        public CurrencyValue Currency { get; private set; }
        public enum CurrencyValue { SEK, USD, EUR }

        private static double ConvertFromSek(CurrencyValue c)
        {
            if (c == CurrencyValue.USD)
            {
                return 0.09;
            }
            if (c == CurrencyValue.EUR)
            {
                return 0.085;
            }
            return 1;
        }

        
        public static string CurrencySymbol(CurrencyValue c)
        {
            if (c == CurrencyValue.USD)
            {
                return "$";
            }
            else if (c == CurrencyValue.EUR)
            {
                return "€";
            }
            else
            {
                return "kr";
            }
        }

        public static double PriceInCurrency(CurrencyValue c, double price)
        {
            double rate = ConvertFromSek(c);
            return Math.Round(price * rate, 2);
        }

    }
}
