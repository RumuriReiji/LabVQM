using System.ComponentModel.DataAnnotations;

namespace LabDay11.Models
{
    public class Student
    {
        public int Id { get; set; } //Mã sinh viên

        [Display(Name = "Họ tên")]
        [Required(ErrorMessage = "{0} không được để trống")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "{0} phải từ {2} đến {1} ký tự")]
        public string? Name { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "{0} không được để trống")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@gmail\.com$", ErrorMessage = "{0} phải có đuôi @gmail.com")]
        public string? Email { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "{0} không được để trống")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
            ErrorMessage = "{0} phải ít nhất 8 ký tự, gồm chữ hoa, chữ thường, chữ số và ký tự đặc biệt")]
        public string? Password { get; set; }

        [Display(Name = "Ngành học")]
        [Required(ErrorMessage = "Vui lòng chọn {0}")]
        public Branch? Branch { get; set; }

        [Display(Name = "Giới tính")]
        [Required(ErrorMessage = "Vui lòng chọn {0}")]
        public Gender? Gender { get; set; }

        [Display(Name = "Hệ đào tạo")]
        public bool IsRegular { get; set; } //true-chính quy, false-phi chính quy

        [Display(Name = "Địa chỉ")]
        public string? Address { get; set; }

        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime DateOfBorth { get; set; }

        [Display(Name = "Điểm")]
        [Range(0.0, 10.0, ErrorMessage = "{0} phải từ {1} đến {2}")]
        public double? Score { get; set; }

        [Display(Name = "Ảnh đại diện")]
        public string? AvatarUrl { get; set; }
    }
}
