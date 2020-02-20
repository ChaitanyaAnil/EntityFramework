using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace EFCodeFirstProductCustomer
{
    class Customer
    {
        [Key]
        public int Cid { get; set; }
        public string Cname { get; set; }
        public long Cmobileno { get; set; }
        public string Caddress { get; set; }
       public virtual List<Product> ProductDetails { get; set; }
    }
}
