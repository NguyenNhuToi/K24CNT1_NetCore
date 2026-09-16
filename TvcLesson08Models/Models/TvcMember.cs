using System.ComponentModel;

namespace TvcLesson08Models.Models
{
    public class TvcMember
    {
        public string TvcMemberId { get; set; }
        public string TvcUserName { get; set; }
        public string TvcPassword { get; set; }

        [DisplayName("Họ và tên")]
        public string TvcFullName { get; set; }
        public string TvcEmail { get; set; }
    }
}
