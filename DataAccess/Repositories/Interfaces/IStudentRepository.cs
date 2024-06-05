using BusinessObject.Models;
using BusinessObject.ViewModels;

namespace DataAccess.Repositories.Interfaces
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetStudents();
        IEnumerable<StudentDetails> GetStudentDetails();
        IEnumerable<StudentDetails> GetStudentsByName(string name);
        IEnumerable<StudentDetails> GetStudentByEmail(string email);
        IEnumerable<StudentDetails> GetStudentsByGroupName(string group);
        Student GetStudentById(int id);
        void AddStudent(Student student);
        void UpdateStudent(Student student);
        void DeleteStudent(int id);
    }
}
