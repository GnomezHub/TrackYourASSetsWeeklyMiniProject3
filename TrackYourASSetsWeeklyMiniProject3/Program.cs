/*
 *  # Asset Tracking 
This project is the start of an Asset Tracking database. It should have input possibilities from a user and print out 
functionality of user data.
 Asset Tracking is a way to keep track of the company assets, like Laptops, Stationary computers, Phones and so 
on... 
All assets have an end of life which for simplicity reasons is 3 years. 
Level 1 
Create a console app that have classes and objects. For example like below with computers and phones.
 Laptop Computers - MacBook- Asus- Lenovo
 Mobile Phones - Iphone- Samsung- Nokia
 You will need to create the appropriate properties and constructors for each object, like purchase date, price, 
model name etc. 

 * */
using WeeklyMiniProject3;


LiveCurrency.FetchRates();

// Office locations.
string usa = "Los Angeles";
string sweden = "Malmö";
string germany = "Berlin";
string australia = "Sydney";
string india = "Mumbai";

AssetsManager tracker = new AssetsManager();

// Adding assets to the AssetsManager (tracker)
tracker.AddAsset(new Computer(new Price(300, Currency.AUD), DateTime.Now.AddMonths(-36), "Asus", "ROG 560", australia));
tracker.AddAsset(new Computer(new Price(250, Currency.AUD), DateTime.Now.AddMonths(-36 + 9), "Asus", "ROG 500", australia));
tracker.AddAsset(new Computer(new Price(3400000, Currency.IDR), DateTime.Now.AddMonths(-36 + 5), "Lenovo", "Thinkpad", india));
tracker.AddAsset(new Smartphone(new Price(200, Currency.USD), DateTime.Now.AddMonths(-36 + 4), "Motorola", "X3", usa));
tracker.AddAsset(new Smartphone(new Price(400, Currency.USD), DateTime.Now.AddMonths(-36 + 5), "Motorola", "X3", usa));
tracker.AddAsset(new Smartphone(new Price(400, Currency.USD), DateTime.Now.AddMonths(-36 + 10), "Motorola", "X2", usa));
tracker.AddAsset(new Smartphone(new Price(4500, Currency.SEK), DateTime.Now.AddMonths(-36 + 6), "Samsung", "Galaxy 10", sweden));
tracker.AddAsset(new Smartphone(new Price(4500, Currency.SEK), DateTime.Now.AddMonths(-36 + 7), "Samsung", "Galaxy 10", sweden));
tracker.AddAsset(new Smartphone(new Price(3000, Currency.SEK), DateTime.Now.AddMonths(-36 + 4), "Sony", "XPeria 7", sweden));
tracker.AddAsset(new Smartphone(new Price(3000, Currency.SEK), DateTime.Now.AddMonths(-36 + 5), "Sony", "XPeria 7", sweden));
tracker.AddAsset(new Smartphone(new Price(220, Currency.EUR), DateTime.Now.AddMonths(-36 + 12), "Siemens", "Brick", germany));
tracker.AddAsset(new Computer(new Price(100, Currency.USD), DateTime.Now.AddMonths(-38), "Dell", "Desktop 900", usa));
tracker.AddAsset(new Computer(new Price(100, Currency.USD), DateTime.Now.AddMonths(-37), "Dell", "Desktop 900", usa));
tracker.AddAsset(new Computer(new Price(300, Currency.USD), DateTime.Now.AddMonths(-36 + 1), "Lenovo", "X100", usa));
tracker.AddAsset(new Computer(new Price(300, Currency.USD), DateTime.Now.AddMonths(-36 + 4), "Lenovo", "X200", usa));
tracker.AddAsset(new Computer(new Price(500, Currency.USD), DateTime.Now.AddMonths(-36 + 9), "Lenovo", "X300", usa));
tracker.AddAsset(new Computer(new Price(1500, Currency.SEK), DateTime.Now.AddMonths(-36 + 7), "Dell", "Optiplex 100", sweden));
tracker.AddAsset(new Computer(new Price(1400, Currency.SEK), DateTime.Now.AddMonths(-36 + 8), "Dell", "Optiplex 200", sweden));
tracker.AddAsset(new Computer(new Price(1300, Currency.SEK), DateTime.Now.AddMonths(-36 + 9), "Dell", "Optiplex 300", sweden));
tracker.AddAsset(new Computer(new Price(1600, Currency.EUR), DateTime.Now.AddMonths(-36 + 14), "Asus", "ROG 600", germany));
tracker.AddAsset(new Computer(new Price(1200, Currency.EUR), DateTime.Now.AddMonths(-36 + 4), "Asus", "ROG 500", germany));
tracker.AddAsset(new Computer(new Price(1200, Currency.EUR), DateTime.Now.AddMonths(-36 + 3), "Asus", "ROG 500", germany));
tracker.AddAsset(new Computer(new Price(1300, Currency.EUR), DateTime.Now.AddMonths(-36 + 2), "Asus", "ROG 500", germany));




