using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSimpleStocks.Model
{
    public enum stockType { Common, Preferred };
    public class Stock
    {
        public string StockSymbol { get; set; }
        public stockType Type { get; set; }

        public int LastDividend { get; set; }

        public int? FixedDividend { get; set; }

        public int ParValue { get; set; }

    }

}
