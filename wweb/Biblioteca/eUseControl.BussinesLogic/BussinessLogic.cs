using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eUseControl.BussinesLogic.AppBL;
using eUseControl.BussinesLogic.Interfaces;

namespace eUseControl.BussinesLogic
{
    public class BusinessLogic
    {
        public IRegister GetRegisterBL()
        {
            return new RegisterBL();
        }


    }

}
