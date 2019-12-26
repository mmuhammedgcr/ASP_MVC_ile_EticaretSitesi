using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_ticaret.MvcWebUi.Models
{
    public class Register
    {
        [Required]
        [DisplayName("Adınız")]
        public string Name { get; set; }


        [Required]
        [DisplayName("Soyadınız")]
        public string LatName { get; set; }


        [Required]
        [DisplayName("Kullanıcı Adınız")]
        public string UserName { get; set; }


        [Required]
        [DisplayName("Email Adresi")]
        [EmailAddress(ErrorMessage ="Düzgün Girin")]
        public string Email { get; set; }


        [Required]
        [DisplayName("Şifre")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required]
        [DisplayName("Şifre Tekrar")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Şifreler Uyuşmuyor")]
        public string RePassword { get; set; }
    }
}