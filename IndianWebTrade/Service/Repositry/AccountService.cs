using DAL.IndianTradeDb;
using INFASTRUCTURE.Dto;
using INFASTRUCTURE.GernalResult;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Service.Repositry
{
    public class AccountService : IAccount
    {
        private readonly IndianWebTradeDataBaseContext _dbContext;
        public AccountService(IndianWebTradeDataBaseContext dBContext)
        {
            _dbContext = dBContext;
        }

        public IGernalResult AddUserRole(UserRoleDto dto)
        {
            IGernalResult result = new GernalResult();
            try
            {
                //MstUserRole userRole = new MstUserRole
                //{
                //    RoleId = dto.Id,
                //    RoleName = dto.RoleName,
                //};
                // _dbContext.Add(userRole);
                int save = _dbContext.SaveChanges();
                result.Succsefully = save > 0 ? true : false;
                result.Message = save > 0 ? "UserRole added Succsefully." : "UserRole not add.";

            }
            catch
            {
                result.Succsefully = false;
                result.Message = "Server error.";
            }
            return result;
        }

        public IGernalResult UserRegistration(UserDto dto)
        {
            IGernalResult result = new GernalResult();
            try
            {
                TblUser User = new TblUser
                {
                    Name = dto.Name,
                    Address = dto.Address,
                    Email = dto.Email,
                    Password = dto.Password,
                    ImageUrl = dto.ImageUrl,
                    RoleId = dto.Role,
                    MobileNo = dto.MobileNo,
                    CreatedDate = DateTime.UtcNow,
                    IsSeller = dto.Role > 1 ? true : false

                };
                string userType = dto.Role > 1 ? "Seller" : "User";
                _dbContext.Add(User);
                int save = _dbContext.SaveChanges();
                result.Succsefully = save > 0 ? true : false;
                result.Message = save > 0 ? userType + " register Succsefully" : userType + "not register";

            }
            catch
            {
                result.Succsefully = false;
                result.Message = "server error";
            }
            return result;
        }
        public IGernalResult EditUser(UserDto dto)
        {
            IGernalResult result = new GernalResult();
            try
            {
                TblUser User = _dbContext.TblUser.Where(w => w.Id == dto.Id).FirstOrDefault();
                {
                    User.Name = dto.Name;
                    User.Address = dto.Address;

                    User.ImageUrl = dto.ImageUrl;

                };

                int save = _dbContext.SaveChanges();
                result.Succsefully = save > 0 ? true : false;
                result.Message = save > 0 ? "User update Succsefully" : "User not update";

            }
            catch
            {
                result.Succsefully = false;
                result.Message = "server error";
            }
            return result;
        }
    }
}
