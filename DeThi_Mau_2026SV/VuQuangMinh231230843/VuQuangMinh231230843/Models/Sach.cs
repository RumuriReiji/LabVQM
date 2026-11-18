using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VuQuangMinh231230843.Models;

public partial class Sach
{
    [Key]
    public int MaSach { get; set; }

    public int MaTl { get; set; }

    public string TenSach { get; set; } = null!;

    [Required(ErrorMessage = "Vui lòng nhập giá")]
    [Range(50, 1000, ErrorMessage = "Giá phải là số và nằm trong khoảng 50 đến 1000")]
    public decimal? Gia { get; set; }

    [Required(ErrorMessage = "Vui lòng nhập ảnh")]
    [RegularExpression(@".*\.(jpg|png|gif|tiff)$", ErrorMessage = "Tên file ảnh phải có đuôi: .jpg | .png | .gif | .tiff")]
    public string? Anh { get; set; }

    public virtual TheLoai? MaTlNavigation { get; set; }
}
