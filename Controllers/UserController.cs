using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryAPI.Helper.Interface;
using LibraryAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly LibrarysContext _context;
        private readonly IJwtAuthentication _authentication;

        public UserController(LibrarysContext context, IJwtAuthentication authentication)
        {
            _context = context;
            _authentication = authentication;
        }

        [HttpPost("UserLogin")]
        public async Task<string> Login(string email, string password)
        {
            UserLib user = new UserLib();
            user.Email = email;
            user.Password = password;

            var token = await _authentication.GenerateToken(user);
            return token;
        }

        [HttpGet("GetAllUsers")]
        public IEnumerable<UserLib> GetAllUsers()
        {
            return _context.UserLibs.ToList();
        }

        [HttpGet("GetUserById")]
        public UserLib GetUserById(int id)
        {
            var userById = _context.UserLibs.Find(id) ?? throw new Exception("User not found");
            return userById;
        }

        [HttpPost("AddUser")]
        public string AddUser(UserVM userLib)
        {
            var user = new UserLib()
            {
                UserName = userLib.UserName,
                BookId = userLib.BookId,
                Email = userLib.Email,
                Password = userLib.Password
            };

            _context.Add(user);
            _context.SaveChanges();
            return "User added succcessdully";
        }

        [HttpPut("UpdateUser")]
        public string UpdateUser(UserLib userLib)
        {
            var existing = _context.UserLibs.Find(userLib.UserId);
            if (existing == null) throw new Exception("cannot update empty user.");

            existing.BookId = userLib.BookId;
            existing.UserName = userLib.UserName;

            _context.Entry(existing).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return "User data updated successfully";
        }

        [HttpDelete("DeleteUser")]
        public string DeleteUser(UserLib userLib)
        {
            var existing = _context.UserLibs.Find(userLib.UserId);
            if (existing == null) throw new Exception("No user found!");

            _context.Remove(existing);
            _context.SaveChanges();
            return "User Deleted";
        }

    }
}