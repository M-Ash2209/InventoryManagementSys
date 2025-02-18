using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auth.Domain.RepoInterfaces;
using AuthService.Model;
using CrudApp.Data;
using Microsoft.EntityFrameworkCore;

namespace Auth.Infrastructure.Repo
{
    public class GetUserImplementation : IUserRepoInterface
    {
        private readonly AppDbContext _appDbContext;
        public GetUserImplementation(AppDbContext dbContext)
        {
            _appDbContext = dbContext;
        }
        public async Task<SignUp> GetUserAsync(int Id)
        {
            var user = await _appDbContext.SignUp.FindAsync(Id);
            //user.Password = Encoding.UTF8.GetString(Convert.FromBase64String(user.Password));
            return user;
        }
    }
}
