﻿using eUseControl.BussinesLogic.AppBL;
using eUseControl.Data.Entities.Admin;
using eUseControl.Data.Entities.Product;
using eUseControl.Data.Entities.User;
using eUseControl.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.BussinesLogic.Core
{
    public class AdminApi
    {
          internal Response AddUserAction(AddUserData user)
          {
               var validate = new EmailAddressAttribute();
               if (validate.IsValid(user.Email))
               {
                    using (var db = new TableContext())
                    {
                         UserTable existingEmail = db.Users.FirstOrDefault(u => u.Email == user.Email);
                         UserTable existingUsername = db.Users.FirstOrDefault(u => u.Username == user.Username);
                         if (existingEmail != null)
                         {
                              return new Response { Status = false, StatusMsg = "Emailul deja înregistrat." };
                         }
                         if (existingUsername != null)
                         {
                              return new Response { Status = false, StatusMsg = "Numele deja există." };
                         }

                         var newUser = new UserTable
                         {
                              Username = user.Username,
                              Password = LoginHelper.HashGen(user.Password),
                              Email = user.Email,
                              Level = user.Level,
                              LastLogin = DateTime.Now,
                              LastIp = "1:1:1:1",
                              Image = user.Username + ".png"
                         };
                         db.Users.Add(newUser);
                         db.SaveChanges();
                    }
                    return new Response { Status = true };
               }
               else
                    return new Response { Status = false };
          }

          internal void DeleteUserAction(int id)
          {
               using (var db = new TableContext())
               {
                    UserTable user = db.Users.FirstOrDefault(u => u.Id == id);
                    db.Users.Remove(user);
                    db.SaveChanges();
               }
          }

          internal Response EditUserAction(EditUserData data)
          {
               var validate = new EmailAddressAttribute();
               if (validate.IsValid(data.Email))
               {
                    using (var db = new TableContext())
                    {
                         UserTable user = db.Users.FirstOrDefault(u => u.Email == data.Email);
                         user.Username = data.Username;
                         user.Email = data.Email;
                         user.Level = data.Level;
                         db.SaveChanges();
                    }
                    return new Response { Status = true };
               }
               else
                    return new Response { Status = false };
          }


          internal Response AddBookAction(AddBookData book)
          {
               using (var db = new TableContext())
               {
                    BookTable existingBook = db.Books.FirstOrDefault(u => u.Name == book.Name);
                    if (existingBook != null)
                    {
                         return new Response { Status = false, StatusMsg = "Cartea deja există." };
                    }

                    var newBook = new BookTable
                    {
                         Name = book.Name,
                         Price = book.Price,
                         Description = book.Description,
                         Author = book.Description,
                         Edit = book.Edit,
                         Type = book.Type,
                         Bought = 0,
                         Image = book.Name + ".png"
                    };
                    db.Books.Add(newBook);
                    db.SaveChanges();
               }
               return new Response { Status = true };
          }

          internal void DeleteBookAction(int id)
          {
               using (var db = new TableContext())
               {
                    BookTable book = db.Books.FirstOrDefault(u => u.Id == id);
                    db.Books.Remove(book);
                    db.SaveChanges();
               }
          }

          internal Response EditBookAction(EditBookData data)
          {
               using (var db = new TableContext())
               {
                    BookTable book = db.Books.FirstOrDefault(u => u.Name == data.Name);
                    book.Name = data.Name;
                    book.Price = data.Price;
                    book.Description = data.Description;
                    book.Author = data.Author;
                    book.Edit = data.Edit;
                    book.Type = data.Type;
                    db.SaveChanges();
               }
               return new Response { Status = true };
          }
     }
}
