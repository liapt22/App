using eUseControl.Data.Entities.User;
using eUseControl.BussinesLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using eUseControl.Domain.Entities.User;


namespace eUseControl.BussinesLogic.Interfaces
{
    public interface ISession
    {
     
       
    }

    public interface IRegister
{
    void Insert_RegisterUserAction(URegister register);
    void SendEmail_Register(URegister register);
}
}
