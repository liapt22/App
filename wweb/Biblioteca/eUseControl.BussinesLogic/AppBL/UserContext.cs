using eUseControl.Data.Entities.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.BussinesLogic.AppBL
{
    public class UserContext: DbContext
    {
        public UserContext() :
  base("name=bookify")
        {

        }

        public virtual DbSet<UserTable> Users { get; set; }
    }
}
