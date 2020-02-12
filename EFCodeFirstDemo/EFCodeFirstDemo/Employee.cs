using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EFCodeFirstDemo
{
  public  class Employee
    {
        [Key]
        public int Eid { get; set; }      //one piece of data is representerd in property
        public string Ename { get; set; }
        public string Designation { get; set; }
        public double Salary { get; set; }
    }
}
