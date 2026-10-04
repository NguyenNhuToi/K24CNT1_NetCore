using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nnt_TvcLesson14.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Giá không được để trống")]
        public float Price { get; set; }

        public float SalePrice { get; set; } = 0;

        public byte Status { get; set; } = 1;

        [Required(ErrorMessage = "Danh mục không được để trống")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [StringLength(100)]
        public string? Image { get; set; }

        [StringLength(350)]
        public string? Description { get; set; }
    }
}