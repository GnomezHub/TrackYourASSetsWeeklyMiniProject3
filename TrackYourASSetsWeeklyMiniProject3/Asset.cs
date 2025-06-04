using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeeklyMiniProject3
{

    //Base class for all assets
    abstract class Asset
    {
        public Price Price { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string ModelName { get; set; }
        public string Office { get; set; }
        public string Brand { get; set; }
        public string AssetType { get; }
        public Asset(Price price, DateTime purchaseDate, string brand, string modelName, string office)
        {
            Price = price;
            PurchaseDate = purchaseDate;
            ModelName = modelName;
            Office = office;
            Brand = brand;
            AssetType = GetType().Name; // Automatically set the asset type based on the derived class name
        }
    }   
}
