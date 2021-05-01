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
        public IGernalResult userLogin(UserDto dto)
        {
            IGernalResult result = new GernalResult();
            try
            {
                TblUser user = _dbContext.TblUser.Where(w => w.Email == dto.Email).FirstOrDefault();
                if (user != null)
                {
                    if (user.Password == dto.Password)
                    {
                        var roles = _dbContext.MstRole.Where(w => w.Id == user.RoleId).FirstOrDefault();
                        result.Succsefully = true;
                        result.value = new UserDto
                        {
                            Id = user.Id,
                            RoleId = user.RoleId ?? 0,
                            Email = user.Email,
                            Role = roles.Role
                        };
                    }
                    else
                    {
                        result.Succsefully = false;
                        result.Message = "Password is wrong";
                    }
                }
                else
                {
                    result.Succsefully = false;
                    result.Message = "Please enter a valid email.";
                }
            }
            catch
            {
                result.Succsefully = false;
                result.Message = "server error.";
            }
            return result;
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
                    RoleId = dto.RoleId,
                    MobileNo = dto.MobileNo,
                    CreatedDate = DateTime.UtcNow,
                    IsSeller = dto.RoleId > 1 ? true : false

                };
                string userType = dto.RoleId > 1 ? "Seller" : "User";
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

        public IGernalResult ChangePassword(int id,string password)
        {
            IGernalResult result = new GernalResult();
            try
            {
                TblUser User = _dbContext.TblUser.Where(w => w.Id == id).FirstOrDefault();
                User.Password = password;
                int update = _dbContext.SaveChanges();
                result.Succsefully = true;
                result.Message = "Password change succsefully.";
            }
            catch
            {
                result.Succsefully = false;
                result.Message = "Server eroor";
            }
            return result;
        }
    }
}
