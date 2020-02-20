using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace EFCodeFirstProductCustomer
{
    class Product
    {
        [Key]
        public int Pid { get; set; }
        public string Pname { get; set; }
        public double Price { get; set; }
        public virtual List<Customer> CustomerDetails { get; set; }
    }
}
