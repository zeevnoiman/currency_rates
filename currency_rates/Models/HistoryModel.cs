using Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace currency_rates.Models
{
    public class HistoryModel : DbContext
    {
        public HistoryModel() : base("HistoryDB")
        {

        }
        public DbSet<CurrencyHistory> CurrHistory { get; set; }
    }
}
