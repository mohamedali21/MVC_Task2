using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_Task2.Models
{
    [Table("Review")]
    public class Review
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string PReview { get; set; }
        public int Rate { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public virtual Product Product  { get; set; }
    }
}