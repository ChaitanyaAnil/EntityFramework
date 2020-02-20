using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstProductCustomer
{
    class Program
    {
        static void Main(string[] args)
        {
           // CustomerInsert();
            ProductInsert();

        }
        private static void ProductInsert()
        {
            using (ProductOrderContext db = new ProductOrderContext())
            {
                // Create and save a new products
                Console.Write("Enter Product details: ");
               // Console.WriteLine("enter cid");
               // int Pid = int.Parse(Console.ReadLine());
                Console.WriteLine("enter product name");
                string Pname = Console.ReadLine();
                Console.WriteLine("enter product  price");
                double price = double.Parse(Console.ReadLine());

                var product=new Product { Pname=Pname,Price=price };
                db.Products.Add(product);
                db.SaveChanges();
                var pdisplay = from p in db.Products
                               orderby p.Pid
                               select p;
                Console.WriteLine("product  details are:");

                foreach (var res in pdisplay)
                {
                    Console.WriteLine("{0} {1} {2}  ", res.Pid,res.Pname,res.Price);
                }

                Console.ReadKey();

                

            }
        }

        private static void CustomerInsert()
        {
            using (ProductOrderContext db = new ProductOrderContext())
            {
                // Create and save a new products
                Console.Write("Enter customer details: ");
               // Console.WriteLine("enter cid");
               // int cid = int.Parse(Console.ReadLine());
                Console.WriteLine("enter cname");
                string cname = Console.ReadLine();
                Console.WriteLine("enter cmobile");
                long cmobile = long.Parse(Console.ReadLine());
                Console.WriteLine("enter caddress");
                string cadd = Console.ReadLine();

                var customer = new Customer {  Cname = cname, Cmobileno = cmobile, Caddress = cadd };
                db.Customers.Add(customer);
                db.SaveChanges();
                var cdisplay = from c in db.Customers
                               orderby c.Cid
                               select c;
                Console.WriteLine("customer details are:");

                foreach (var res in cdisplay)
                {
                    Console.WriteLine("{0} {1} {2} {3} ", res.Cid, res.Cname, res.Cmobileno, res.Caddress);
                }

                Console.ReadKey();











            }
        }
    }
}
