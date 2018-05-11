using MVC_Task2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Task2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<ProductVM> prods = new List<ProductVM>
            {
                new ProductVM {Name="Iphone6",Img_Url="iphone6.jpg",NumOfReviews=82,Price=500,Rate=5},
                new ProductVM {Name="HTC-one",Img_Url="htc-one.jpg",NumOfReviews=50,Price=400,Rate=4 },
                new ProductVM { Name="Iphone6",Img_Url="iphone6.jpg",NumOfReviews=60,Price=450,Rate=3}
            };
            return View(prods);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}