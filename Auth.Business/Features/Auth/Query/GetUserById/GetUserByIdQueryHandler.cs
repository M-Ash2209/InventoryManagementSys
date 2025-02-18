using System.Text;
using Auth.Domain.RepoInterfaces;
using AuthService.Model;
using CrudApp.Data;
using MediatR;

namespace CrudApp.Features.Auth.Query.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, SignUp>
    {

        private readonly IUserRepoInterface _getUser;
        public GetUserByIdQueryHandler(IUserRepoInterface getUser )
        {
            _getUser = getUser;
        }
        public async Task<SignUp> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            //var user = await _context.SignUp.FindAsync(request.Id);
            ////user.Password = Encoding.UTF8.GetString(Convert.FromBase64String(user.Password));
            return await _getUser.GetUserAsync(request.Id);
        }
    }
}
