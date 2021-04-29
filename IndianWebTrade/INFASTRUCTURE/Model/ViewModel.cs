using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;

namespace INFASTRUCTURE.Model
{
    public class UserViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Name")]
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "MobileNo")]
        public string MobileNo { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }
        //public string ImageUrl { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "OTP")]
        public string Otp { get; set; }

        //public int? Role { get; set; }

        //public IFormFile ProfileImage { get; set; }
    }
    public class ProductItemViewModel
    {
        //public int Id { get; set; }
        //public string ItemId { get; set; }
        [Display(Name = "Name")]
        [Required]
        public string Name { get; set; }

        //public string SellerId { get; set; }
        [Display(Name = "Quantity")]
        [Required]
        public string Quantity { get; set; }
        [Display(Name = "Price")]
        [Required]
        public string Price { get; set; }
        
        public int CatogeryId { get; set; }
        [Display(Name = "Discription")]
        [Required]

        public string Discription { get; set; }
        public IFormFile Image { get; set; }
    }
}
