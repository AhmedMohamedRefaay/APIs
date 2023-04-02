using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
  public  class Review
    {
       
        [Key]
        public int Id { get; set; }
       
 
        public string Comment { get; set; }
        public Decimal Rate { get; set; }
        Product? Product { get; set; }
  
        public User? user { get; set; }

    }
}
