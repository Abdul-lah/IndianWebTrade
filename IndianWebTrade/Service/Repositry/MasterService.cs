using DAL.IndianTradeDb;
using INFASTRUCTURE.Dto;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Service.Repositry
{
    public class MasterService : IMasterService
    {
        private readonly IndianWebTradeDBContext _dbContext;
        public MasterService(IndianWebTradeDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public List<CategoryDto> GetCategories()
        {
            return _dbContext.MstCatogery.Select(s => new CategoryDto
            {
                Id = s.Id,
                CatogeryId = s.CatogeryId,
                CatogeryName = s.CatogeryName
            }).ToList();
        }
    }
}
