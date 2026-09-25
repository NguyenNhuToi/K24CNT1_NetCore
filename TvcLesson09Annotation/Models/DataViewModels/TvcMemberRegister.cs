using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TvcLesson09Annotation.Models.DataViewModels
{
    /// <summary>
    /// Data Annotation - Validation
    /// </summary>
    public class TvcMemberRegister
    {
        public int TvcMemberId { get; set; }

        [DisplayName("Tên đăng nhập")]
        [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Tên đăng nhập phải từ 5 đến 20 ký tự")]
        public string TvcUserName { get; set; }

        [DisplayName("Mật khẩu")]
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [DataType(DataType.Password)]
        public string TvcPassword { get; set; }

        public string TvcEmail { get; set; }
        public string TvcPhoneNumber { get; set; }
        public string TvcFullName { get; set; }
        public DateTime TvcDateOfBirth { get; set; }
    }
}