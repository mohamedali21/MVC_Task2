using Microsoft.AspNet.SignalR;
using MVC_Task2.Models;
using MVC_Task2.MyHubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Task2.Controllers
{
    public class HomeController : Controller
    {
        ProductDB db = new ProductDB();
        public ActionResult Index()
        {
            List<ProductVM> prodsVM = new List<ProductVM>();
        
            if (!db.Database.Exists())
            {
                Product p1 = new Product() { Name = "Iphone6", Img_Url = "iphone6.jpg", Quantity = 20, Price = 500 };
                Product p2 = new Product() { Name = "HTC-one", Img_Url = "htc-one.jpg", Quantity = 25, Price = 400 };
                Product p3 = new Product() { Name = "Iphone6", Img_Url = "iphone6.jpg", Quantity = 50, Price = 450 };
                db.Products.Add(p1);
                db.Products.Add(p2);
                db.Products.Add(p3);
                db.SaveChanges();
                Review r1 = new Review() { PReview = "Good", Rate = 5, ProductId = p1.Id };
                Review r2 = new Review() { PReview = "Good", Rate = 4, ProductId = p1.Id };
                Review r3 = new Review() { PReview = "Good", Rate = 5, ProductId = p1.Id };
                Review r4 = new Review() { PReview = "Good", Rate = 3, ProductId = p1.Id };
                Review r5 = new Review() { PReview = "Good", Rate = 5, ProductId = p1.Id };
                db.Reviews.Add(r1);
                db.Reviews.Add(r2);
                db.Reviews.Add(r3);
                db.Reviews.Add(r4);
                db.Reviews.Add(r5);

                Review r6 = new Review() { PReview = "Good", Rate = 5, ProductId = p2.Id };
                Review r7 = new Review() { PReview = "Good", Rate = 4, ProductId = p2.Id };
                Review r8 = new Review() { PReview = "Good", Rate = 2, ProductId = p2.Id };
                Review r9 = new Review() { PReview = "Good", Rate = 3, ProductId = p2.Id };
                Review r10 = new Review() { PReview = "Good", Rate = 5, ProductId = p2.Id };
                Review r11 = new Review() { PReview = "Good", Rate = 5, ProductId = p2.Id };
                Review r12 = new Review() { PReview = "Good", Rate = 4, ProductId = p2.Id };
                Review r13 = new Review() { PReview = "Good", Rate = 2, ProductId = p2.Id };
                Review r14 = new Review() { PReview = "Good", Rate = 3, ProductId = p2.Id };
                Review r15 = new Review() { PReview = "Good", Rate = 5, ProductId = p2.Id };
                db.Reviews.Add(r6);
                db.Reviews.Add(r7);
                db.Reviews.Add(r8);
                db.Reviews.Add(r9);
                db.Reviews.Add(r10);
                db.Reviews.Add(r11);
                db.Reviews.Add(r12);
                db.Reviews.Add(r13);
                db.Reviews.Add(r14);
                db.Reviews.Add(r15);

                Review r16 = new Review() { PReview = "Good", Rate = 2, ProductId = p3.Id };
                Review r17 = new Review() { PReview = "Good", Rate = 3, ProductId = p3.Id };
                Review r18 = new Review() { PReview = "Good", Rate = 5, ProductId = p3.Id };
                Review r19 = new Review() { PReview = "Good", Rate = 5, ProductId = p3.Id };
                Review r20 = new Review() { PReview = "Good", Rate = 4, ProductId = p3.Id };
                Review r21 = new Review() { PReview = "Good", Rate = 2, ProductId = p3.Id };
                Review r22 = new Review() { PReview = "Good", Rate = 3, ProductId = p3.Id };
                Review r23 = new Review() { PReview = "Good", Rate = 5, ProductId = p3.Id };
                db.Reviews.Add(r16);
                db.Reviews.Add(r17);
                db.Reviews.Add(r18);
                db.Reviews.Add(r19);
                db.Reviews.Add(r20);
                db.Reviews.Add(r21);
                db.Reviews.Add(r22);
                db.Reviews.Add(r23);
                db.SaveChanges();
            }
            var prods = (from p in db.Products
                     select p).ToList();
            foreach (var item in prods)
            {
                var reviews = (from r in db.Reviews
                               where r.ProductId == item.Id
                               select r);
                ProductVM prodVM = new ProductVM();
                prodVM.Id = item.Id;
                prodVM.Name = item.Name;
                prodVM.Img_Url = item.Img_Url;
                prodVM.Price = item.Price;
                prodVM.Quantity = item.Quantity;
                prodVM.NumOfReviews = reviews.Count();
                prodVM.Rate = reviews.Sum(r=>r.Rate)/ prodVM.NumOfReviews;
                prodsVM.Add(prodVM);
            }

            return View(prodsVM);
        }
        public ActionResult Buy(int productID)
        {

            var product = (from p in db.Products
                           where p.Id == productID
                           select p).FirstOrDefault();
            product.Quantity--;
            db.SaveChanges();
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<ChangeQty>();
            //hubContext.Clients.All.DeptChange(department);
            hubContext.Clients.All.QtyChange(product.Id, product.Quantity);
            return RedirectToAction("Index");
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