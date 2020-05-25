using System;
using System.Collections.Generic;

namespace AspNetWebDemo.Tietokanta
{
    public partial class LoginDb
    {
        public long LoginId { get; set; }
        public string LoginName { get; set; }
        public string LoginPassword { get; set; }
    }
}
