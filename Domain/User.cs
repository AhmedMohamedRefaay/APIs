using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;

namespace Domain
{
   public class User:IdentityUser

    {

        public string  Fname { get; set; }
        public string Lname { get; set; }

        public string Password { get; set; }
        public IEnumerable<ContactDetails> contactDetails { get; set; }
    }
}
