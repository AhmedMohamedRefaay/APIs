using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
   public class Card
    {
        public long Number { set; get; }

        public int CID { get; set; }///????????????????
         
        public int CVV  { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }

        public IEnumerable<Order> orders { get; set; }

 
        public Buyer buyer { get; set; }
    }
}
