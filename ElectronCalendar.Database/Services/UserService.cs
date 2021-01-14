using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using ElectronCalendar.Database.Data;
using ElectronCalendar.Database.Entities;
using ElectronCalendar.Database.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace ElectronCalendar.Database.Services
{
    public class UserService : BaseService
    {
        public UserService(DatabaseContext dbContext) : base(dbContext)
        {
        }


        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyHash(string password, string userHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, userHash);
        }

        public async Task<ClaimsPrincipal> Login(string username, string password)
        {
            var userByName = await DbContext.Users
                .FirstOrDefaultAsync(x => x.Username == username);

            if (userByName == null)
                return null;

            if (!VerifyHash(password, userByName.Password))
            {
                return null;
            }

            return GetSessionClaims(userByName);
        }


        private ClaimsPrincipal GetSessionClaims(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Sid, user.Id.ToString()),
            };

            var claimsIdentity = new ClaimsIdentity(claims, "Login");
            return new ClaimsPrincipal(claimsIdentity);
        }
    }
}