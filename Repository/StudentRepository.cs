using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Student_Portal.Data;
using Student_Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Portal.Repository
{
    public class StudentRepository
    {
        private readonly DbContextOptionsBuilder<StudentContext> optionsBuilder = null;

        public StudentRepository(IConfiguration configuration)
        {
            this.optionsBuilder = new DbContextOptionsBuilder<StudentContext>()
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        }

        public async Task<int> AddNewStudent(StudentModel model)
        {
            var student = new Student()
            {
                Name = model.Name,
                Group = model.Group,
                Roll = model.Roll,
                ProfilePicUri = model.ProfilePicUri
            };
            using (var db = new StudentContext(this.optionsBuilder.Options))
            {
                await db.StudentInfo.AddAsync(student);
                await db.SaveChangesAsync();
            }
            return student.Id;
        }

        public async Task<List<StudentModel>> GetAllStudent()
        {
            var studentInfo = new List<StudentModel>();
            List<Student> student = new List<Student>();

            using (var db = new StudentContext(this.optionsBuilder.Options))
            {
                student = await db.StudentInfo.ToListAsync();
            }
            if (student!=null)
            {
                foreach(var studens in student)
                {
                    studentInfo.Add(new StudentModel()
                    {
                        Roll=studens.Roll,
                        Name=studens.Name,
                        ProfilePicUri=studens.ProfilePicUri,
                        Group=studens.Group,
                    });      
                }
            }
            return studentInfo;
        }

        public List<Student> GetStudent()
        {
            
            List<Student> student = new List<Student>();

            using (var db = new StudentContext(this.optionsBuilder.Options))
            {
                student = db.StudentInfo.ToList();
            }
            return student;
        }

        //public async Task<StudentModel> GetStudentById(int ID)
        //{
        //    var data = await _context.StudentInfo.FindAsync(ID);
        //    if(data!= null)
        //    {
        //        var studentInformation = new StudentModel()
        //        {
        //            Id = data.Id,
        //            Name = data.Name,
        //            Group = data.Group,
        //            Roll = data.Roll,
        //            ProfilePicUri = data.ProfilePicUri
        //        };
        //        return studentInformation;
        //    }
        //    return null;
        //}
    }
}
