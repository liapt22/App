using eUseControl.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Net;
using eUseControl.BussinesLogic;
using eUseControl.Domain.Entities.User;
using eUseControl.BussinesLogic.Interfaces;



namespace eUseControl.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IRegister _register;
        public RegisterController()
        {
            var bl = new BusinessLogic();
            _register = bl.GetRegisterBL();
        }
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        // POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserRegister register)
        {
            if (ModelState.IsValid)
            {
                var bl = new BusinessLogic();
                //create a new user
                URegister newUser = new URegister
                {
                    Username = register.Username,
                    Email = register.Email,
                    Password = register.Password
                };
                _register.Insert_RegisterUserAction(newUser);
                _register.SendEmail_Register(newUser);

                ViewBag.Message = "User registered successfully";

            }
            return View();


        }


    }
}