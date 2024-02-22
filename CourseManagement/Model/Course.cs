﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseManagement.Model
{
    public class Course : Person
    {
        public int CId { get; set; }
        public string CourseName { get; set; }
        public string CourseNumber { get; set; }
        public int ResponsibleTeacher { get; set; }
        //public Course() :base()
        //{ 
        //}
    }

    public class Courses : List<Course>
    {
        public Courses() { }

        public Courses(IEnumerable<Course> list)
            : base(list)
        {

        }
    }
}