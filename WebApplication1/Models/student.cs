using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models
{
    public class student
    {
        [Key]

        public int studentId { get; set; }
        public string name { get; set; }
        public DateTime date { get; set; }
        public string number { get; set; }
        public string birthday { get; set; }
        public string dep { get; set; }
    }
}