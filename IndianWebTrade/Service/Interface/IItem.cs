using INFASTRUCTURE.Dto;
using INFASTRUCTURE.GernalResult;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interface
{
    public interface IItem
    {
        List<ItemDto> getAllItem();
        IGernalResult getItem(int id);

        IGernalResult AddItem(ItemDto dto);
        IGernalResult EditItem(ItemDto dto);
        IGernalResult DelteItem(int id);

        CartDto AddTocart(CartDto CartDto);
        List<CartDto> GetUsercartById(int userId);

        bool RemoveFromCart(int cartId, int userId);
        bool EditFromCart(int cartId, int Countity);

    }
}
