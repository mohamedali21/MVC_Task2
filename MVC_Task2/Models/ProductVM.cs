﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Task2.Models
{
    public class ProductVM
    {
        public string Name { get; set; }
        public string Img_Url { get; set; }
        public int NumOfReviews { get; set; }
        public decimal Price { get; set; }
        public int Rate { get; set; }
    }
}