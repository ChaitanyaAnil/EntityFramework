using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFirstProductTask
{
    class Program
    {
        static StudentDbEntities sdb = new StudentDbEntities();
        static void Main(string[] args)
        {
            Console.WriteLine("DATA BASE FIRST APPROACH ");
            int ch = 0;
            Console.WriteLine("1.insert 2.display ");
            Console.WriteLine("enter your choice");
            ch = int.Parse(Console.ReadLine());
            switch (ch)
            {
                case 1:
                    InsertCetogery();
                      InsertProduct();

                    break;
                case 2:
                    ShowCategory();
                     ShowProduct();
                    break;

            }
            //  InsertCetogery();
            //   InsertProduct();
            // ShowCategory();
            // ShowProduct();
            Console.ReadKey();
        }

        private static void ShowProduct()
        {
            Console.WriteLine("product details with category");
           
            var product = sdb.Products;
            Console.WriteLine("{0,-8} {1,-14} {2,-14} {3,-8} {4,14} ", "Pid", "pname", "price", "cid", "Cname");
            foreach (var p in product)
            {
                Console.WriteLine("{0,-8} {1,-14} RS {2,-14} {3,-8} {4,14} ", p.Pid, p.Title, p.Price, p.Cid, p.Category.Cname);
            }
        }

        private static void ShowCategory()
        {
            Console.WriteLine("category details");
            var category = sdb.Categories;
            foreach (var c in category)
            {
                Console.WriteLine("{0} {1} ", c.Cid, c.Cname);
            }
        }

        private static void InsertProduct()
        {
            Console.WriteLine("enter product detials");
            Console.WriteLine("enter pname");
            string pname = Console.ReadLine();
            Console.WriteLine("enter price");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.WriteLine("eneter cateogry id");
            int id = int.Parse(Console.ReadLine());
            var products = new Product
            {
                Title = pname,
                Price = price,
                Cid=id

            };
            sdb.Products.Add(products);
            sdb.SaveChanges();
            Console.WriteLine("insert succes");
        }

        private static void InsertCetogery()
        {
            Console.WriteLine("enter cetogry detials");
            Console.WriteLine("enter name");
            string cname = Console.ReadLine();
            var category = new Category
            {
                Cname = cname
            };
            sdb.Categories.Add(category);
            sdb.SaveChanges();
            Console.WriteLine("insert succes");
        }
    }
}
