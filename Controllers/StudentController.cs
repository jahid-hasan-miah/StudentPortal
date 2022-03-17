using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Student_Portal.Models;
using Student_Portal.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Diagnostics;

namespace Student_Portal.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentRepository _studentRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public StudentController(StudentRepository studentRepository,IWebHostEnvironment webHostEnvironment)
        {
            _studentRepository = studentRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> GetAllStudent()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            var student = _studentRepository.GetAllStudent();
            var task = _studentRepository.GetAllStudent();
            var task1 = _studentRepository.GetAllStudent();
            var task2 = _studentRepository.GetAllStudent();
            var task3 = _studentRepository.GetAllStudent();
            var task4 = _studentRepository.GetAllStudent();
            var task5 = _studentRepository.GetAllStudent();
            var task6 = _studentRepository.GetAllStudent();
            var task7= _studentRepository.GetAllStudent();
            var task8 = _studentRepository.GetAllStudent();
            var task9 = _studentRepository.GetAllStudent();
            var task10 = _studentRepository.GetAllStudent();
            var task11 = _studentRepository.GetAllStudent();
            var task12 = _studentRepository.GetAllStudent();
            var task13 = _studentRepository.GetAllStudent();
            var task14 = _studentRepository.GetAllStudent();
            var task15 = _studentRepository.GetAllStudent();
            var task16 = _studentRepository.GetAllStudent();
            var task17 = _studentRepository.GetAllStudent();
            var task18 = _studentRepository.GetAllStudent();
            var task19 = _studentRepository.GetAllStudent();
            var task20 = _studentRepository.GetAllStudent();
            var task21 = _studentRepository.GetAllStudent();
            await Task.WhenAll(task1, task2, task3, task4, task5, task6, task7, task8, task9, task10, task11, task12, task13, task14,task15,task16,task17,task18,task19,task20,task21,task,student);
            stopWatch.Stop();
            var t = stopWatch.ElapsedMilliseconds;

            return View(student.Result);
            
        }

        public void Student()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            _studentRepository.GetStudent();
            _studentRepository.GetStudent();
            _studentRepository.GetStudent();
            _studentRepository.GetStudent();
            _studentRepository.GetStudent();
            _studentRepository.GetStudent();
            _studentRepository.GetStudent();
            _studentRepository.GetStudent();
            _studentRepository.GetStudent();
            _studentRepository.GetStudent();
            _studentRepository.GetStudent();
            _studentRepository.GetStudent();
            _studentRepository.GetStudent();
            _studentRepository.GetStudent();
            _studentRepository.GetStudent();
            _studentRepository.GetStudent();
            _studentRepository.GetStudent();
            _studentRepository.GetStudent();
            _studentRepository.GetStudent();
            _studentRepository.GetStudent();
            _studentRepository.GetStudent();
            _studentRepository.GetStudent();
            _studentRepository.GetStudent();
            stopWatch.Stop();
            var t = stopWatch.ElapsedMilliseconds;
        }

        //public async Task<IActionResult> StudentById(int id)
        //{
        //    var ParticularStudent = await _studentRepository.GetStudentById(id);
        //    return View(ParticularStudent);
        //}

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
