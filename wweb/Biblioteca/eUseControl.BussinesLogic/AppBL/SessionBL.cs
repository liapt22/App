using eUseControl.BussinesLogic.Core;
using eUseControl.BussinesLogic.Interfaces;
using eUseControl.Data.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.BussinesLogic.AppBL
{
    public class SessionBL: UserApi, ISession
    {
        public UloginResp UserLogin(ULoginData data)
        {
            return UserLoginAction(data);
        }
        public UregisterResp UserRegister(UregisterData data)
        {
            return UserRegisterAction(data);
        }
    }
}
