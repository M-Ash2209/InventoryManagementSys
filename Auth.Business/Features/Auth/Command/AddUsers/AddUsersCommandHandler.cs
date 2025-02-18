using Auth.Business.Features.Auth.Command.AddUsers;
using Auth.Domain.Interfaces;
using AuthService.Model;
using MediatR;


namespace CrudApp.Features.Auth.Command.AddUsers
{
    public class AddUsersCommandHandler : IRequestHandler<AddUsersCommand, int>
    {
        private readonly IRegisterInterface _res;
        public AddUsersCommandHandler(IRegisterInterface res)
        {
            _res = res;
        }
        public async Task<int> Handle(AddUsersCommand request, CancellationToken cancellationToken)
        {
            var user = new SignUp
            {
                Username = request.Username,
                Email = request.Email,
                Password = request.Password
            };

            return await _res.RegisterAsync(user,cancellationToken);  
        }
    }
}
