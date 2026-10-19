using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DemoDay7.Models
{
    public class VqmMember
    {
        public int Id { get; set; }
        [DisplayName("Tài khoản")]
        [Required(ErrorMessage = "Tài khoản không được để trống")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Tài khoản có độ dài trong khoảng 3-20 ký tự")]
        public string VqmUserName { get; set; }

        [DisplayName("Password")]
        [StringLength(100, MinimumLength = 8, ErrorMessage ="Mật khẩu tối thiểu 8 ký tự")]
        public string VqmPassword { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Email không được để trống")]
        [DataType(DataType.EmailAddress)]
        public string VqmEmail { get; set; }

        [DisplayName("Điện thoại")]
        [Required(ErrorMessage = "Bạn chưa nhập điện thoại")]
        [RegularExpression(@"^0\d{9,9}",ErrorMessage ="Điện thoại phải là 10 ký tự số, bắt đâì bằng")]

        public string VqmPhone { get; set; }

    }
}
