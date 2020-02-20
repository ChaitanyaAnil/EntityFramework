using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace EFCodeFirstProductCustomer
{
    class ProductOrderContext:DbContext
    {
     public    DbSet<Customer> Customers { get; set; }
      public  DbSet<Product> Products { get; set; }


    }
}
