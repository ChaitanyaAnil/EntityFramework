using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            
             Console.WriteLine("********************* Employee CRUD APPLICATION *****************\n 1.insert Employee \n 2.Display All Employees \n 3.update Employee\n  4.serach Employee\n 5.delete Employee\n 6.exit\n");
            int ch = 0;
            do
            {

                Console.WriteLine("enter your choice");
                 ch = int.Parse(Console.ReadLine());



                switch (ch)
                {
                    case 1:
                        InsertData();
                        break;
                    case 2:
                        DisplayAllData();
                        break;
                    case 3:
                        UpdataData();
                        break;
                    case 4:
                        SearchById();
                        break;
                    case 5:
                        DeleteDataById();
                        break;
                    case 6:Console.WriteLine("/n *******Thank you ***********");
                        return;
                    default: Console.WriteLine("wrong choice entered ***please select choices between 1 to 5");
                        break;

             


                }
            } while (ch<=6);

            Console.ReadKey();

        }

        private static void UpdataData()
        {
            EmployeeContext empctx = new EmployeeContext();
            Console.WriteLine("enter employee id to update details");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("enter salary details");
            double sal = double.Parse(Console.ReadLine());
            Console.WriteLine("enter employee designation  details");
            string desg = Console.ReadLine();

            var employees = empctx.Employees;


            var emp = from e in employees
                      where e.Eid == id
                      select e;
            foreach(var e in emp)
            {
                e.Salary = sal;
                e.Designation = desg;
            }

            foreach (var res in emp)
            {
                Console.WriteLine(" the row is \n {0} {1} {2} {3}", res.Eid, res.Ename, res.Designation, res.Salary);
            }
            empctx.SaveChanges();

            Console.WriteLine("*************update success*************");
        }

        private static void DeleteDataById()
        {
            EmployeeContext empctx = new EmployeeContext();
            Console.WriteLine("enter employee id to delete details");
            int id = int.Parse(Console.ReadLine());
            var emp1 = empctx.Employees;
            var emp = from e in emp1
                      where e.Eid == id
                      select e;

            empctx.Employees.RemoveRange(emp);
            foreach (var res in emp)
            {
                Console.WriteLine(" the deleted row is \n {0} {1} {2} {3}", res.Eid, res.Ename, res.Designation, res.Salary);
            }
            empctx.SaveChanges();
            Console.WriteLine("*************Delete success*************");
        }

        private static void SearchById()
        {
            EmployeeContext empctx = new EmployeeContext();
            Console.WriteLine("enter employee id to get details");
            int id = int.Parse(Console.ReadLine());
            var emp1 = empctx.Employees;
            var emp = from e in emp1
                      where e.Eid == id
                      select e;
            foreach(var res in emp)
            {
                Console.WriteLine("{0} {1} {2} {3}", res.Eid, res.Ename, res.Designation, res.Salary);
            }
        }

        private static void DisplayAllData()
        {
            EmployeeContext empctx = new EmployeeContext();
            var employees = empctx.Employees;
            Console.WriteLine("******** Employees detials Retrived successfully*******");
            foreach (var emp in employees)
            {
                Console.WriteLine(" {0} \n {1} \n {2} \n {3} ", emp.Eid, emp.Ename, emp.Designation, emp.Salary);
            }
        }

        private static void InsertData()
        {
            EmployeeContext ect = new EmployeeContext();
            Console.WriteLine("enter employee name");
            string name = Console.ReadLine();
            Console.WriteLine("enter designation");
            string desg = Console.ReadLine();
            Console.WriteLine("Enter salary");
            double sal = Convert.ToDouble(Console.ReadLine());
            ect.Employees.Add(new Employee
            {
                Ename = name,
                Designation = desg,
                Salary = sal
            });
            ect.SaveChanges();
            Console.WriteLine("*************insert success*************");
        }
    }
}
