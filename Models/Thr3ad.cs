using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Education.Models
{
    public class Thr3ad
    {
        public int Id { get; set; }

        [StringLength(15)]
        [Required]
        public string? Title { get; set; }
        
        [Display(Name = "Release Date")]
        [DataType(DataType.DateTime)]
        public DateTime UploadDate { get; set; }
        public string? Author { get; set; }
        public string? Content { get; set; }
    }
}
