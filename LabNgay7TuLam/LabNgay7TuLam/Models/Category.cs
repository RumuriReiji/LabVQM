using System.ComponentModel.DataAnnotations;

namespace LabNgay7TuLam.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên danh mục không được để trống")]
        [StringLength(150, MinimumLength = 6, ErrorMessage = "Tên danh mục phải từ 6 đến 150 ký tự")]
        public string Name { get; set; }
    }
}
