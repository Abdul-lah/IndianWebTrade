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
    public class ItemService : IItem
    {
        private readonly IndianWebTradeDataBaseContext _dbContext;
        public ItemService(IndianWebTradeDataBaseContext dBContext)
        {
            _dbContext = dBContext;
        }
        public IGernalResult AddItem(ItemDto dto)
        {
            throw new NotImplementedException();
        }

        public IGernalResult DelteItem(int id)
        {
            IGernalResult result = new GernalResult();
            try
            {
                result = getItem(id);
                TblItem item = _dbContext.TblItem.Where(w => w.Id == id).FirstOrDefault();
                item.IsDelete = true;
                int delete = _dbContext.SaveChanges();
                result.Succsefully = delete > 0 ? true : false;
                result.Message = delete > 0 ? "Item deleted Succsefully" : "Item not delet.";

            }
            catch
            {
                result.Succsefully = false;
                result.Message = "Server error";
            }
            return result;
        }

        public IGernalResult EditItem(ItemDto dto)
        {
            throw new NotImplementedException();
        }

        public IGernalResult getAllItem()
        {
            IGernalResult result = new GernalResult();
            try
            {
                List<ItemDto> items = new List<ItemDto>();
                items = _dbContext.TblItem.Select(s => new ItemDto
                {
                    Name = s.Name,
                    CatogeryId = s.CategoryId,
                    Discription = s.Discription,
                    Id = s.Id,
                    ImageUrl = _dbContext.TblItemImage.Where(w => w.ItemId == s.Id).Select(s => s.ImageUrl).ToList(),
                    ItemId = s.ItemId,
                    Price = s.Price,
                    Quantity = s.Quantity,
                    SellerId = Convert.ToString(s.SellerId),
                }).Where(w => w.IsDelete == false).ToList();
                result.Succsefully = true;
                result.value = items;
                result.Message = Convert.ToString(items.Count);
            }
            catch
            {
                result.Succsefully = false;
                result.Message = "Server error";
            }
            return result;
        }

        public IGernalResult getItem(int id)
        {
            IGernalResult result = new GernalResult();
            try
            {
                ItemDto item = new ItemDto();
                item = _dbContext.TblItem.Select(s => new ItemDto
                {
                    Name = s.Name,
                    CatogeryId = s.CategoryId,
                    Discription = s.Discription,
                    Id = s.Id,
                    ImageUrl = _dbContext.TblItemImage.Where(w => w.ItemId == id).Select(s => s.ImageUrl).ToList(),
                    ItemId = s.ItemId,
                    Price = s.Price,
                    Quantity = s.Quantity,
                    SellerId = Convert.ToString(s.SellerId),
                }).Where(w => w.Id == id).FirstOrDefault();

                result.Succsefully = true;
                result.value = item;
            }
            catch
            {
                result.Succsefully = false;
                result.Message = "Server error";
            }
            return result;
        }
    }
}
