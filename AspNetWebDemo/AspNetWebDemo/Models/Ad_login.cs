using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetWebDemo.Models
{
    public class Ad_login
    {
        [Required]
        [DataType(DataType.Text)]
        public string LoginName { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string LoginPassword { get; set; }
    }
}
