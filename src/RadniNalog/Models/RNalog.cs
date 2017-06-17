using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RadniNalog.Models
{
    public class RNalog
    {
        public int ID { get; set; }

       
        public string Datum { get; set; }
        public string OpisRadova { get; set; }
        public string Materijal { get; set; }
        public string Rukovoditelj { get; set; }
        public string Izvrsitelj2 { get; set; }
        public string Izvrsitelj3 { get; set; }
        public string PutniNalog{get;set;}


        //nav properties
        public int AutomobilID { get; set; }
        public Automobil Automobil { get; set; }


        public int MjestoRadaID { get; set; }
        public MjestoRada MjestoRada { get; set; }

        public int VrstaRadaID { get; set; }
        public VrstaRada VrstaRada { get; set; }

    }
}
