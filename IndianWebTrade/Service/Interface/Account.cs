using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.IndianTradeDb;
using INFASTRUCTURE.Dto;
using INFASTRUCTURE.GernalResult;
using System.Linq;
namespace Service.Interface
{
    public interface IAccount
    {
        IGernalResult UserRegistration(UserDto dto);
        IGernalResult AddUserRole(UserRoleDto dto);
        IGernalResult EditUser(UserDto dto);
        IGernalResult ChangePassword(int id, string password);

        IGernalResult userLogin(UserDto dto);

    }

}
