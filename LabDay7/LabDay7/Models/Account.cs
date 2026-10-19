using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LabDay7.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage = "Họ và tên không được để trống")]
        [MinLength(6, ErrorMessage = "Họ tên ít nhất 6 ký tự")]
        [MaxLength(20, ErrorMessage = "Họ tên tối đa 20 ký tự")]
        public string Fullname { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage ="Email không được để trống")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng")]
        public string Email { get; set; }

        [Display(Name= "Số điện thoại")]
        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        [Remote(action: "VerifyPhone", controller: "Account")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Display(Name = "Địa chỉ thường trú")]
        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        [StringLength(35, ErrorMessage ="Địa chỉ không vượt quá 35 ký tự")]
        public string Address { get; set; }

        [Display(Name ="Ảnh đại diện")]
        public string Avatar { get; set; }

        [Display(Name= "Ngày sinh" )]
        [Required(ErrorMessage = "Ngày sinh không được để trống")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        [Display(Name = "Giới tính")]
        public string Gender { get; set; }

        [Display(Name ="Mật khẩu")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name ="Link Facebook cá nhân")]
        [Required(ErrorMessage ="Link Facebook không được để trống")]
        [Url(ErrorMessage ="Url phải đúng định dạng bao gồm http hoặc https, tên miền VD: https://facebook.com/vqminh")]
        public string Facebook { get; set; }

    }
}
