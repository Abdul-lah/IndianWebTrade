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
        public int? Role { get; set; }
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
        public string Quantity { get; set; }
        public string Price { get; set; }
        public int? CatogeryId { get; set; }
        public bool? IsDelete { get; set; }
        public string Discription { get; set; }
        public List<string> ImageUrl { get; set; }
    }
}
