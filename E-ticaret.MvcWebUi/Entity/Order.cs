using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_ticaret.MvcWebUi.Entity
{
    public class Order
    {
        public int Id { get; set; }
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


        public virtual List<OrderLine> OrderLines { get; set; }
    }
    public class OrderLine
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
        public double Price { get; set; }

        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}