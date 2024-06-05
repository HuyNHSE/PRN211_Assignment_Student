using BusinessObject.Models;
using BusinessObject.ViewModels;
using DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly Prn231Su23StudentGroupDbContext _dbContext;
        public StudentRepository(Prn231Su23StudentGroupDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddStudent(Student student)
        {
            _dbContext.Students.Add(student);
            _dbContext.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
            var student = GetStudentById(id);
            if (student != null)
            {
                _dbContext.Students.Remove(student);
                _dbContext.SaveChanges();
            }
        }

        public IEnumerable<StudentDetails> GetStudentByEmail(string email)
        {
            var students = _dbContext.Students
                                .Include(s => s.Group)
                                .Where(s => s.Email.Equals(email))
                                .Select(s => new StudentDetails
                                {
                                    Id = s.Id,
                                    FullName = s.FullName,
                                    Email = s.Email,
                                    DateOfBirth = s.DateOfBirth,
                                    GroupName = s.Group.GroupName
                                })
                                .ToList();
            return students;
        }

        public Student GetStudentById(int id) => _dbContext.Students.SingleOrDefault(x => x.Id == id);

        public IEnumerable<StudentDetails> GetStudentDetails()
        {
            var students = _dbContext.Students
                             .Include(s => s.Group)
                             .Select(s => new StudentDetails
                             {
                                 Id = s.Id,
                                 FullName = s.FullName,
                                 Email = s.Email,
                                 //GroupId = s.GroupId,
                                 DateOfBirth = s.DateOfBirth,
                                 GroupName = s.Group.GroupName
                             })
                             .ToList();
            return students;
        }

        public IEnumerable<Student> GetStudents() => _dbContext.Students.Include(x => x.Group.GroupName).ToList();

        public IEnumerable<StudentDetails> GetStudentsByGroupName(string group)
        {
            var students = _dbContext.Students
                                .Where(x => x.Group.GroupName.Contains(group))
                                .Include(x => x.Group)
                                .Select(x => new StudentDetails
                                {
                                    Id = x.Id,
                                    FullName = x.FullName,
                                    Email = x.Email,
                                    //GroupId= x.GroupId,
                                    DateOfBirth = x.DateOfBirth,
                                    GroupName = x.Group.GroupName
                                })
                                .ToList();
            return students;
        }

        public IEnumerable<StudentDetails> GetStudentsByName(string name)
        {
            var students = _dbContext.Students
                                .Where(x => x.FullName.Contains(name))
                                .Include(x => x.Group)
                                .Select(x => new StudentDetails
                                {
                                    Id = x.Id,
                                    FullName = x.FullName,
                                    Email = x.Email,
                                    //GroupId= x.GroupId,
                                    DateOfBirth = x.DateOfBirth,
                                    GroupName = x.Group.GroupName
                                })
                                .ToList();
            return students;
        }

        public void UpdateStudent(Student student)
        {
            _dbContext.Students.Update(student);
            _dbContext.SaveChanges();
        }
    }
}