// Option to add more assets from the console
while (true)
{
    // Print all assets
    tracker.PrintAssets();
    Console.WriteLine("\nDo you want to add a new asset? (y/n): ");
    var input = Console.ReadLine();
    if (input == null || input.Trim().ToLower() != "y")
        break;

    Console.WriteLine("Enter asset type (Smartphone/Computer): ");
    string assetType = Console.ReadLine();

    Console.WriteLine("Enter brand: ");
    string brand = Console.ReadLine();

    Console.WriteLine("Enter model name: ");
    string model = Console.ReadLine();

    Console.WriteLine("Enter office location: ");
    string office = Console.ReadLine();

    Console.WriteLine("Enter purchase date (yyyy-MM-dd): ");
    DateTime purchaseDate;
    while (!DateTime.TryParse(Console.ReadLine(), out purchaseDate))
    {
        Console.WriteLine("Invalid date. Please enter again (yyyy-MM-dd): ");
    }

    Console.WriteLine("Enter price value: ");
    double priceValue;
    while (!double.TryParse(Console.ReadLine(), out priceValue))
    {
        Console.WriteLine("Invalid value. Please enter a number: ");
    }

    // Show available currencies from the enum
    Console.WriteLine("Available currencies:");
    foreach (var c in Enum.GetNames(typeof(Currency)))
    {
        Console.Write(c + " ");
    }
    Console.WriteLine();

    Console.WriteLine("Enter currency (as shown above): ");
    string currencyStr = Console.ReadLine();
    Currency currency;
    while (!Enum.TryParse(currencyStr.ToUpper(), true, out currency))
    {
        Console.WriteLine("Invalid currency. Please enter one of the available options: ");
        currencyStr = Console.ReadLine();
    }

    Price price = new Price(priceValue, currency);

    if (assetType.Trim().ToLower() == "smartphone")
    {
        tracker.AddAsset(new Smartphone(price, purchaseDate, brand, model, office));
    }
    else if (assetType.Trim().ToLower() == "computer")
    {
        tracker.AddAsset(new Computer(price, purchaseDate, brand, model, office));
    }
    else
    {
        Console.WriteLine("Unknown asset type. Skipping.");
        continue;
    }

    Console.WriteLine("Asset added!\n");
}



// Enum for currencies, fetched from the ECB XML document
public enum Currency
{
    USD,
    EUR,
    SEK,
    JPY,
    BGN,
    CZK,
    DKK,
    GBP,
    HUF,
    PLN,
    RON,
    CHF,
    ISK,
    NOK,
    HRK,
    RUB,
    TRY,
    AUD,
    BRL,
    CAD,
    CNY,
    HKD,
    IDR,
    ILS,
    INR,
    KRW,
    MXN,
    MYR,
    NZD,
    PHP,
    SGD,
    THB,
    ZAR
}