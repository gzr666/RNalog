using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RadniNalog.Models
{
    public class Zaposlenik
    {
        public int ID { get; set; }

        [Required]
        public string Ime { get; set; }

       // public ICollection<RNalog> Nalozi { get; set; }
    }
}
