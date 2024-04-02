using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Helper.Interface
{
    public interface IJwtAuthentication
    {
        Task<string> GenerateToken(UserLib _userData);
        Task<UserLib> GetUser(string email, string password);
    }
}