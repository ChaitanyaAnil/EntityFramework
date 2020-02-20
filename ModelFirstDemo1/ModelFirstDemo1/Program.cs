using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelFirstDemo1
{
    class Program
    {
      static  ModelfirstContainer mfb = new ModelfirstContainer();
        static void Main(string[] args)
        {
            Console.WriteLine("MODEL FIRST APPROACH ");
          
            
                int ch = 0;
            do
            {
                Console.WriteLine("1.insert 2.display 3.exit ");
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
                    case 3:
                        return ;
                        


                }
            } while (ch <= 2);
            
            
            
            
        }
        private static void ShowProduct()
        {
            Console.WriteLine("product details with category");

            var product = mfb.Productdets;
            Console.WriteLine("{0,-8} {1,-14} {2,-14} {3,-8} {4,14} ", "Pid", "pname", "price", "cid", "Cname");
            foreach (var p in product)
            {
                Console.WriteLine("{0,-8} {1,-14} RS {2,-14} {3,-8} {4,14} ", p.Pid, p.Pname, p.Price, p.Cid, p.Categorydet.Cname);
            }
        }

        private static void ShowCategory()
        {
            Console.WriteLine("category details");
            var category = mfb.Categorydets;
            foreach (var c in category)
            {
                Console.WriteLine("{0} {1} ", c.Cid, c.Cname);
            }
        }
        private static void InsertCetogery()
            {
                Console.WriteLine("enter cetogry detials");
                Console.WriteLine("enter name");
                string cname = Console.ReadLine();
                var category = new Categorydet
                {
                    Cname = cname
                };
                mfb.Categorydets.Add(category);
            mfb.SaveChanges();
                Console.WriteLine("insert succes");
            
             }
        private static void InsertProduct()
        {
           
            Console.WriteLine("enter product detials");
            Console.WriteLine("enter pname");
            string pname = Console.ReadLine();
            Console.WriteLine("enter price");
            double price = double.Parse(Console.ReadLine());
            Console.WriteLine("eneter cateogry id");
            int id = int.Parse(Console.ReadLine());
            var products = new Productdet
            {
               Pname=pname,Price=price,Cid=id

            };
            mfb.Productdets.Add(products);
            mfb.SaveChanges();
            Console.WriteLine("insert succes");


        }
    }
}
