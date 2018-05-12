using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_Task2.Models
{
    [Table("Product")]
    public class Product
    {  
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Img_Url { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}