using E_ticaret.MvcWebUi.Entity;
using E_ticaret.MvcWebUi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace E_ticaret.MvcWebUi.Controllers
{
    public class HomeController : Controller
    {
        DataContext context = new DataContext();
        
        // GET: Home
        public ActionResult Index()
        {
            return View(context.Products.Where(i=>i.IsApproved==true).Select(i=>new ProductModel {
                Id=i.Id,
                Name =i.Name,
                Description=i.Description.Length > 50? i.Description.Substring(0,50)+"...":i.Description,
                Price=i.Price,
                Stock=i.Stock,
                Cargo=i.Cargo,
                Image=i.Image,
                CategoryId=i.CategoryId

            }).ToList());
        }
        public ActionResult Details(int id)
        {
            return View(context.Products.Where(i=>i.Id==id).FirstOrDefault());
        }
        public ActionResult List(int? id)
        {
            var urunler = context.Products.Where(i => i.IsApproved == true).Select(i => new ProductModel
            {
                Id = i.Id,
                Name = i.Name,
                Description = i.Description.Length > 50 ? i.Description.Substring(0, 50) + "..." : i.Description,
                Price = i.Price,
                Stock = i.Stock,
                Cargo = i.Cargo,
                Image = i.Image,
                CategoryId = i.CategoryId

            }).AsQueryable();

            if (id!=null)
            {
                urunler = urunler.Where(i => i.CategoryId == id);
            }

            return View(urunler.ToList());
        }

        public PartialViewResult GetCategory()
        {
            return PartialView(context.Categories.ToList());
        }
    }
}