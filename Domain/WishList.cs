using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
   public class WishList
    {
        [Key]
        [Column(Order = 1)]
        public int Id { get; set; }

        public DateTime DataAdded { get; set; } //?????????
        [Key]
         [Column(Order = 2)]
         
        public Buyer  buyer{ get; set; }

        public IEnumerable<Product> products { get; set; }

    }
}
