using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ReceptionsListProject.Models
{
    public class Reception
    {
        public int ID { get; set; }
      
        [Display(Name = "Created Date")]
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Components { get; set; } = string.Empty;
        public string Instructions { get; set; } = string.Empty;
        
        public string ImageUrl { get; set; } = string.Empty;
    }
}