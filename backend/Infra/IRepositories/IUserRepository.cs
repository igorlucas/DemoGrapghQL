using Domain.Entities;

namespace Infra.IRepositories
{
    public interface IUserRepository
    {
        string Authenticate(string email, string password);
        User Find(string email, string password);
        bool CheckToken(string token);
        User Create(User user);
    }
}
