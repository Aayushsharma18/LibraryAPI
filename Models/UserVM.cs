using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace LibraryAPI.Models
{
    public class UserVM
    {
        [StringLength(20)]
        public string UserName { get; set; } = null!;
        public int BookId { get; set; }
        [EmailAddress]
        public string Email { get; set; } = null!;
        [PasswordPropertyText]
        public string Password { get; set; } = null!;
    }
}