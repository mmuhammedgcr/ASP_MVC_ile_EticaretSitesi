﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_ticaret.MvcWebUi.Models
{
    public class Login
    {

        [Required]
        [DisplayName("Kullanıcı Adınız")]
        public string UserName { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Şifre")]
        public string Password { get; set; }


        [DisplayName("Beni Hatırla")]
        public bool RememberMe { get; set; }

    }
}