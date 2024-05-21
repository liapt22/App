﻿using eUseControl.BussinesLogic.Core;
using eUseControl.BussinesLogic.Interfaces;
using eUseControl.Data.Entities.Product;
using eUseControl.Data.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace eUseControl.BussinesLogic.AppBL
{
    public class SessionBL: UserApi, ISession
    {
        public Response UserLogin(ULoginData data)
        {
            return UserLoginAction(data);
        }
        public Response UserRegister(UregisterData data)
        {
            return UserRegisterAction(data);
        }
          public List<UserTable> GetUsersList()
          {
               return GetUsersListAction();
          }
          public List<BookTable> GetBooksList()
          {
               return GetBooksListAction();
          }
          public HttpCookie GenCookie(string loginCredential)
        {
            return Cookie(loginCredential);
        }
        public UserMinimal GetUserByCookie(string apiCookieValue)
        {
            return UserCookie(apiCookieValue);
        }
    }
}
