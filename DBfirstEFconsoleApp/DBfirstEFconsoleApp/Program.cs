using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBfirstEFconsoleApp
{
    class Program
    {
        static StudentDbEntities sdb = new StudentDbEntities();
        static void Main(string[] args)
        {
            Console.WriteLine("******************DBFIRST APPROACH CRUD APPLICATION************");
            int ch = 0;
            Console.WriteLine("1.insert 2.display ");
            Console.WriteLine("enter your choice");
            ch = int.Parse(Console.ReadLine());
            switch(ch)
            {
                case 1:
                    InsertStudent();
                    InsertCousrse();
                    break;
                case 2:
                    AllStudents();
                    AllCourses();
                    break;
                    
            }
            
           // InsertStudent();
         //  InsertCousrse();

          //  AllCourses();
          //  AllStudents();
            Console.ReadKey();

        }

        private static void InsertCousrse()
        {
            Console.WriteLine("*************enter Course details****************");
            Console.WriteLine("enter course id");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("enter ctudent name");
            string cname = Console.ReadLine();

            Console.WriteLine("enter course start date");
            DateTime sdate = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("enter fees");
            decimal fee = decimal.Parse(Console.ReadLine());

            var course = new Course
            {
                CourseId = id,
                CourseType = cname,
                StartDate = sdate,
                Fees = fee

            };
            sdb.Courses.Add(course);
            sdb.SaveChanges();
            Console.WriteLine("***********students details inserted succesfully************");
        }

        private static void InsertStudent()
        {
            Console.WriteLine("*************enter student details****************");
            Console.WriteLine("enter student id");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("enter student name");
            string sname = Console.ReadLine();
            Console.WriteLine("enter address");
            string sadd = Console.ReadLine();
            Console.WriteLine("enter student dob");
            DateTime sdate = Convert.ToDateTime(Console.ReadLine());
            var student = new Student1
            {
                S_Id = id,
                S_Name = sname,
                S_Address = sadd,
                S_DOB = sdate
            };
            sdb.Student1.Add(student);
            sdb.SaveChanges();
            Console.WriteLine("***********course details inserted succesfully************");
        }

        private static void AllStudents()
        {
            Console.WriteLine("All students are:");
            var students = sdb.Student1;
            foreach (var s in students)
            {
                Console.WriteLine("{0} {1} {2} {3} ", s.S_Id, s.S_Name, s.S_Address, s.S_DOB);
            }
        }

        private static void AllCourses()
        {
            Console.WriteLine("*****************************");
            Console.WriteLine("All available Courses");
            var courses = sdb.Courses;
            foreach (var c in courses)
            {
                Console.WriteLine("{0} {1} {2} {3} ", c.CourseId, c.CourseType, c.StartDate, c.Fees);
            }
        }
    }
}
