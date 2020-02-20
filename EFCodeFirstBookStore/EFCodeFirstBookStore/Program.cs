using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstBookStore
{
    class Program
    {
        static void Main(string[] args)
        {
             start();
           

        }

        private static void start()
        {
            Console.WriteLine("*********BOOK-APP CRUD APPLICATION**********");

            int ch = 0;
            Console.WriteLine("1.insert 2.display ");
            Console.WriteLine("enter your choice");
            ch = int.Parse(Console.ReadLine());
            for (int i = 0; i < ch; i++)
            {
                switch (ch)
                {
                    case 1:
                        Insert();
                        Console.WriteLine("inserted succes");
                        break;
                    case 2:
                        Display();
                        break;
                    default:return;
                }

            }
        }

        private static void Insert()
        {
            Book b = new Book();
            BookContext btx = new BookContext();
            Console.WriteLine("enter Book details");
            Console.WriteLine("enter book title");
            string title = Console.ReadLine();
            Console.WriteLine("enter Book Price");
            double price = Double.Parse(Console.ReadLine());
            var books = new List< Book>
            {
                new Book{Title=title,Price=price}
            };
            books.ForEach(bo => btx.Books.Add(bo));
            
            btx.SaveChanges();



            Console.WriteLine("enter Author details");
            Console.WriteLine("enter author name");
            string name = Console.ReadLine();
            Console.WriteLine("enter author Address");
            string address = Console.ReadLine();
           
            var authors = new List<Author>
            {
                new Author{
                Aname = name,
                Address = address,
                
                
                }
            };
            authors.ForEach(au => btx.Authors.Add(au));
            btx.SaveChanges();


            Console.WriteLine("enter  detail of  book transactons");
            Console.WriteLine("enter dare of book published");
            DateTime pdate = Convert.ToDateTime(Console.ReadLine());
            Author a = new Author();
            Console.WriteLine("enter author id");
            int aid = int.Parse(Console.ReadLine());
            Console.WriteLine("enter book id");
            int bid = int.Parse(Console.ReadLine());

            var det = new List<Detail>
            {
                new Detail{
                PublishDate=pdate,
                Bid=bid,
                Aid=aid
                

                }

            };
            det.ForEach(d => btx.Details.Add(d));
            btx.SaveChanges();


        }
        private static void Display()
        {
            BookContext btx = new BookContext();
            var books = btx.Books;
            Console.WriteLine("books details are:");
            foreach(var b in books)
            {
                Console.WriteLine("{0} {1} {2}", b.Bid, b.Title, b.Price);
            }
            var authors = btx.Authors;
            Console.WriteLine("**********************************");
            Console.WriteLine("author details are:");
            foreach (var a in authors)
            {
                Console.WriteLine("{0} {1} {2}", a.Aid,a.Aname,a.Address);
            }
            Console.WriteLine("**********************************");
            Console.WriteLine("book store  with all detials ");
            Console.WriteLine("{0,-8}{1,-10}{2,-8}{3,-8}{4,-8}{5,-8}{6,-8}{7,-8}","TID","Tp_DATE","BOOKID","TITLE","PRICE","AID","Aname","Aadress");
            var details = btx.Details;
            foreach(var d in details)
            {
                Console.WriteLine("{0,-8}{1,-8}{2,5}{3,-8}{4,-8}{5,-8}{6,-14}{7,-8}", d.Tid, d.PublishDate.ToShortDateString(),d.Bid,d.Books.Title,d.Books.Price,d.Aid,d.Authors.Aname,d.Authors.Address);
            }
            Console.ReadKey();
        }
    }
}
