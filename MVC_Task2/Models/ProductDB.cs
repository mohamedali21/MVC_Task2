using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_Task2.Models
{
    public class ProductDB :DbContext
    {
        public ProductDB():base("DefaultConnection")
        {

        }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
      
    }
}