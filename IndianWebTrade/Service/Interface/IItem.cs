using INFASTRUCTURE.Dto;
using INFASTRUCTURE.GernalResult;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interface
{
    public interface IItem
    {
        bool IsAvilableItem(int cartId, int Countity, int itemid);
        List<ItemDto> getAllItem();
        IGernalResult getItem(int id);

        IGernalResult AddItem(ItemDto dto);
        IGernalResult EditItem(ItemDto dto);
        IGernalResult DelteItem(int id);

        CartDto AddTocart(CartDto CartDto);
        List<CartDto> GetUsercartById(int userId);

        bool RemoveFromCart(int cartId, int userId);
        IGernalResult EditFromCart(int cartId, int Countity);

        IGernalResult AddOrder(OrderDto dto);
        IGernalResult CancelOrder(int orderId);

    }
}
