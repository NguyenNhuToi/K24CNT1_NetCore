using System.ComponentModel.DataAnnotations;

namespace TvcLesson09Annotation.Models.DataModels
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên danh mục không được để trống")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Tên danh mục phải từ 6 đến 50 ký tự")]
        public string Name { get; set; }
    }
}
