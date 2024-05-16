using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eUseControl.BussinesLogic.Interfaces;
using eUseControl.Data.Entities.User;
using eUseControl.BussinesLogic.Core;
using eUseControl.Domain.Entities.User;


namespace eUseControl.BussinesLogic
{
    public class SessionBL : UserApi, ISession
    {
 
       
    }
    public class RegisterBL : UserApi, IRegister
    {
        public void Insert_RegisterUserAction(URegister register)
        {
            RegisterUserAction(register);
        }
        public void SendEmail_Register(URegister register)
        {
            SendEmail(register);
        }
    }
}