using System;
using System.Collections.Generic;

namespace AspNetWebDemo.Tietokanta
{
    public partial class Varaukset
    {
        public string Varaajannimi { get; set; }
        public string Varaukset1 { get; set; }
        public DateTime Varauspäivämäärä { get; set; }
        public DateTime Palautuspäivämäärä { get; set; }
    }
}
