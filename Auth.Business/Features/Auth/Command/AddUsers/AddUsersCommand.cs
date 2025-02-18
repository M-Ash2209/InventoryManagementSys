using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Auth.Business.Features.Auth.Command.AddUsers
{
    public class AddUsersCommand : IRequest<int>
    {
        public string Username { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
