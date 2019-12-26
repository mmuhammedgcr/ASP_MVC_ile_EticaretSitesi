using E_ticaret.MvcWebUi.Entity;
using E_ticaret.MvcWebUi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_ticaret.MvcWebUi.Controllers
{
    public class CartController : Controller
    {
       private DataContext db = new DataContext();
        // GET: Cart
        public ActionResult Index()
        {
            return View(GetCart());
        }
        public ActionResult AddToCart(int Id)
        {
            var product = db.Products.FirstOrDefault(i => i.Id == Id);
            if (product!=null)
            {
                GetCart().AddProduct(product,1);

            }
            return RedirectToAction("Index");
        }
        public ActionResult RemoveFromCart(int Id)
        {
            var product = db.Products.FirstOrDefault(i => i.Id == Id);
            if (product != null)
            {
                GetCart().DeleteProduct(product);

            }
            return RedirectToAction("Index");
        }
        public ActionResult AllDelete()
        {
            GetCart().Clear();
            return RedirectToAction("Index");
        }


        public Cart GetCart()
        {
            var cart = (Cart)Session["Cart"];
            if (cart==null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }

            return cart;
        }
        public PartialViewResult sepetMiktar()
        {
            return PartialView(GetCart());
        }

       
        public ActionResult CheckOut()
        {
            return View(new ShippingDetails());
        }
        [HttpPost]
        public ActionResult CheckOut(ShippingDetails entity)
        {
            var cart = GetCart();
            if (cart.CartLines.Count==0)
            {
                ModelState.AddModelError("HataError", "Sipariş listenizde ürün bulunmamaktadır.");
            }
            if (ModelState.IsValid)
            {
                SaveOrder(cart, entity);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(entity);
            }
     
        }

        private void SaveOrder(Cart cart, ShippingDetails entity)
        {
            var order = new Order();
            order.OrderNumber = "A" + (new Random()).Next(11111, 66666);
            order.OrderDate = DateTime.Now;
            order.OrderState = EnumOrderState.Bekleniyor;
            order.FullName = User.Identity.Name;
            order.Total = cart.Total();
            


            order.AdresBaslik = entity.AdresBaslik;
            order.Adres = entity.Adres;
            order.Sehir = entity.Sehir;
            order.Ilce = entity.Ilce;
            order.PostaKKodu = entity.PostaKKodu;
            order.Telefon = entity.Telefon;
            order.OrderLines = new List<OrderLine>();

           
            foreach (var pr in cart.CartLines)
            {
                var orderline = new OrderLine();
                orderline.Quantity = pr.Quantity;
                orderline.Price = pr.Quantity * pr.Product.Price;
                orderline.ProductId = pr.Product.Id;

                order.OrderLines.Add(orderline);


            }
            db.Orders.Add(order);
            db.SaveChanges();



        }
    }
}