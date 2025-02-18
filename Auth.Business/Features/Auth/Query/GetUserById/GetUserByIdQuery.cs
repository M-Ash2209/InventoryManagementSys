using System.ComponentModel.DataAnnotations;
using AuthService.Model;
using MediatR;

namespace CrudApp.Features.Auth.Query.GetUserById
{
    public record GetUserByIdQuery(int Id) : IRequest<SignUp>{
       
    }

}
