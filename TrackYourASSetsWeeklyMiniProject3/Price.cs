using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeeklyMiniProject3;

namespace WeeklyMiniProject3
{

    class Price
    {
        public Price(double value, Currency currency)
        {
            Value = value;
            LocalCurrency = currency.ToString();// Convert the Currency enum to string for easier handling
        }

        //double Convert(double input, string fromCurrency, string toCurrency) // Method in LiveCurrency that uses the fetched rates to convert between the given rates via Euro

        private double Value; // The value of the asset in the local currency
      
        private string LocalCurrency; // The local currency of the asset, e.g. USD, EUR, SEK
        public string WithCurrancy => LocalCurrency + " " + Value.ToString("#.##");
        public string PriceInUSD
        { // converts the price to USD and returns it as a string with two decimal places
            get
            {
                double valueInUSD;
                if (LocalCurrency == "USD")
                {
                    valueInUSD = Value; // If the currency is already USD, no conversion is needed
                }
                else if (LocalCurrency == "EUR")
                {
                    // If the currency is EUR, convert directly to USD
                    valueInUSD = LiveCurrency.Convert(Value, "EUR", "USD");
                }
                else // If the currency is not USD or EUR, convert Euro first then to USD
                {
                    double valueInEuro = LiveCurrency.Convert(Value, LocalCurrency, "EUR");
                    valueInUSD = LiveCurrency.Convert(valueInEuro, "EUR", "USD");
                }
                return valueInUSD.ToString("#.##");
            }
        }


    }

}
