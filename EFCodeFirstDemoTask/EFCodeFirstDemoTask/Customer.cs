using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EFCodeFirstDemoTask
{
    class Customer
    {
        [Key]
        public int Cid { get; set; }
        [Required]
        [MaxLength(250)]
        public string Cname { get; set; }
        
        public long Mobileno { get; set; }
      
        public string Address { get; set; }
     public virtual ICollection<Purchase> Purchases { get; set; }
    }
}
