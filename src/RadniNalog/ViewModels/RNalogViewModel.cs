using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadniNalog.ViewModels
{
    public class RNalogViewModel
    {
        public int ID { get; set; }
        public DateTime Datum { get; set; }
        public string OpisRadova { get; set; }
        public string Materijal { get; set; }
        public string Rukovoditelj { get; set; }
        public string Izvrsitelj2 { get; set; }
        public string Izvrsitelj3 { get; set; }
        public string PutniNalog { get; set; }
        public AutomobilViewModel Automobil{get;set;}
        public VrstRadaViewModel VrstaRada { get; set; }
        public MjestoRadaViewModel MjestoRada { get; set; }
    }
}
