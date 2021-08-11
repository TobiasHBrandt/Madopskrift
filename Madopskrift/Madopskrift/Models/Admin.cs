using System;
using System.Collections.Generic;

#nullable disable

namespace Madopskrift.Models
{
    public partial class Admin
    {
        public int Id { get; set; }
        public string Fornavn { get; set; }
        public string Efternavn { get; set; }
        public int Alder { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
