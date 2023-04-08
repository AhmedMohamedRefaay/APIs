using Domain;
using System.ComponentModel.DataAnnotations;

namespace ModelDto.Review
{
    public class ReviewMinimalDTO
    {

        public int Id { get; set; }
        public string? Comment { get; set; }
        public int Rate { get; set; }
        public DateTime Date { get; set; }
        

        public ReviewMinimalDTO() { }
        
    }
}
