using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    [Table("QuotesInfo")]
    public class Quote
    {
        [Key]
        [Column(Order = 1)]
        public string quote { get; set; }

        [Key]
        [Column(Order = 2)]
        public string Country { get; set; }

        public override string ToString()
        {
            return "Name: " + quote + "\nCountry: " + Country + "\n";
        }
    }
}
