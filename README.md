# TrackYourASSetsWeeklyMiniProject3
This is my take on the third weekly miniproject at my school (Lexicon). 
It is an asset tracking app that lists different assets (computers and smartphones) from different offices and displays them in white, yellow or red depending on how close they are to their end life of 3 years from purchase date.
It fetches the exchange rates live to show the correct value in USD. It allso shows the prices in local office currency.

We where provided with some sample data in this format:
tracker.AddAsset(new Computer(new Price(1300, Currency.EUR), DateTime.Now.AddMonths(-36 + 2), "Asus", "ROG 500", germany));

First I started with making an Asset base Class and Computer & Smartphone deriving from that Asset class. The asset type name was stored in a variable in the base class that got its value using "AssetType = GetType().Name;". That was I didnt have to deal with it from the child classes. Then I made an AssetsManager class that handled the adding of new assets. Ass I wanted to use the sample data as it was, I also made a Currency enum and a Price Class. I put the sorting of assets with linq in the addAsset method, and wrote a printAsset method for the console. Then I moved on to marking the assets red or yellow depending on purchase date.

Now for the trickier part: converting the prices. I struggled a bit trying to understand what I was suppose to show from the description but fortunally I had a sample output image. That and the sample data made me understand that I needed a column to show the price in USD which then resulted in this logic:

*if the currency of the asset is in USD, no conversion is needed

*if the currency is EUR, convert directly to USD

*if the currency is not USD or EUR, convert Euro first then to USD

I found it suitable to place this logic in a get property, PriceInUSD, inside the Price class. That way I could return a formated string so I didnt end up with a bunch of extra decimals.
Also made a property for returning a string with the local price& currency.

Fetching the live data was intressting. Didnt get it to work with the first file I tried involving some envelopes and nested objects. But the other one was pretty straight forward, needed a "CurrencyObj" to be added in a list with the fetched rates &currencies. First I made a class but then I changed it to a struct type because I didnt want to end up with a class on a seperate file only for that simple object. (I know I could have kept the CurrencyObj class inside the LiveCurrency file, but it felt better doing so with a struct type). After I got the logic working I focused on making it visually as the output end ended up with this
![Skärmbild 2025-06-05 123459](https://github.com/user-attachments/assets/4db3fc02-be7b-42c6-a5fc-73a56532e2ab)
I found that paddingRight is needed in the last column when there is a background color set on the console.
I added all the currencys fetched from the ECB XML document to the currency enum and added more offices to test it (australia and india). Lastly I added the option to add more assets, and print them out again after adding.

Thats all for now, happy grading!

/Danny Gomez
