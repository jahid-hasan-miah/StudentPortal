using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Student_Portal.Models;
using Student_Portal.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace Student_Portal.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentRepository _studentRepository = null;
        private readonly IWebHostEnvironment _webHostEnvironment = null;
        public StudentController(StudentRepository studentRepository,IWebHostEnvironment webHostEnvironment)
        {
            _studentRepository = studentRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> GetAllStudent()
        {
            var student = await _studentRepository.GetAllStudent();
            return View(student);
        }

        public async Task<IActionResult> StudentById(int id)
        {
            var ParticularStudent = await _studentRepository.GetStudentById(id);
            return View(ParticularStudent);
        }

        public IActionResult AddNewStudent(bool isSuccess = false)
        {
            ViewBag.IsSuccess = isSuccess;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddNewStudent(StudentModel studentModel)
        {
            if(ModelState.IsValid)
            {
               if(studentModel.ProfileImage != null)
               {
                   string path = "Student/Profilepic/";
                   path += Guid.NewGuid() + studentModel.ProfileImage.FileName;
                   studentModel.ProfilePicUri = "/" + path;
                   string serverfolder = Path.Combine(_webHostEnvironment.WebRootPath, path);
                   await studentModel.ProfileImage.CopyToAsync(new FileStream(serverfolder, FileMode.Create));
               }
               int id = await _studentRepository.AddNewStudent(studentModel);
               if (id>0)
               {
                   return RedirectToAction(nameof(AddNewStudent),new { isSuccess = true});
               }
            }
            return View();
        }
    }
}
