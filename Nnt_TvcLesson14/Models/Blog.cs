using System.ComponentModel.DataAnnotations;

namespace Nnt_TvcLesson14.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tiêu đề blog không được để trống")]
        [StringLength(100)]
        public string Name { get; set; }

        public byte Status { get; set; } = 1;

        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [StringLength(100)]
        public string? Image { get; set; }

        [StringLength(350)]
        public string? Description { get; set; }
    }
}