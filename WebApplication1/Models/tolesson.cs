using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models
{
    public class tolesson
    {
        [Key]
        public int Id { get; set; }
        public int lessonId { get; set; }
        public int studentId { get; set; }
        public virtual lesson lesson { get; set; }
        public virtual student student { get; set; }
    }
}