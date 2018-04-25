using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    [Table("CurrencyHistoryInfo")]
    public class CurrencyHistory
    {
            public CurrencyHistory() { }

            [Key]
            [Column(Order = 1)]
            public string Source { get; set; } // USD

            [Key]
            [Column(Order = 2)]
            public string Target { get; set; } // EUR

            [Key]
            [Column(Order = 3)]
            public double Value { get; set; } //3.24

            [Key]
            [Column(Order = 4)]
            public long Timestamp { get; set; } //3243545657
        
            private DateTime date;
            [Key]
            [Column(Order = 5)]
            public DateTime Date {
            get
            {
                return date;
            }
            set
            {
                date = value;
            }
        }

            public override string ToString()
            {
            
                return "Name: " + Source + Target + "\nValue: " + Value + "\nDate: " + Date.ToString("dd/MM/yyyy");
            }

    }
}


