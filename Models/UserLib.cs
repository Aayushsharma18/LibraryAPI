using System;
using System.Collections.Generic;

// #nullable disable
namespace LibraryAPI.Models
{
    public partial class UserLib
    {
        public UserLib()
        {
            BorrowedBooks = new HashSet<BorrowedBook>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public int BookId { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual Book? Book { get; set; } = null!;
        public virtual ICollection<BorrowedBook>? BorrowedBooks { get; set; }
    }
}
