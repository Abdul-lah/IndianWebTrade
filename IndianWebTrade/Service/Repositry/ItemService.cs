using DAL.IndianTradeDb;
using INFASTRUCTURE.Dto;
using INFASTRUCTURE.GernalResult;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Service.Repositry
{
    public class ItemService : IItem
    {
        private readonly IndianWebTradeDataBaseContext _dbContext;
        public ItemService(IndianWebTradeDataBaseContext dBContext)
        {
            _dbContext = dBContext;
        }
        public IGernalResult AddItem(ItemDto s)
        {
            IGernalResult result = new GernalResult();
            try
            {
                TblItem item = new TblItem
                {
                    Name = s.Name,
                    CategoryId = s.CatogeryId,
                    Discription = s.Discription,
                    ImageUrl = s.Image,
                    Price = s.Price,
                    Quantity = s.Quantity,
                    SellerId = Convert.ToInt32(s.SellerId),
                    CreatedDate = DateTime.UtcNow,
                    IsAvailable = true,
                    IsDelete = false
                };

                _dbContext.Add(item);
                int save = _dbContext.SaveChanges();
                result.Succsefully = save > 0 ? true : false;
                result.Message = save > 0 ? "Selling Item add Succsefully" : "Selling Item not register";

            }
            catch(Exception ex)
            {
                result.Succsefully = false;
                result.Message = "Server error";
            }
            return result;
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
            IGernalResult result = new GernalResult();
            TblItem item = _dbContext.TblItem.Where(w => w.Id == dto.Id).FirstOrDefault();

            item.Name = dto.Name;
            item.CategoryId = dto.CatogeryId;
            item.Discription = dto.Discription;
            item.ImageUrl = dto.Image;
            item.Price = dto.Price;
            item.Quantity = dto.Quantity;



            int save = _dbContext.SaveChanges();
            result.Succsefully = save > 0 ? true : false;
            result.Message = save > 0 ? "Selling Item edit Succsefully" : "Selling Item not edit";
            return result;
        }

        public List<ItemDto> getAllItem()
        {
            List<ItemDto> items = new List<ItemDto>();
            IGernalResult result = new GernalResult();
            try
            {

                items = _dbContext.TblItem.Select(s => new ItemDto
                {
                    Name = s.Name,
                    CatogeryId = s.CategoryId ?? 0,
                    Discription = s.Discription,
                    Id = s.Id,
                    // ImageUrl = _dbContext.TblItemImage.Where(w => w.ItemId == s.Id).Select(s => s.ImageUrl).ToList(),
                    Image = s.ImageUrl,
                    Price = s.Price,
                    Quantity = s.Quantity,
                    SellerId = Convert.ToString(s.SellerId),
                    SellerName = _dbContext.TblUser.Where(w => w.Id == s.SellerId).Select(s => s.Name).FirstOrDefault(),
                }).ToList();
                result.Succsefully = true;
                result.value = items;
                result.Message = Convert.ToString(items.Count);
            }
            catch
            {
                result.Succsefully = false;
                result.Message = "Server error";
            }
            return items;
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
                    CatogeryId = s.CategoryId ?? 0,
                    Discription = s.Discription,
                    Id = s.Id,
                    //ImageUrl = _dbContext.TblItemImage.Where(w => w.ItemId == id).Select(s => s.ImageUrl).ToList(),
                    Image = s.ImageUrl,
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

        public CartDto AddTocart(CartDto dto)
        {

            try
            {
                TblCart cart = new TblCart
                {
                    ItemId = dto.ItemId,
                    PricePerItem = Convert.ToString(dto.PricePerItem),
                    TotalPrice = Convert.ToString(Convert.ToInt32(dto.PricePerItem) * dto.Quantity),
                    UserId = dto.UserId,
                    Quantity = dto.Quantity,
                    CreatedDate = DateTime.UtcNow,
                };
                _dbContext.Add(cart);
                int save = _dbContext.SaveChanges();
                dto.Id = cart.Id;
            }
            catch
            {
                throw;
            }


            return dto;
        }

        public List<CartDto> GetUsercartById(int userId)
        {

            try
            {
                var data = _dbContext.TblCart.Include(i => i.Item).Where(w => w.UserId == userId).ToList();
                //  return _dbContext.TblCart.Select(s => new CartDto
                return data.Select(s => new CartDto
                {
                    Id = s.Id,
                    ItemId = s.ItemId,
                    ItemName = _dbContext.TblItem.Where(w => w.Id == s.ItemId).Select(s => s.Name).FirstOrDefault(),
                    PricePerItem = Convert.ToInt32(s.PricePerItem),
                    TotalPrice = s.TotalPrice,
                    Quantity = s.Quantity,
                    ImageUrl = s.Item.ImageUrl,
                    Discription = s.Item.Discription
                }).ToList();
            }
            catch
            {
                throw;
            }
        }
        public bool RemoveFromCart(int cartId, int userId)
        {
            try
            {

                TblCart cart = _dbContext.TblCart.Where(w => w.Id == cartId && w.UserId == userId).FirstOrDefault();
                if (cart != null)
                {
                    _dbContext.Remove(cart);
                    _dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                throw;
            }
        }
        public bool IsAvilableItem(int cartId, int Countity, int itemid)
        {
            bool avilable = false;
            TblCart cart = new TblCart();
            if (cartId > 0)
            {
                cart = _dbContext.TblCart.Where(w => w.Id == cartId).FirstOrDefault();
            }
            else
            {
                cart = _dbContext.TblCart.Where(w => w.ItemId == itemid).FirstOrDefault();
            }
            try
            {
                int totalplaceOrderquantiy = 0;

                TblItem Item = _dbContext.TblItem.Where(w => w.Id == cart.ItemId).FirstOrDefault();
                List<TblOrder> order = _dbContext.TblOrder.Where(w => w.ItemId == cart.ItemId && w.IsCanceled == false).ToList();
                if (order != null)
                {
                    foreach (var item in order)
                    {
                        int v = item.Quantity + totalplaceOrderquantiy;
                        totalplaceOrderquantiy = v;
                    }
                }
                int avilableNow = Convert.ToInt32(Item.Quantity) - totalplaceOrderquantiy;
                if (totalplaceOrderquantiy == Convert.ToInt32(Item.Quantity))
                {
                    avilable = false;
                }
                else if (avilableNow < Countity)
                {
                    avilable = true;
                }
                return avilable;
            }
            catch
            {
                throw;
            }
        }
        public IGernalResult EditFromCart(int cartId, int Countity)
        {
            IGernalResult result = new GernalResult();
            TblCart cart = _dbContext.TblCart.Where(w => w.Id == cartId).FirstOrDefault();
            try
            {
                int totalplaceOrderquantiy = 0;

                TblItem Item = _dbContext.TblItem.Where(w => w.Id == cart.ItemId).FirstOrDefault();
                List<TblOrder> order = _dbContext.TblOrder.Where(w => w.ItemId == cart.ItemId && w.IsCanceled == false).ToList();
                if (order != null)
                {
                    foreach (var item in order)
                    {
                        int v = item.Quantity + totalplaceOrderquantiy;
                        totalplaceOrderquantiy = v;
                    }
                }
                int avilableNow = Convert.ToInt32(Item.Quantity) - totalplaceOrderquantiy;
                if (totalplaceOrderquantiy == Convert.ToInt32(Item.Quantity))
                {
                    result.Succsefully = false;
                    result.Message = "Item not availablenow plz try some time later.";
                }
                else if (avilableNow < Countity)
                {
                    result.Succsefully = false;
                    result.Message = "Now we have avilable only" + avilableNow;
                }
                else
                {
                    int total = Convert.ToInt32(cart.PricePerItem) * Countity;



                    cart.TotalPrice = Convert.ToString(total);
                    cart.Quantity = Countity;
                    int save = _dbContext.SaveChanges();
                    result.Succsefully = save > 0 ? true : false;
                }
            }
            catch
            {
                result.Succsefully = false;
                result.Message = "server error.";

            }
            return result;
        }

        public IGernalResult AddOrder(OrderDto dto)
        {
            IGernalResult result = new GernalResult();
            try
            {
                int totalplaceOrderquantiy = 0;

                TblItem Item = _dbContext.TblItem.Where(w => w.Id == dto.ItemId).FirstOrDefault();
                List<TblOrder> order = _dbContext.TblOrder.Where(w => w.ItemId == dto.ItemId && w.IsCanceled == false).ToList();
                if (order != null)
                {
                    foreach (var item in order)
                    {
                        int v = item.Quantity + totalplaceOrderquantiy;
                        totalplaceOrderquantiy = v;
                    }
                }
                int avilableNow = Convert.ToInt32(Item.Quantity) - totalplaceOrderquantiy;
                if (totalplaceOrderquantiy == Convert.ToInt32(Item.Quantity))
                {
                    result.Succsefully = false;
                    result.Message = "Item not availablenow plz try some time later.";
                }
                else if (avilableNow < dto.Quantity)
                {
                    result.Succsefully = false;
                    result.Message = "Now we have avilable only" + avilableNow;
                }
                else
                {
                    TblOrder Order = new TblOrder
                    {
                        IsCanceled = false,
                        OrderDate = DateTime.UtcNow,
                        UserId = dto.UserId,
                        ItemId = dto.ItemId,
                        PricePerItem = Convert.ToInt32(Item.Price),
                        PriceTotal = Convert.ToInt32(Item.Price) * dto.Quantity,
                    };
                    _dbContext.Add(Order);
                    int save = _dbContext.SaveChanges();
                    result.Message = save > 0 ? "Order add Succsefully" : "Order not add";
                    result.Succsefully = save > 0 ? true : false;
                }
            }
            catch
            {
                result.Message = "server error";
                result.Succsefully = false;
            }
            return result;
        }

        public IGernalResult CancelOrder(int orderId)
        {
            IGernalResult result = new GernalResult();
            try
            {

                TblOrder order = _dbContext.TblOrder.Where(w => w.Id == orderId).FirstOrDefault();
                order.IsCanceled = true;
                int save = _dbContext.SaveChanges();
                result.Message = save > 0 ? "Order cancel Succsefully" : "Order not cancel";
                result.Succsefully = save > 0 ? true : false;

            }
            catch
            {
                result.Message = "server error";
                result.Succsefully = false;
            }
            return result;
        }
    }
}
