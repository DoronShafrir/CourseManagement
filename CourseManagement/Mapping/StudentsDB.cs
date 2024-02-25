using CourseManagement.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CourseManagement.Mapping
{
    public class StudentsDB
    {
        private string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Physics.mdf;Integrated Security=True";

        public Students SelectAll()
        {
            Students students = new Students();

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("SELECT Person.Name, Courses.CourseName FROM Student INNER JOIN Person ON  SId=Person.PId JOIN  Courses ON Student.CourseId = Courses.CId;", connection))
            {
                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Student student = new Student
                            {
                                Name = reader["Name"].ToString(),
                                CourseName = reader["CourseName"].ToString(),

                            };
                            students.Add(student);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle the exception (log, throw, etc.)
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return students;
        }
        public string RenderAllStudents()
        {
            Students students = SelectAll();
            string RenderTable = "";
            foreach (var item in students)
            {
                RenderTable += this.CreateTableLIne(item);
                RenderTable += "<br>";
            }
            return RenderTable;
        }
        public string CreateTableLIne(Student item)
        {
            string studentsList = "";
            studentsList += item.Name.ToString() + "  ";
            studentsList += item.CourseName.ToString() + "  ";


            return studentsList;

        }
        public int Insert(Student student)
        {
            int records = 0;
            int arg1 = CheckStudent(student.Name);
            int arg2 = CheckCourse(student.CourseName);
            if (arg1 != 0 && arg2 != 0)
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand($"INSERT INTO Student VALUES('{arg1}','{arg2}')", connection))

                    try
                    {
                        connection.Open();
                        records = command.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                    }
                    finally
                    {
                        connection.Close();
                    }
            }

            return records;
        }

        public int DeleteStudent(int studentId)
        {
            int records = 0;
            //int arg1 = CheckStudent(student.Name);
            //int arg2 = CheckCourse(student.CourseName); 
            int arg1 = studentId;
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand($"DELETE FROM Student WHERE Id ='{arg1}';", connection))

                try
                {
                    connection.Open();
                    records = command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                }
                finally
                {
                    connection.Close();
                }
            return records;
        }
        //checkmname() checks if teh anme exist in the people table if yes return the PId and if not return 0
        public int CheckStudent(string item)
        {
            int recordId = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand($"SELECT PId FROM Person WHERE Name = '{item}';", connection))

                try
                {
                    connection.Open();
                    recordId = command.ExecuteScalar() == null ? 0 : (int)command.ExecuteScalar();
                }
                catch (Exception e)
                {
                }
                finally
                {
                    connection.Close();
                }
            return recordId;
        }
        public int CheckCourse(string item)
        {
            int recordId = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand($"SELECT CId FROM Courses WHERE CourseName = '{item}';", connection))

                try
                {
                    connection.Open();
                    recordId = command.ExecuteScalar() == null ? 0 : (int)command.ExecuteScalar();
                }
                catch (Exception e)
                {
                }
                finally
                {
                    connection.Close();
                }
            return recordId;
        }

        public string PrepareCoursestDropDownList()
        {
            Courses courses = new Courses();
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("SELECT Courses.CId, Courses.CourseName FROM  Courses", connection))
            {
                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    // Loop through the data and add <option> elements to the <select> element
                    while (reader.Read())
                    {
                        Student student = new Student
                        {
                            CId = (int)reader["CId"],                           
                            CourseName = reader["CourseName"].ToString()
                        };
                        courses.Add(student);
                    }

                    // Close the SqlDataReader
                    reader.Close();
                }
                catch (Exception ex)
                {
                    // Handle the exception (log, throw, etc.)
                    Console.WriteLine(ex.Message);
                }

                finally
                {
                    connection.Close();
                }
            }
            string prepartion;
            prepartion = " <select name=\"idCourseToSelect\" >";
            prepartion += "<option>Course to register the student>";
            foreach (var item in courses)
            {
                prepartion += $"<option value={item.CId}> Course Name:{item.CourseName} </ option >";
            }
            prepartion += "</select>";
            return prepartion;
        }
    

        public string PrepareStudenstsDropDownList()
        {
            Students students = new Students();
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("SELECT Student.Id, Person.Name FROM Student INNER JOIN Person ON  SId=Person.PId ;", connection))
            {
                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    // Loop through the data and add <option> elements to the <select> element
                    while (reader.Read())
                    {
                        Student student = new Student
                        {
                            Id = (int)reader["Id"],
                            Name = reader["Name"].ToString()
                        };
                        students.Add(student);
                    }

                    // Close the SqlDataReader
                    reader.Close();
                }
                catch (Exception ex)
                {
                    // Handle the exception (log, throw, etc.)
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            string prepartion;
            prepartion = " <select name=\"idToDelete\" >";
            prepartion += "<option>Student to add a course>";
            foreach (var item in students)
            {
                prepartion += $"<option value={item.Id}> Student Name:{item.Name} </ option >";
            }
            prepartion += "</select>";
            return prepartion;
        }

        public string PrepareStudenstsDropDownListToDelete()
        {
            Students students = new Students();
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("SELECT Student.Id, Person.Name, Courses.CourseName FROM Student INNER JOIN Person ON  SId=Person.PId JOIN  Courses ON Student.CourseId = Courses.CId;", connection))
            {
                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();



                    // Loop through the data and add <option> elements to the <select> element
                    while (reader.Read())
                    {
                        Student student = new Student
                        {
                            Id = (int)reader["Id"],
                            Name = reader["Name"].ToString(),
                            CourseName = reader["CourseName"].ToString()
                        };
                        students.Add(student);
                    }

                    // Close the SqlDataReader
                    reader.Close();
                }
                catch (Exception ex)
                {
                    // Handle the exception (log, throw, etc.)
                    Console.WriteLine(ex.Message);
                }

                finally
                {
                    connection.Close();
                }
            }
            string prepartion;
            prepartion = " <select name=\"idToDelete\" >";
            prepartion += "<option>Student to be removed from course>";
            foreach (var item in students)
            {
                prepartion += $"<option value={item.Id}> Name:{item.Name}   Course:{item.CourseName} </ option >";
            }
            prepartion += "</select>";
            return prepartion;
        }

    }
}