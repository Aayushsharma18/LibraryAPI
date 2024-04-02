using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryAPI.Helper.Interface;
using LibraryAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BookController : ControllerBase
    {
        private readonly LibrarysContext _context;
        private readonly IJwtAuthentication _authentication;

        public BookController(LibrarysContext context, IJwtAuthentication authentication)
        {
            _context = context;
            _authentication = authentication;
        }

        [HttpGet("GetAllBooks")]
        public IEnumerable<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }

        [HttpGet("GetBookById")]
        public Book GetBookById(int id)
        {
            return _context.Books.Find(id) ?? throw new Exception("Book not found");
        }

        [HttpPost("AddBook")]
        public string AddBook(Book Book)
        {
            _context.Add(Book);
            _context.SaveChanges();
            return "Book added succcessdully";
        }

        [HttpPut("UpdateBook")]
        public string UpdateBook(Book Book)
        {
            var existing = _context.Books.Find(Book.BookId);
            if (existing == null) throw new Exception("cannot update empty Book.");

            existing.Title = Book.Title;
            existing.Isbn = Book.Title;

            _context.Entry(existing).State = EntityState.Modified;
            _context.SaveChanges();

            return "Book data updated successfully";
        }

        [HttpDelete("DeleteBook")]
        public string DeleteBook(Book Book)
        {
            var existing = _context.Books.Find(Book.BookId);
            if (existing == null) throw new Exception("No Book found!");

            _context.Remove(existing);
            _context.SaveChanges();
            return "Book Deleted";
        }
    }
}