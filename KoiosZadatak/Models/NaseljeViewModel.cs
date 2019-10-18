using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoiosZadatak.Models
{
    public class NaseljeViewModel
    {
        public Drzava Drzava { get; set; }
        public Naselje Naselje { get; set; }
        public IEnumerable<Drzava> Drzave { get; set; }
        public IEnumerable<Naselje> Naselja { get; set; }

    }
}
