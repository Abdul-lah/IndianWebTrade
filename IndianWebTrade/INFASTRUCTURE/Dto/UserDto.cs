using System;
using System.Collections.Generic;
using System.Text;

namespace INFASTRUCTURE.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ImageUrl { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
        public int RoleId { get; set; }

        public string MobileNo { get; set; }
        public bool? IsSeller { get; set; }
    }
    public class UserRoleDto
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
    public class ItemDto
    {
        public int Id { get; set; }
        public string ItemId { get; set; }
        public string Name { get; set; }
        public string SellerId { get; set; }
        public string SellerName { get; set; }
        public string Quantity { get; set; }
        public string Price { get; set; }
        public int CatogeryId { get; set; }
        public bool IsDelete { get; set; }
        public string Discription { get; set; }
        //   public List<string> ImageUrl { get; set; }
        public string Image { get; set; }
    }
    public class CategoryDto
    {
        public int Id { get; set; }
        public string CatogeryName { get; set; }
    }
    public class CartDto
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public int PricePerItem { get; set; }
        public string TotalPrice { get; set; }
        public string ImageUrl { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
