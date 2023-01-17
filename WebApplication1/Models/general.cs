using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class general
    {
        [Key]
        public int generalId { get; set; }
        public string name { get; set; }
        public string objective { get; set; }
        public string type { get; set; }
    }
}