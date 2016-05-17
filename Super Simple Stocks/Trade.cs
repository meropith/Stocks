using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Simple_Stocks
    {
    public class Trade
        {
        public DateTime timestamp { get; set; }
        public bool Bought { get; set; }
        public Stock stock { get; set; }
        public int NoShares { get; set; }

        public double price { get; set; }
        public static Trade performTrade(Stock stock, int howMany, bool buy,double price)
            {
            Trade tmpTrade = new Trade();
            tmpTrade.timestamp = DateTime.UtcNow;
            tmpTrade.Bought = buy;
            tmpTrade.stock = stock;
            tmpTrade.NoShares = howMany;
            tmpTrade.price = price;
            return tmpTrade;
            }


        }


    }
