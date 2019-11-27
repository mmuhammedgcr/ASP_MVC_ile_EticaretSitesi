using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace E_ticaret.MvcWebUi.Entity
{
    public class Product
    {
        public int  Id { get; set; }
        [DisplayName("Ürün Adı")]
        public string Name { get; set; }
        [DisplayName("Ürün Açıklaması")]
        public string Description { get; set; }
        [DisplayName("Fiyatı")]
        public double Price { get; set; }
        [DisplayName("Stok Miktarı")]
        public int  Stock { get; set; }
        [DisplayName("Anasayfa Durumu")]
        public bool IsApproved { get; set; }
        [DisplayName("Kargo Durumu")]
        public bool Cargo { get; set; }
        [DisplayName("Ürün Resmi")]
        public string Image { get; set; }

        


        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}