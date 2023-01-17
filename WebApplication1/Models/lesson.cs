using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models
{
    public class lesson
    {
        public int lessonId { get; set; }
        public string name { get; set; }
        public int? point { get; set; }
        public int generalId { get; set; }
        public virtual general general { get; set; }
    }
}