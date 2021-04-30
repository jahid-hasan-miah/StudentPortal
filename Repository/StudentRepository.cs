using Microsoft.EntityFrameworkCore;
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
        private readonly StudentContext _context = null;
        public StudentRepository(StudentContext context)
        {
            _context = context;
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
            await _context.StudentInfo.AddAsync(student);
            await _context.SaveChangesAsync();

            return student.Id;
        }

        public async Task<List<StudentModel>> GetAllStudent()
        {
            var studentInfo = new List<StudentModel>();
            var student =await _context.StudentInfo.ToListAsync();
            if(student!=null)
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
        public async Task<StudentModel> GetStudentById(int ID)
        {
            var data = await _context.StudentInfo.FindAsync(ID);
            if(data!= null)
            {
                var studentInformation = new StudentModel()
                {
                    Id = data.Id,
                    Name = data.Name,
                    Group = data.Group,
                    Roll = data.Roll,
                    ProfilePicUri = data.ProfilePicUri
                };
                return studentInformation;
            }
            return null;
        }
    }
}
