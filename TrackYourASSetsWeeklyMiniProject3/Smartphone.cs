using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeeklyMiniProject3;

namespace WeeklyMiniProject3
{
    //child class for smartphones
    class Smartphone : Asset
    {
        public Smartphone(Price price, DateTime purchaseDate, string brand, string modelName, string office)
            : base(price, purchaseDate, brand, modelName, office)
        {
        }
    }
}
