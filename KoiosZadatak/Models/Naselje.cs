using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoiosZadatak.Models
{
    public class Naselje
    {
        public int Id { get; set; }
        public string PostanskiBroj { get; set; }
        public string Naziv { get; set; }
        public int DrzavaId { get; set; }
        public virtual Drzava Drzava { get; set; }
    }
}
