using System;
using System.Collections.Generic;

#nullable disable

namespace Madopskrift.Models
{
    public partial class Bruger
    {
        public Bruger()
        {
            Opskrifts = new HashSet<Opskrift>();
        }

        public int Id { get; set; }
        public string Brugernavn { get; set; }
        public int Alder { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Opskrift> Opskrifts { get; set; }
    }
}
