using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Portal.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult GetAllStudent()
        {
            return View();
        }

        public IActionResult StudentById()
        {
            return View();
        }

        public IActionResult AddNewStudent()
        {
            return View();
        }
    }
}
