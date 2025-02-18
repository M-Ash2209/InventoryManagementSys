using AuthService.Model;

namespace Auth.Domain.Interfaces
{
    public interface IRegisterInterface
    {
        Task<int> RegisterAsync(SignUp signUp,CancellationToken cancellationToken);
    }
}
