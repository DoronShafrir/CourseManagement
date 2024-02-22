using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseManagement.Model
{
    public class Student : Course
    {
        public int Id { get; set; }
        public int SId { get; set; }
        public int CourseId { get; set; }
    }
       
    public class Students : List<Student>
    {
        public Students() { }

        public Students(IEnumerable<Student> list) : base(list) { }
    }
}