using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace eUseControl.Web.Models
{
    public class UserRegister
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        public object Name { get; set; }
        public object Surname { get;  set; }
    }

    public class UserRegisterDBContext : DbContext
    {
        public DbSet<UserRegister> Users { get; set; }
    }
}
