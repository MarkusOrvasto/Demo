using System;
using System.Collections.Generic;

namespace AspNetWebDemo.Tietokanta
{
    public partial class VarastoTilanne
    {
        public long ItemId { get; set; }
        public string ItemName { get; set; }
        public long? ItemQuantity { get; set; }
    }
}
