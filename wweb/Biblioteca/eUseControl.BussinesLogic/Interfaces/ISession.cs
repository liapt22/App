﻿using eUseControl.Data.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.BussinesLogic.Interfaces
{
    public interface ISession
    {
        UloginResp UserLogin(ULoginData data);
        UregisterResp UserRegister(UregisterData data);
    }
}
