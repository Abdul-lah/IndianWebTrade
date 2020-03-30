using DAL.IndianTradeDb;
using INFASTRUCTURE.Dto;
using INFASTRUCTURE.GernalResult;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Repositry
{
    public class AccountService : IAccount
    {
        private readonly IndianWebTradeDBContext _dbContext;
        public AccountService(IndianWebTradeDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public IGernalResult AddUserRole(UserRoleDto dto)
        {
            IGernalResult result = new GernalResult();
            try
            {
                MstUserRole userRole = new MstUserRole
                {
                    RoleId = dto.Id,
                    RoleName = dto.RoleName,
                };
                _dbContext.Add(userRole);
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
                    Role = dto.Role
                };
                _dbContext.Add(User);
                int save = _dbContext.SaveChanges();
                result.Succsefully = save > 0 ? true : false;
                result.Message = save > 0 ? "User register Succsefully" : "User not register";

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
