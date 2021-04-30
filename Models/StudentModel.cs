using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Portal.Models
{
    public class StudentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Roll { get; set; }
        public string Group { get; set; }
        public IFormFile ProfileImage { get; set; }
        public string ProfilePicUri { get; set; }
    }
}
