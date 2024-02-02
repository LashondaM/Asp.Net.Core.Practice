using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Stock
{
    public class StockDto
    {
        public int Id { get; set; }
        public string Symbol { get; set; } = string.Empty; // puts an empty string into the DB when the value for it is empty instead of putting a null
        public string CompanyName { get; set; } = string.Empty;
        public decimal Purchase { get; set; }
        public decimal LastDiv { get; set; } // Last Dividend
        public string Industry { get; set; } = string.Empty;
        public long MarketCap { get; set; }
    }
}