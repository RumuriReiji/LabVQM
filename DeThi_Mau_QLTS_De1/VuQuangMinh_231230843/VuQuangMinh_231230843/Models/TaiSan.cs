using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VuQuangMinh_231230843.Models;

public partial class TaiSan
{
    [Key]
    public int MaTs { get; set; }

    public int MaLoai { get; set; }

    public string TenTs { get; set; } = null!;

    [Required(ErrorMessage = "Vui lòng nhập nguyên giá")]
    [Range(1, 2000, ErrorMessage = "Nguyen giá phải là số và nằm trong khoảng 1 đến 2000")]
    public decimal? NguyenGia { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập ảnh")]
    [RegularExpression(@".*\.(jpg|jpeg|png|webp)$", ErrorMessage = "Tên file ảnh phải có đuôi: .jpg | .jpeg | .png | .webp")]
    public string? Anh { get; set; }

    public virtual LoaiTaiSan? MaLoaiNavigation { get; set; }
}
