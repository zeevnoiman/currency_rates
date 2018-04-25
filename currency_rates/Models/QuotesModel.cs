using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace currency_rates.Models
{
    class QuotesModel : DbContext
    {
        public QuotesModel() : base("quotesDB")
        { }

        public DbSet<Quote> Quotes { get; set; }
    }
}
