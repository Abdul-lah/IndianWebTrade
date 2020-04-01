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
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string ImageUrl { get; set; }
        [Required]
        public string Address { get; set; }

        public int? Role { get; set; }
    }
}
