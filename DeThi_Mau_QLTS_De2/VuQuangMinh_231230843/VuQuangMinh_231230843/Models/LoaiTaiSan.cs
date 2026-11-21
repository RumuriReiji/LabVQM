using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VuQuangMinh_231230843.Models;

public partial class LoaiTaiSan
{
    [Key]
    public int MaLoai { get; set; }

    public string TenLoai { get; set; } = null!;

    public virtual ICollection<TaiSan> TaiSans { get; set; } = new List<TaiSan>();
}
