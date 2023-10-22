using Laborator2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;

namespace Laborator2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : Controller
    {
        // Cream o clasa Student cu proprietatile
        // nume, prenume, an, specializare
        // Cream o lista cu studenti (5)
        // Metode pentru get, add, put, delete
        public static List<Student> students = new List<Student>()
        {
            new Student()
            {
                ID = 1,
                Name = "John",
                Prenume = "Doe",
                An = 2,
                Specializare = "CS"
            },
            new Student()
            {
                ID = 2,
                Name = "Dan",
                Prenume = "Nuca",
                An = 2,
                Specializare = "Java"
            },
            new Student() 
            {
                ID = 3,
                Name = "Marina",
                Prenume = "Bard",
                An = 1,
                Specializare = "CS"
            },
            new Student()
            {
                ID = 4,
                Name = "Laurentiu",
                Prenume = "Lucraru",
                An = 3,
                Specializare = "C++"
            },
            new Student()
            {
                ID = 5,
                Name = "Marc",
                Prenume = "Capon",
                An = 4,
                Specializare = "C"
            }
        };

        [HttpGet]
        public List<Student> Get() 
        {
            return students; 
        }

        [HttpPost]
        public List<Student> Post(Student student)
        {
            students.Add(student);
            return students;
        }

        [HttpPut]
        public string Put(int id, string newName, string newLastName) 
        {
            int cnt = 0;
            for(int i = 0; i < students.Count; i++)
            {
                if (students[i].ID == id)
                {
                    students[i].Name = newName;
                    students[i].Prenume = newLastName;
                    cnt++;      
                }
            }
            if(cnt == 0)
            {
                return "Student not found";
            }
            return "Succes";
        }

        [HttpDelete]
        public string Delete(int id)
        {
            int cnt = 0;
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].ID == id)
                {
                    students.Remove(students[i]);
                    cnt++;
                }
            }
            if (cnt == 0)
            {
                return "Student not found";
            }
            return "Succes";
        }

    }
}
