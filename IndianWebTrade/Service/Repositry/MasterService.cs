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
        private readonly IndianWebTradeDataBaseContext _dbContext;
        public MasterService(IndianWebTradeDataBaseContext dBContext)
        {
            _dbContext = dBContext;
        }
        public List<CategoryDto> GetCategories()
        {

            return _dbContext.MstCatogery.Select(s => new CategoryDto
            {
                Id = s.Id,
                CatogeryName = s.CatogeryName
            }).ToList();
        }

    }
}
