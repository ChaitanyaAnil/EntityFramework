using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstDemoTask
{
    class Program
    {
       static CustomerContext cpp = new CustomerContext();

        static void Main(string[] args)
        {
            // InsertData();
            ShowAll();
            Console.ReadKey();

        /*   // Insert();
            Display();
            
        }
        public static void Insert()
        {
            Customer cst = new Customer();
            Console.WriteLine("Enter the Customer name");
            cst.Cname = Console.ReadLine();
           
            Console.WriteLine("Enter the Customer Mobilenumber");
            cst.Mobileno = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Customer City");
            cst.Address = Console.ReadLine();


            Console.WriteLine("Product List");
            cst.Products = ProductDataList();
            cpp.Customers.Add(cst);
            cpp.SaveChanges();
            Console.WriteLine("Data Inserted Successfully");

        }

        public static List<Product> ProductDataList()
        {
            Product pd = new Product();
            List<Product> list = new List<Product>();
            Console.WriteLine("Product name");
            pd.Pname = Console.ReadLine();

           

            Console.WriteLine("Product Price");
            pd.Price = double.Parse(Console.ReadLine());

            list.Add(pd);
            return list;
        }
        public static void  Display()
        {
            
            using (var db = new CustomerContext())
            {
                int id = int.Parse(Console.ReadLine());
                var query = from c in db.Customers
                            where c.Cid == id
                            select c;
                foreach(var  res in query)
                {
                    Console.WriteLine(res.Cname,res.Mobileno,res.Address,res.Products);
                }
                Console.ReadKey();
            }
            */
        }
        private static void InsertData()
        {
            CustomerContext ctx = new CustomerContext();
            var customers = new List<Customer>
            {
                new Customer{Cname="Anil",Mobileno=9812345678,Address="chennai"},
                 new Customer{Cname="prasad",Mobileno=9812345678,Address="hyderabad"},
                 new Customer{Cname="satya",Mobileno=9812345678,Address="chennai"},
                 new Customer{Cname="Anand",Mobileno=9812345678,Address="hyderabad"},
            };
            customers.ForEach(s => ctx.Customers.Add(s));
            ctx.SaveChanges();
            var products = new List<Product>
            {
                new Product{Pname="sweets",Price=450},
                new Product{Pname="snacks",Price=150},
                new Product{Pname="drinks",Price=300},
                new Product{Pname="choclates",Price=250}

            };
            products.ForEach(p => ctx.Products.Add(p));
            ctx.SaveChanges();
            var purchases = new List<Purchase>
            {
                new Purchase{OrderDate=Convert.ToDateTime("09-02-2020"),Pid=1,Cid=2},
                 new Purchase{OrderDate=Convert.ToDateTime("10-02-2020"),Pid=2,Cid=1},
                  new Purchase{OrderDate=Convert.ToDateTime("11-02-2020"),Pid=3,Cid=2},
                   new Purchase{OrderDate=Convert.ToDateTime("12-02-2020"),Pid=4,Cid=3}
            };
            purchases.ForEach(pr => ctx.Purchases.Add(pr));
            ctx.SaveChanges();
        }
        private static void ShowAll()
        {
            CustomerContext ctx = new CustomerContext();
            var customers = ctx.Customers;
            Console.WriteLine("customer details are :");
            foreach(var c in customers)
            {
                Console.WriteLine("{0} {1} {2} {3}",c.Cid, c.Cname, c.Mobileno, c.Address);
            }

            var products = ctx.Products;
            Console.WriteLine("product details are:");
            foreach(var pd in products)
            {
                Console.WriteLine("{0} \t {1} \t{2}",pd.Pid, pd.Pname, pd.Pname);
            }
            Console.WriteLine("\n purchases... \n");
            var purchases = ctx.Purchases;
            Console.WriteLine("{0,-8}{1,-14}{2,-8}{3,-14}{4,14}{5,8}{6,15}","PurchID","orderDate",
                "Pid","Pname","Price","CustId","CustName");
            foreach(var pr in purchases)
            {
            Console.WriteLine("{0,-8}{1,-14}{2,-8}{3,-14}RS{4,10:N}{5,8}{6,15}", pr.Id, pr.OrderDate.ToShortDateString(),
                 pr.Pid, pr.Product.Pname, pr.Product.Price, pr.Cid, pr.Customer.Cname);
            }


        }

    }
}
