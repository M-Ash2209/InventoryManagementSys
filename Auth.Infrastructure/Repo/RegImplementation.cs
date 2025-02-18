using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auth.Domain.Interfaces;
using AuthService.Model;
using CrudApp.Data;

namespace Auth.Infrastructure.Repo
{
    public class RegImplementation : IRegisterInterface
    {
        private readonly AppDbContext _appDbContext;
        public RegImplementation(AppDbContext dbContext)
        {
            _appDbContext = dbContext;
        }

        public async Task<int> RegisterAsync(SignUp signUp, CancellationToken cancellationToken)
        {
            _appDbContext.SignUp.Add(signUp);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return signUp.Id;
        }
    }
}
