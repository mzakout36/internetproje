using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class mycontext:DbContext
    {
        public DbSet<student> students { get; set; }
        public DbSet<general> generals { get; set; }
        public DbSet<lesson> lessons { get; set; }
        public DbSet<tolesson> tolessons { get; set; }
    }
}