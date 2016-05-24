using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperSimpleStocks.Model;

namespace SuperSimpleStocks
{
    class Program
    {
        static void Main(string[] args)
        {
            Repository superSimpleStocks = new Repository();

            // 1 a. i.	calculate the dividend yield for a given stock
            superSimpleStocks.GetDiviDendYield("TEA");
            superSimpleStocks.GetDiviDendYield("POP");
            superSimpleStocks.GetDiviDendYield("ALE");
            superSimpleStocks.GetDiviDendYield("GIN");
            superSimpleStocks.GetDiviDendYield("JOE");


            // 1 a. ii.	calculate the dividend yield for a given stock
            superSimpleStocks.GetPERatio("TEA");
            superSimpleStocks.GetPERatio("POP");
            superSimpleStocks.GetPERatio("ALE");
            superSimpleStocks.GetPERatio("GIN");
            superSimpleStocks.GetPERatio("JOE");

            // 1 a. iii.	record a trade, with timestamp, quantity of shares, buy or sell indicator and price - Buy
            superSimpleStocks.AddNewTrade(new Trade { StockSymbol="TEA", Quantity = 100, Type = TradeType.Buy, Price = 1500.70 , DateTime = System.DateTime.Now});

            // 1 a. iii.	record a trade, with timestamp, quantity of shares, buy or sell indicator and price - Sell
            superSimpleStocks.AddNewTrade(new Trade { StockSymbol = "ALE", Quantity = 50, Type = TradeType.Sell, Price = 100 , DateTime = System.DateTime.Now });

            // 1 a. iv.	Calculate Stock Price based on trades recorded in past 15 minutes
            superSimpleStocks.GetStockPrice("TEA");

            // 1 b.	Calculate the GBCE All Share Index using the geometric mean of prices for all stocks
            superSimpleStocks.GetGBCEAllShareIndex();
        }
    }
}
