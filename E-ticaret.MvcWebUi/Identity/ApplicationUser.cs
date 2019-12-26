using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_ticaret.MvcWebUi.Identity
{
    public class ApplicationUser:IdentityUser
    {
        private string v;

        public ApplicationUser()
        {
        }

        public ApplicationUser(string userName, string v) : base(userName)
        {
            this.v = v;
        }

        public string Name { get; set; }
        public string LastName { get; set; }
    }
}