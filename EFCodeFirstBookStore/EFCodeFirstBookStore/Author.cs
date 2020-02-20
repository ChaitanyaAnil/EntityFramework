using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace EFCodeFirstBookStore
{
    class Author
    {
        [Key]
        public int Aid { get; set; }
        public string Aname { get; set; }
        public string Address { get; set; }
     
       
    }
}
