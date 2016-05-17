using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Simple_Stocks
    {
    class Program
        {
        static void Main(string[] args)
            {
            Console.WriteLine("Start Stocks Initialise");
            List<Stock> theStocks = initStocks();
            Console.WriteLine("End Stocks Initialise");

            Console.WriteLine("Start Trades Initialise");
            List<Trade> theTrades = initSomeTrades(theStocks);
            Console.WriteLine("End Trades Initialise");

            Console.WriteLine("TEA: £" + getStockPriceInPounds("TEA", theTrades));
            Console.WriteLine("GEO Mean: " + getGeoMean(theStocks, theTrades));

            Console.WriteLine("Ask for one of the following:");
            Console.WriteLine("TEA,POP,ALE,GIN,JOE");
            var searchName = Console.ReadLine();
            Console.WriteLine(searchName + ": £" + getStockPriceInPounds(searchName, theTrades));
            Console.WriteLine("New GEO Mean: " + getGeoMean(theStocks, theTrades));
            Console.ReadLine();
            }

        public static List<Stock> initStocks()
            {
            List<Stock> tmpStocks = new List<Stock>();
            Stock tempStock = new Stock();
            tempStock.stockSymbol = "TEA";
            tempStock.stockType = "Common";
            tempStock.lastDividend = 0;
            tempStock.fixedDividend = 0;
            tempStock.parValue = 100;
            tempStock.tickerPrice = 10;
            tmpStocks.Add(tempStock);

            tempStock = new Stock();
            tempStock.stockSymbol = "POP";
            tempStock.stockType = "Common";
            tempStock.lastDividend = 8;
            tempStock.fixedDividend = 0;
            tempStock.parValue = 100;
            tempStock.tickerPrice = 10;
            tmpStocks.Add(tempStock);

            tempStock = new Stock();
            tempStock.stockSymbol = "ALE";
            tempStock.stockType = "Common";
            tempStock.lastDividend = 23;
            tempStock.fixedDividend = 0;
            tempStock.parValue = 60;
            tempStock.tickerPrice = 10;
            tmpStocks.Add(tempStock);

            tempStock = new Stock();
            tempStock.stockSymbol = "GIN";
            tempStock.stockType = "Preferred";
            tempStock.lastDividend = 0;
            tempStock.fixedDividend = 2;
            tempStock.parValue = 100;
            tempStock.tickerPrice = 10;
            tmpStocks.Add(tempStock);

            tempStock = new Stock();
            tempStock.stockSymbol = "JOE";
            tempStock.stockType = "Common";
            tempStock.lastDividend = 0;
            tempStock.fixedDividend = 0;
            tempStock.parValue = 250;
            tempStock.tickerPrice = 10;
            tmpStocks.Add(tempStock);

            return tmpStocks;
            }

        public static List<Trade> initSomeTrades(List<Stock> theStocks)
            {
            List<Trade> theTrades = new List<Trade>();
            Console.WriteLine("Record Trade for TEA Buy 10 at 100");
            theTrades.Add(Trade.performTrade(theStocks.Where(s => s.stockSymbol == "TEA").FirstOrDefault(), 10, true, 100));

            Console.WriteLine("Record Trade for TEA Buy 10 at 150");
            theTrades.Add(Trade.performTrade(theStocks.Where(s => s.stockSymbol == "TEA").FirstOrDefault(), 10, true, 150));

            Console.WriteLine("Record Trade for TEA Buy 20 at 100");
            theTrades.Add(Trade.performTrade(theStocks.Where(s => s.stockSymbol == "TEA").FirstOrDefault(), 20, true, 200));

            Console.WriteLine("Record Trade for TEA Buy 10 at 50");
            theTrades.Add(Trade.performTrade(theStocks.Where(s => s.stockSymbol == "TEA").FirstOrDefault(), 10, true, 50));

            Console.WriteLine("Record Trade for TEA Buy 30 at 20");
            theTrades.Add(Trade.performTrade(theStocks.Where(s => s.stockSymbol == "TEA").FirstOrDefault(), 30, true, 20));

            Console.WriteLine("Record Trade for TEA Buy 10 at 10");
            theTrades.Add(Trade.performTrade(theStocks.Where(s => s.stockSymbol == "TEA").FirstOrDefault(), 10, true, 10));

            Console.WriteLine("Record Trade for TEA Buy 10 at 20");
            theTrades.Add(Trade.performTrade(theStocks.Where(s => s.stockSymbol == "TEA").FirstOrDefault(), 10, true, 20));

            Console.WriteLine("Record Trade for POP Buy 10 at 20");
            theTrades.Add(Trade.performTrade(theStocks.Where(s => s.stockSymbol == "POP").FirstOrDefault(), 10, true, 20));

            Console.WriteLine("Record Trade for TEA Buy 10 at 100");
            theTrades.Add(Trade.performTrade(theStocks.Where(s => s.stockSymbol == "TEA").FirstOrDefault(), 10, true, 100));

            Console.WriteLine("Record Trade for GIN Buy 10 at 20");
            theTrades.Add(Trade.performTrade(theStocks.Where(s => s.stockSymbol == "GIN").FirstOrDefault(), 10, true, 20));

            Console.WriteLine("Record Trade for GIN Buy 10 at 30");
            theTrades.Add(Trade.performTrade(theStocks.Where(s => s.stockSymbol == "GIN").FirstOrDefault(), 10, true, 30));

            Console.WriteLine("Record Trade for TEA Buy 10 at 100");
            theTrades.Add(Trade.performTrade(theStocks.Where(s => s.stockSymbol == "TEA").FirstOrDefault(), 10, true, 10));

            Console.WriteLine("Record Trade for TEA Buy 10 at 111");
            theTrades.Add(Trade.performTrade(theStocks.Where(s => s.stockSymbol == "TEA").FirstOrDefault(), 10, true, 111));

            Console.WriteLine("Record Trade for TEA Buy 10 at 111");
            theTrades.Add(Trade.performTrade(theStocks.Where(s => s.stockSymbol == "TEA").FirstOrDefault(), 10, true, 111));

            return theTrades;
            }

        public static double getStockPriceInPounds(string stockSymbol, List<Trade> Trades)
            {
            double value = 0;
            List<Trade> releventTrades = Trades.Where(t => t.stock.stockSymbol == stockSymbol && t.timestamp > DateTime.UtcNow.AddMinutes(-15)).ToList();
            if (releventTrades.Count() > 0)
                {
                foreach (var trade in releventTrades)
                    {
                    value += trade.price * trade.NoShares;
                    }

                return (value / releventTrades.Count()) / 100;
                }
            else
                {
                return 0;
                }
            }

        public static double getGeoMean(List<Stock> theStocks, List<Trade> Trades)
            {
            double result = 1;
            int count = 0;
            foreach (var stock in theStocks)
                {
                var price = getStockPriceInPounds(stock.stockSymbol, Trades);
                if (price != 0)
                    {
                    result = result * price;
                    count++;
                    }
                }
            result = Math.Pow(result, 1.0 / count);
            return result;
            }

        }
    }
