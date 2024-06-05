using BusinessObject.Models;
using DataAccess.Repositories.Interfaces;

namespace DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Prn231Su23StudentGroupDbContext _dbContext;
        public UserRepository(Prn231Su23StudentGroupDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public UserRole GetUser(string username, string password)
        {
            return _dbContext.UserRoles.FirstOrDefault(x => x.Username == username && x.Passphrase == password);
        }
    }
}
