using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadniNalog.Models
{
    public class VrstaRada
    {
        public int ID { get; set; }
        public string Naziv { get; set; }

        public ICollection<RNalog> Nalozi { get; set; }
    }
}
