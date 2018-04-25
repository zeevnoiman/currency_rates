using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace currency_rates.Models
{
    public class CurrencyModel : DbContext
    {
        public CurrencyModel() : base("CurrenciesDB")
        {

        }

        public DbSet<Currency> Currencies { get; set; }
    }
}


