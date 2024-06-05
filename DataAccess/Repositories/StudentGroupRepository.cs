using BusinessObject.Models;
using DataAccess.Repositories.Interfaces;

namespace DataAccess.Repositories
{
    public class StudentGroupRepository : IStudentGroupRepository
    {
        private readonly Prn231Su23StudentGroupDbContext _dbContext;
        public StudentGroupRepository(Prn231Su23StudentGroupDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<StudentGroup> GetGroups() => _dbContext.StudentGroups.ToList();
    }
}
