using Laborator4.Data;
using Laborator4.Models;
using Laborator4.Repositories.GenericReporitory;

namespace Laborator4.Repositories.StudentRepository
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(Lab4Context lab4Context) : base(lab4Context)
        {

        }
    }
}
