using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSimpleStocks.Model
{
    public class Repository
    {
        

        List<Stock> stocks = new List<Stock>();
        List<TickerPrice> tickerPrices = new List<TickerPrice>();
        List<Trade> trades = new List<Trade>();
        public Repository()
        {
            // Sample Stock data
            stocks.Add(new Stock {StockSymbol="TEA", Type= stockType.Common, LastDividend = 0, FixedDividend=null, ParValue=100 });
            stocks.Add(new Stock { StockSymbol = "POP", Type = stockType.Common, LastDividend = 8, FixedDividend = null, ParValue = 100 });
            stocks.Add(new Stock { StockSymbol = "ALE", Type = stockType.Common, LastDividend = 23, FixedDividend = null, ParValue = 60 });
            stocks.Add(new Stock { StockSymbol = "GIN", Type = stockType.Preferred, LastDividend = 8, FixedDividend = 2, ParValue = 100 });
            stocks.Add(new Stock { StockSymbol = "JOE", Type = stockType.Common, LastDividend = 13, FixedDividend = null, ParValue = 250 });

            // Sample TicketPrices data
            tickerPrices.Add(new TickerPrice { StockSymbol ="TEA", Current = 50 });
            tickerPrices.Add(new TickerPrice { StockSymbol = "POP", Current = 75 });
            tickerPrices.Add(new TickerPrice { StockSymbol = "ALE", Current = 25 });
            tickerPrices.Add(new TickerPrice { StockSymbol = "GIN", Current = 30 });
            tickerPrices.Add(new TickerPrice { StockSymbol = "JOE", Current = 10 });

            // Sample Trades data
            trades.Add(new Trade { Id=1, Type=TradeType.Buy, StockSymbol = "TEA", Quantity = 10, Price=250.60, DateTime =  new DateTime(2016, 5, 24, 13, 25, 0) });
            trades.Add(new Trade { Id = 1, Type = TradeType.Buy, StockSymbol = "POP", Quantity = 20, Price = 150, DateTime = new DateTime(2016, 5, 24, 13, 26, 0) });
            trades.Add(new Trade { Id = 1, Type = TradeType.Buy, StockSymbol = "GIN", Quantity = 30, Price = 450, DateTime = new DateTime(2016, 5, 24, 13, 27, 0) });
            trades.Add(new Trade { Id = 1, Type = TradeType.Buy, StockSymbol = "JOE", Quantity = 40, Price = 350, DateTime = new DateTime(2016, 5, 24, 13, 28, 0) });
        }


        public  int? GetDiviDendYield(string StockSymbol)
        {
            Stock stock = stocks.Find(s => s.StockSymbol == StockSymbol);
            int tickerPrice = tickerPrices.Find(tp => tp.StockSymbol == StockSymbol).Current;

            stockType stockType = stock.Type;
            
            if (stock.Type == stockType.Common)
            {
                if (stock.LastDividend  == 0)
                {
                    return 0;
                }
                else
                {
                    return stock.LastDividend / tickerPrice;
                }

            }
            else if (stock.Type == stockType.Preferred)
            {
                return (stock.FixedDividend * stock.ParValue) / tickerPrice;
            }
            else
            {
                return null;
            }
        }

        public int GetPERatio(string StockSymbol)
        {
            Stock stock = stocks.Find(s => s.StockSymbol == StockSymbol);
            int tickerPrice = tickerPrices.Find(tp => tp.StockSymbol == StockSymbol).Current;

            stockType stockType = stock.Type;

            return tickerPrice / stock.LastDividend;

        }


        public int AddNewTrade( Trade trade)
        {
            this.trades.Add(trade);

            //return new trade id of the trade created
            return trade.Id;

        }

        public double GetStockPrice(string StockSymbol)
        {
            var tradesInLast15mins =  trades.FindAll(t => t.StockSymbol == StockSymbol && t.DateTime == DateTime.Now + new TimeSpan(0, 15, 0));

            if (tradesInLast15mins != null)
            {

                var totalQuantity = tradesInLast15mins.Sum(t => t.Quantity);

                var totalTradePrice = tradesInLast15mins.Sum(t => t.Price);

                if (totalQuantity != 0)
                {

                    return (totalTradePrice * totalQuantity) / totalQuantity; 
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }

        }

        public double GetGBCEAllShareIndex()
        {
            List<double> GMPAllStock = new List<double>();

            foreach(Stock stock  in stocks)
            {

                var tradesOfStock = trades.FindAll(tt => tt.StockSymbol == stock.StockSymbol && tt.DateTime == DateTime.Now + new TimeSpan(0, 15, 0));

                var gmp = 50; // calculate gmp for each stock.
                              
                GMPAllStock.Add(gmp);
            }

            double t = 1;
            foreach (int g in GMPAllStock)
            {
                t = t * g;
            }

           
            return Math.Pow(t, 1 / GMPAllStock.Count);


        }
             


    }
}
