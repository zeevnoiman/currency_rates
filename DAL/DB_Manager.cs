using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DB_Manager : DbContext
    {
        public DB_Manager() : base("CurrenciesDB")
        {

        }

        public DbSet<Currency> Currencies { get; set; }

    }
}
