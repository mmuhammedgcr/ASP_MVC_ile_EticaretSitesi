using E_ticaret.MvcWebUi.Entity;
using E_ticaret.MvcWebUi.Models;
using E_ticaret.MvcWebUi.Identity;
using Microsoft.AspNet.Identity;
using E_ticaret.MvcWebUi.Controllers;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Web.Security;

namespace E_ticaret.MvcWebUi.Controllers
{
    public class AccountController : Controller
    {
        private DataContext db = new DataContext();

        private UserManager<ApplicationUser> UserManager;
        private RoleManager<ApplicationRole> RoleManager;


        public AccountController()
        {
            var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            UserManager = new UserManager<ApplicationUser>(userStore);

            var roleStore = new RoleStore<ApplicationRole>(new IdentityDataContext());
            RoleManager = new RoleManager<ApplicationRole>(roleStore);
        }
        
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        [Authorize]
        public ActionResult Index()
        {
            var username = User.Identity.Name;
            var orders = db.Orders.Where(i => i.FullName == username)
                .Select(i => new UserOrderModel()
                {
                    Id = i.Id,
                    OrderNumber = i.OrderNumber,
                    OrderDate = i.OrderDate,
                    Total = i.Total,
                    OrderState = i.OrderState

                }).OrderByDescending(i => i.OrderDate).ToList();
            return View(orders);
        }

        [Authorize ]
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



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser();
                user.Name = model.Name;
                user.LastName = model.LatName;
                user.Email = model.Email;
                user.UserName = model.UserName;

                var result = UserManager.Create(user, model.Password);


                if (result.Succeeded)
                {
                    if (RoleManager.RoleExists("user"))
                    {
                        UserManager.AddToRole(user.Id, "user");
                    }
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("RegisterUserError", "Kullanıcı olusturma hatası...");
                }
            }
            return View();
        }



        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model)
        {
            if (ModelState.IsValid)
            {

                var user = UserManager.Find(model.UserName, model.Password);

                if (user!=null)
                {
                    var authManager=HttpContext.GetOwinContext().Authentication;
                    var identityclaims = UserManager.CreateIdentity(user, "ApplicationCookie");
                    var authProperties = new AuthenticationProperties();
                    authProperties.IsPersistent = model.RememberMe;
                    authManager.SignIn(authProperties, identityclaims);

                    if (user.UserName=="mmuhammedgcr")
                    {
                        return RedirectToAction("Index", "Product");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    

                }
                else
                {
                    ViewBag.Message = "Hatalı giriş yaptınız. Tekrar deneyiniz...";
                    ModelState.AddModelError("LoginUserError", "Kullanıcı bulubnamadı...");
                }

            }
            return View();
        }


        public ActionResult LogOut()
        {
            CartController cc = new CartController();

            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            //cc.GetCart().Clear(); // Çıkış yaptığı zaman kullanıcının sepetini boşalt
            return RedirectToAction("Login","Account");
            
        }
    }
}