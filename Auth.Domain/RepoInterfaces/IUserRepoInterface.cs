using AuthService.Model;

namespace Auth.Domain.RepoInterfaces
{
    public interface IUserRepoInterface
    {
        Task<SignUp> GetUserAsync(int Id);
    }
}
