using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
namespace EFCodeFirstBookStore
{
    class Detail
    {
        [Key]
        public int Tid { get; set; }
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }
        public int Bid { get; set; }
        public int Aid { get; set; }
        public virtual Book Books { get; set; }
        public virtual Author Authors { get; set; }
    }
}
