using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_ticaret.MvcWebUi.Models
{
    public class ShippingDetails
    {
        [Required(ErrorMessage = "Lütfen isim Giriniz")]
        public string FullName { get; set; }
        [Required(ErrorMessage ="Lütfen Adres Baslıgını Giriniz")]
        public string AdresBaslik { get; set; }
        [Required(ErrorMessage = "Lütfen Adres  Giriniz")]
        public string Adres { get; set; }
        [Required(ErrorMessage = "Lütfen sehir  Giriniz")]
        public string Sehir { get; set; }
        [Required(ErrorMessage = "Lütfen Ilce  Giriniz")]
        public string Ilce { get; set; }
        [Required(ErrorMessage = "Lütfen telefon  Giriniz")]
        public string Telefon { get; set; }
        public string PostaKKodu { get; set; }
    }
}