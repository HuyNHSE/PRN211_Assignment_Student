using BusinessObject.Models;

namespace DataAccess.Repositories.Interfaces
{
    public interface IStudentGroupRepository
    {
        IEnumerable<StudentGroup> GetGroups();
    }
}
