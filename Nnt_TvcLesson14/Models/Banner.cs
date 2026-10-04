using System.ComponentModel.DataAnnotations;

namespace Nnt_TvcLesson14.Models
{
    public class Banner
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên banner không được để trống")]
        [StringLength(100)]
        public string Name { get; set; }

        public byte Status { get; set; } = 1;

        public int Prioty { get; set; } = 0;

        [StringLength(100)]
        public string? Image { get; set; }

        [StringLength(350)]
        public string? Description { get; set; }
    }
}