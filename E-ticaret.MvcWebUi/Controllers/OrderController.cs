using E_ticaret.MvcWebUi.Entity;
using E_ticaret.MvcWebUi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_ticaret.MvcWebUi.Controllers
{
    [Authorize(Roles = "admin")]
    public class OrderController : Controller
    {
        DataContext db = new DataContext();
        // GET: Order

        public ActionResult Index()
        {
            var order = db.Orders.Select(x => new AdminOrderModel()
            {
                Id = x.Id,
                OrderNumber = x.OrderNumber,
                OrderDate = x.OrderDate,
                OrderState = x.OrderState,
                Count = x.OrderLines.Count,
                Total = x.Total

            }).OrderByDescending(i=>i.OrderDate).ToList();
            
            return View(order);
        }

        public ActionResult Details(int id)
        {
            var entity = db.Orders.Where(i => i.Id == id)
                               .Select(i => new OrderDetailsModel()
                               {
                                   OrderId = i.Id,
                                   OrderNumber = i.OrderNumber,
                                   Total = i.Total,
                                   OrderDate = i.OrderDate,
                                   OrderState = i.OrderState,
                                   AdresBaslik = i.AdresBaslik,
                                   Adres = i.Adres,
                                   Sehir = i.Sehir,
                                   Ilce = i.Ilce,
                                   Telefon = i.Telefon,
                                   PostaKKodu = i.PostaKKodu,
                                   FullName=i.FullName,
                                   OrderLines = i.OrderLines.Select(a => new OrderLineModel()
                                   {
                                       ProductId = a.ProductId,
                                       ProductName = a.Product.Name,
                                       Image = a.Product.Image,
                                       Quantity = a.Quantity,
                                       Price = a.Price
                                   }).ToList()
                               }).FirstOrDefault();


            return View(entity);
        }


        public ActionResult UpdateOrderState(int OrderId, EnumOrderState OrderState)
        {
            var order = db.Orders.FirstOrDefault(x => x.Id == OrderId);

            if (order!=null)
            {
                order.OrderState = OrderState;
                db.SaveChanges();
                TempData["mesaj"] = "Bilgiler Güncellendi";
                return RedirectToAction("Index", new { id = OrderId });
            }

            return View("Index");
        }
    }
}