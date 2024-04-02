using System;
using System.Collections.Generic;

// #nullable disable
namespace LibraryAPI.Models
{
    public partial class Book
    {
        public Book()
        {
            BorrowedBooks = new HashSet<BorrowedBook>();
            UserLibs = new HashSet<UserLib>();
        }

        public int BookId { get; set; }
        public string Title { get; set; } = null!;
        public string Isbn { get; set; } = null!;
        public string Image { get; set; } = null!;

        public virtual ICollection<BorrowedBook>? BorrowedBooks { get; set; }
        public virtual ICollection<UserLib>? UserLibs { get; set; }
    }
}
