using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Super_Simple_Stocks
    {
    public class Stock
        {
        public string stockSymbol { get; set; }
        public string stockType { get; set; }
        public int lastDividend { get; set; }

        public double fixedDividend { get; set; }
        public int parValue { get; set; }

        public double tickerPrice { get; set; }

        public double getDividendYield()
            {
            if (this.tickerPrice != 0)
                {
                if (this.stockType == "Common")
                    {
                    return this.lastDividend / this.tickerPrice;
                    }
                else if (this.stockType == "Preferred" && this.fixedDividend != 0)
                    {
                    return ((this.fixedDividend / 100) * this.parValue) / this.tickerPrice;
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

        public double getPeRatio()
            {
            double peRatio = 0;
            if (tickerPrice > 0)
                {
                peRatio = this.tickerPrice / this.getDividendYield();
                }
            return peRatio;
            }                

        }
    }



  
    
