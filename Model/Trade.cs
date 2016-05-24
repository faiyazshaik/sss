using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSimpleStocks.Model
{
    public enum TradeType {Buy, Sell }
    public class Trade
    {
        public int Id { get; set; }

        public string StockSymbol { get; set; }


        public DateTime DateTime { get;  set; }

        public int Quantity { get; set; }

        public TradeType Type { get; set; }

        public Double Price { get; set; }

    }
}
