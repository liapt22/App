using eUseControl.BussinesLogic.AppBL;
using eUseControl.Data.Entities.User;
using eUseControl.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.BussinesLogic.Core
{
    public class UserApi
    {
        internal UloginResp UserLoginAction(ULoginData data)
        {
            UserTable result;
            var validate = new EmailAddressAttribute();
            if (validate.IsValid(data.Email))
            {
                //var pass = LoginHelper.HashGen(data.Password);
                using (var db = new UserContext())
                {
                    result = db.Users.FirstOrDefault(u => u.Email == data.Email && u.Password == data.Password);
                }

                if (result == null)
                {
                    return new UloginResp { Status = false, StatusMsg = "The Username or Password is Incorrect" };
                }

                using (var todo = new UserContext())
                {
                    result.LastIp = data.LoginIp;
                    result.LastLogin = data.LoginDateTime;
                    todo.Entry(result).State = EntityState.Modified;
                    todo.SaveChanges();
                }
                return new UloginResp { Status = true };
            }
            else
                return new UloginResp { Status = false };
        }

        internal UregisterResp UserRegisterAction(UregisterData data)
        {
            UserTable existingUser;
            var validate = new EmailAddressAttribute();
            if (validate.IsValid(data.Email))
            {
                using (var db = new UserContext())
                {
                    existingUser = db.Users.FirstOrDefault(u => u.Email == data.Email);
                }

                if (existingUser != null)
                {
                    return new UregisterResp { Status = false, StatusMsg = "User With Email Already Exists" };
                }

                //var pass = LoginHelper.HashGen(data.Password);
                var newUser = new UserTable
                {
                    Email = data.Email,
                    Username = data.Username,
                    Password = data.Password,
                    LastIp = data.LoginIp,
                    LastLogin = data.LoginDateTime,
                    Level = (URole)0,
                };

                using (var todo = new UserContext())
                {
                    todo.Users.Add(newUser);
                    todo.SaveChanges();
                }
                return new UregisterResp { Status = true };
            }
            else
                return new UregisterResp { Status = false };
        }
    }
}
