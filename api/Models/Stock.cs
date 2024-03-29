using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public string Symbol { get; set; } = string.Empty; // puts an empty string into the DB when the value for it is empty instead of putting a null
        public string CompanyName { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18,2)")] // tells sql to limit the digits to 18 and decimal places to 2
        public decimal Purchase { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal LastDiv { get; set; } // Last Dividend
        public string Industry { get; set; } = string.Empty;
        public long MarketCap { get; set; }

        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}