using E_ticaret.MvcWebUi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_ticaret.MvcWebUi.Models
{
    public class OrderDetailsModel
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public double Total { get; set; }
        public DateTime OrderDate { get; set; }
        public EnumOrderState OrderState { get; set; }


        public string FullName { get; set; }
        public string AdresBaslik { get; set; }
        public string Adres { get; set; }
        public string Sehir { get; set; }
        public string Ilce { get; set; }
        public string Telefon { get; set; }
        public string PostaKKodu { get; set; }


        public virtual List<OrderLineModel> OrderLines { get; set; }
    }

    public class OrderLineModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
      

    }
}