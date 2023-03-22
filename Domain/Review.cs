using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
  public  class Review
    {
        public int Id { get; set; }

        public float Rating { get; set; }

        public string RatingDetails { get; set; }

        public DateTime ReviewDate { get; set; }

 

        public Buyer buyer { get; set; }

        //Relation between Product and Review ??????

       

        public Product product { get; set; }

    }
}
