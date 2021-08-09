using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Madopskrift.Models
{
    public class Opskrift
    {
        public int ID { get; set; }

        public string Titel { get; set; }

        public string Beskrivelse { get; set; }

        public string Ingredienser { get; set; }

        public string Fremgangsmåde { get; set; }
    }
}
