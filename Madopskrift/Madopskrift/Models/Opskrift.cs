using System;
using System.Collections.Generic;

#nullable disable

namespace Madopskrift.Models
{
    public partial class Opskrift
    {
        public int Id { get; set; }
        public int BrugerId { get; set; }
        public string Titel { get; set; }
        public string Beskrivelse { get; set; }
        public string Ingredienser { get; set; }
        public string Fremgangsmoede { get; set; }

        public virtual Bruger Bruger { get; set; }
    }
}
