using BusinessObject.Models;

namespace DataAccess.Repositories.Interfaces
{
    public interface IUserRepository
    {
        UserRole GetUser(string username, string password);
    }
}
