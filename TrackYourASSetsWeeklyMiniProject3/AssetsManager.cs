using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeeklyMiniProject3;

namespace WeeklyMiniProject3
{
    class AssetsManager
    {
        private List<Asset> assets = new List<Asset>();

        public void AddAsset(Asset asset)
        {
            assets.Add(asset);
            //    assets = assets.OrderBy(a => a.AssetType).ToList();
            assets = assets.OrderBy(a => a.Office).ThenByDescending(d => d.PurchaseDate).ToList(); // Sort assets by office and then by purchase date in descending order
        }

        public void PrintAssets()
        {
            int padding = 15; // Padding for each column
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Blue;
            //column headers
            Console.WriteLine("Office".PadRight(padding) + "Asset".PadRight(padding) + "Brand".PadRight(padding)
                + "Model".PadRight(padding) + "Price (USD)".PadRight(padding) + "Price (Local)".PadRight(padding) + "Purchase Date".PadRight(padding));

            foreach (var asset in assets)
            {
                Console.ResetColor();
                Console.BackgroundColor = ConsoleColor.DarkGray;
                // If the asset was purchased more than 3.5 years ago, the color is red
                if (asset.PurchaseDate <= DateTime.Now.AddYears(-3).AddMonths(+3))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                // If the asset was purchased between 3 and 3.5 years ago, the color is yellow
                else if (asset.PurchaseDate <= DateTime.Now.AddYears(-3).AddMonths(+6))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.WriteLine(asset.Office.PadRight(padding) + asset.AssetType.PadRight(padding) + asset.Brand.PadRight(padding)
                    + asset.ModelName.PadRight(padding) + asset.Price.PriceInUSD.PadRight(padding) + asset.Price.WithCurrancy.PadRight(padding)
                    + asset.PurchaseDate.ToShortDateString().PadRight(padding));
            }
            Console.ResetColor();
        }
    }
}
